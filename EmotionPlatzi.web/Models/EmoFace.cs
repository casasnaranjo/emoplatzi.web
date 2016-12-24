using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmoPlatzi.web.Models
{
   // [DataContract(IsReference = true)]
    public class EmoFace
    {
        //[DataMember]
        public int id { get; set; }
       // [DataMember]
        public int EmopictureId { get; set; }
        //[DataMember]
        public int x { get; set; }
        //[DataMember]
        public int y { get; set; }
        //[DataMember]

        public int width {get; set;}
        //[DataMember]
        public int heigh { get; set;}
        

        public virtual EmoPicture Picture { get; set; }
      
        public virtual ObservableCollection<EmoEmotion> Emotions { get; set; }

    }
}