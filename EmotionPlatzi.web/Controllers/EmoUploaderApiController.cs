using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Http.Description;
using EmotionPlatzi.web.Util;
using EmotionPlatzi.web.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Drawing;

namespace EmotionPlatzi.web.Controllers
{
    public class EmoUploaderApiController : ApiController
    {
        string ServerFolderPath;
        EmotionHelper emotionhelper;
        emotionplatzi db;

        public EmoUploaderApiController()
        {
            ServerFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            string Key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            emotionhelper = new EmotionHelper(Key);
            db = new emotionplatzi();
        }
        [HttpPost]
        //POST:api/EmoUploaderAPI
        public async Task<IHttpActionResult> PostEmoUploader()
        {
            
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (file != null && file.Headers.ContentLength > 0)
            //{
         
               // var route = (HttpContext.Current.Server.MapPath(ServerFolderPath)).Replace("\\api","") + "/" + PictureFileName;
            var httprequest = HttpContext.Current.Request;
            foreach (string Archivo in httprequest.Files)
            {
                string PictureFileName = Guid.NewGuid().ToString() + ".jpg";
                var postedFile = httprequest.Files[Archivo];
                var route = HttpContext.Current.Server.MapPath("~/" +ServerFolderPath+"/"+ PictureFileName);
                Stream imagens = postedFile.InputStream;
                postedFile.SaveAs(route);
                var emopicture = await emotionhelper.DetectAndExtractFacesAsync(imagens);
                emopicture.name = PictureFileName;
                emopicture.path = ServerFolderPath + "/" + PictureFileName;
                db.EmoPictures.Add(emopicture);
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = emopicture.id }, emopicture);
            }


            //}
            return Ok();

        }

    }
}
