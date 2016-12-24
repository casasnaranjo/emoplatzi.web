using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmoPlatzi.web.Models
{
    //[DataContract(IsReference = true)]
    public class EmoEmotion
    {
        //[DataMember]
        public int id { get; set; }
        //[DataMember]
        public int EmoFaceId { get; set; }
        //[DataMember]
        [Required]
        [Range(0, 1, ErrorMessage = "Por Favor ingrese un numero entre 0 y 1")]
        public float score{ get; set; }
        //[DataMember]
        public EmotionEnum EmotionType{get;set; }
        
        public virtual EmoFace Face { get; set; }

    }
}