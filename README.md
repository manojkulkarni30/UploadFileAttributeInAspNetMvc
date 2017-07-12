# Retrieve File Information Attribute In AspNetMvc

Simple RetrieveFileInformation file attribute to process the uploaded files and get the required information like binary information, filename, file extension and content type for each uploaded file as a parameter to an action method. It will help to reduce the code and get the required information easily so that we can easily save that information in database. 

```csharp
[HttpPost]
[RetrieveFileInformation]
public ActionResult Create([Bind(Include ="Title")]GalleryViewModel model,List<FileInformation> uploadedFiles)
{
    if(uploadedFiles.Count==0)
    {
        ModelState.AddModelError("", "Please upload a file");
    }
    if(ModelState.IsValid)
    {
            // Todo Save the files in database
            return RedirectToAction("Index");
        }
    }
    return View(model);
}
```
In above example, uploadedFiles parameter will have the information for all the uploaded files. 
