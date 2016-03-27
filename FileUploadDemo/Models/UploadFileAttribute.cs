using System.Collections.Generic;
using System.Web.Mvc;
using FileUploadDemo.ExtensionMethods;
using System.IO;

namespace FileUploadDemo.Models
{
    public class UploadFileAttribute: ActionFilterAttribute
    {
        private readonly bool _saveToDisk;

        public UploadFileAttribute(bool saveToDisk=true)
        {
            this._saveToDisk = saveToDisk;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var fileInformation = new List<FileInformation>();

            if (filterContext != null)
            {
                var path = filterContext.HttpContext.Server.MapPath("~/Content/uploads");
                var request = filterContext.HttpContext.Request;
                if (request != null && request.Files.Count>0)
                {
                    foreach (string uploadedFile in request.Files)
                    {
                        if (request.Files[uploadedFile].ContentLength > 0)
                        {
                            var fileInfo = request.Files[uploadedFile].GetFileInformation();
                            fileInformation.Add(fileInfo);
                            if(_saveToDisk)
                            {
                                request.Files[uploadedFile].SaveAs(Path.Combine(path, fileInfo.FileName));
                            }
                        }
                    }
                }
                filterContext.ActionParameters["uploadedFiles"] = fileInformation;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}