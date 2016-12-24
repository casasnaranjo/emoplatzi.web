using EmotionPlatzi.web.Models;
using EmotionPlatzi.web.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmotionPlatzi.web.Controllers
{
    public class EmoUploaderController : Controller
    {
        string ServerFolderPath;
        EmotionHelper emotionhelper;
        EmotionPlatziwebContext db;
        //Constructor de la clase
        public EmoUploaderController()
        {
            ServerFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            string Key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            emotionhelper = new EmotionHelper(Key);
            db = new EmotionPlatziwebContext();
        }

        // GET: EmoUploader
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            

            if (file!=null && file.ContentLength > 0)
            {
                string PictureFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var route = Server.MapPath(ServerFolderPath) + "/" + PictureFileName;
                file.SaveAs(route);
                Stream imagens = file.InputStream;
                var emopicture=await emotionhelper.DetectAndExtractFacesAsync(imagens);
                emopicture.name = PictureFileName;
                emopicture.path = ServerFolderPath + "/" + PictureFileName;
                db.EmoPictures.Add(emopicture);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "EmoPictures", new {Id=emopicture.id});
            }
            return View();
        }
    }
}