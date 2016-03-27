using FileUploadDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FileUploadDemo.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            var context = new UploadFileDemoEntities();
            var model = context.Galleries
                .Include("Picture")
                .Select(c => new GalleryViewModel
                {
                    Id=c.Id,
                    Title=c.Title,
                    PictureId=c.PictureId,
                    DateCreated=c.DateCreated,
                    DateUpdated=c.DateUpdated,
                    FileName=c.Picture.FileName
                }).ToList();
            model.ForEach(c =>
            {
                c.PictureUrl = Url.Content("~/Content/uploads/" + c.FileName);
            });

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new GalleryViewModel());
        }

        [HttpPost]
        [UploadFile]
        public ActionResult Create([Bind(Include ="Title")]GalleryViewModel model,List<FileInformation> uploadedFiles)
        {
            if(uploadedFiles.Count==0)
            {
                ModelState.AddModelError("", "Please upload a file");
            }
            if(ModelState.IsValid)
            {
                var file = uploadedFiles.FirstOrDefault();
                if (file != null)
                {
                    var context = new UploadFileDemoEntities();
                    var picture = new Picture()
                    {
                        FileName = file.FileName,
                        BinaryData=file.BinaryData,
                        MimeType=file.ContentType
                    };

                    context.Pictures.Add(picture);

                    var gallery = new Gallery()
                    {
                        Title = model.Title,
                        PictureId = picture.Id,
                        IsActive = true,
                        DateCreated = DateTime.UtcNow,
                        DateUpdated = DateTime.UtcNow

                    };
                    context.Galleries.Add(gallery);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}