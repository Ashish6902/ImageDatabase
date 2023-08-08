using ImageDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageDatabase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBcontext dbcontext = new DBcontext();
            List<ImageModel> obj = dbcontext.GetData();
            return View(obj);
        }
        public ActionResult UploadImage(HttpPostedFileBase imageFile)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                byte[] imageBytes;
                using (BinaryReader reader = new BinaryReader(imageFile.InputStream))
                {
                    imageBytes = reader.ReadBytes((int)imageFile.InputStream.Length);
                }
                DBcontext dbcontext = new DBcontext();
                ImageModel imgmod = new ImageModel();
                imgmod.ImageData = imageBytes;
                dbcontext.createData(imgmod);
                return View();
            }

            return RedirectToAction("Index");
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}