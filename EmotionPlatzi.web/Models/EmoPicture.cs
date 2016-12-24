using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmoPlatzi.web.Models
{
    //[DataContract(IsReference = true)]
    public class EmoPicture
    {
        //[DataMember]
        public int id { get; set; }
        //[DataMember]
        public string name { get; set; }
        //[DataMember]
        public string path { get; set; }
        

        public virtual ObservableCollection<EmoFace> Faces { get; set; }
    }
}