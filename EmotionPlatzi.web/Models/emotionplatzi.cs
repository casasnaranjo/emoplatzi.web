using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmotionPlatzi.web.Models
{
    public class emotionplatzi : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public emotionplatzi() : base("name=emotionplatzi")

        {
            Database.SetInitializer<emotionplatzi>(
                new DropCreateDatabaseIfModelChanges<emotionplatzi>()
                );
        }

        public System.Data.Entity.DbSet<EmoPlatzi.web.Models.EmoPicture> EmoPictures { get; set; }
        public System.Data.Entity.DbSet<EmoPlatzi.web.Models.EmoFace> EmoFaces { get; set; }
        public System.Data.Entity.DbSet<EmoPlatzi.web.Models.EmoEmotion> EmoEmotions { get; set; }

        public System.Data.Entity.DbSet<EmotionPlatzi.web.Models.Home> Homes { get; set; }
    }
}
