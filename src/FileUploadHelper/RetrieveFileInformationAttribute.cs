using System.Collections.Generic;
using System.Web.Mvc;

namespace FileUploadHelper
{
    public class RetrieveFileInformationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var fileInformation = new List<FileInformation>();

            if (filterContext != null)
            {
                var path = filterContext.HttpContext.Server.MapPath("~/Content/uploads");
                var request = filterContext.HttpContext.Request;
                if (request != null && request.Files.Count > 0)
                {
                    foreach (string uploadedFile in request.Files)
                    {
                        if (request.Files[uploadedFile].ContentLength > 0)
                        {
                            var fileInfo = request.Files[uploadedFile].GetFileInformation();
                            fileInformation.Add(fileInfo);
                        }
                    }
                }
                filterContext.ActionParameters["uploadedFiles"] = fileInformation;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
