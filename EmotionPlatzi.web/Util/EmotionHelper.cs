using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Emotion;
using System.IO;
using Microsoft.ProjectOxford.Emotion.Contract;
using EmoPlatzi.web.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;

namespace EmotionPlatzi.web.Util
{
    public class EmotionHelper
    {

        public EmotionServiceClient EmoClient;

        public EmotionHelper (string key)
            {
            EmoClient = new EmotionServiceClient(key);
            
            }

        public async Task<EmoPicture>  DetectAndExtractFacesAsync(Stream imagen)
        {
            Emotion[] Emotions = await EmoClient.RecognizeAsync(imagen);
            var emoPicture = new EmoPicture();
            emoPicture.Faces = ExtractFaces(Emotions,emoPicture);
            return emoPicture;

        }

        private ObservableCollection<EmoFace> ExtractFaces(Emotion[] Emotions, EmoPicture emoPicture)
        {
            var ListaFaces = new ObservableCollection<EmoFace>();//inicialización.
            foreach (Emotion Emotion in Emotions)
            {
                var face = new EmoFace
                {
                    x = Emotion.FaceRectangle.Left,
                    y = Emotion.FaceRectangle.Top,
                    heigh = Emotion.FaceRectangle.Height,
                    width = Emotion.FaceRectangle.Width,
                    Picture = emoPicture
                };
             
                face.Emotions = ConvertEmotions(Emotion.Scores,face);
                ListaFaces.Add(face);// agregar una cara reconocida
            };
            
            return ListaFaces;
        }

        private ObservableCollection<EmoEmotion> ConvertEmotions(Scores scores,EmoFace face)
        {
            ObservableCollection<EmoEmotion> emotionList = new ObservableCollection<EmoEmotion>();
            var PropEmotion=scores.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var filtro = from P in PropEmotion
                         where P.PropertyType == typeof(float)
                         select P;

            EmotionEnum emotype = EmotionEnum.Undetermined;
            foreach (var prop in filtro)
            {
                if(!Enum.TryParse<EmotionEnum>(prop.Name, out emotype))
                { emotype = EmotionEnum.Undetermined; };


                EmoEmotion emoEmotion = new EmoEmotion()
                {
                    EmotionType = emotype,
                    score = (float)prop.GetValue(scores),
                    Face = face
                };
                emotionList.Add(emoEmotion);
                };

            return emotionList;
                
            }
        }
    }
