using FileUploadDemo.Models;
using System;
using System.IO;
using System.Web;

namespace FileUploadDemo.ExtensionMethods
{
    public static class HelperExtensionMethods
    {
        public static string GetFileName(this HttpPostedFileBase file)
        {
            return file.FileName;
        }

        public static string GetContentType(this HttpPostedFileBase file)
        {
            var contentType = file.ContentType;
            if (String.IsNullOrEmpty(contentType))
            {
                switch (GetFileExtension(file))
                {
                    case ".bmp":
                        contentType = "image/bmp";
                        break;
                    case ".gif":
                        contentType = "image/gif";
                        break;
                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                    case ".jfif":
                    case ".pjpeg":
                    case ".pjp":
                        contentType = "image/jpeg";
                        break;
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = "image/tiff";
                        break;
                    default:
                        break;
                }
            }
            return contentType;
        }

        public static byte[] GetBinaryData(this HttpPostedFileBase file)
        {
            var fileBinary = new byte[file.InputStream.Length];
            file.InputStream.Read(fileBinary, 0, fileBinary.Length);
            return fileBinary;
        }

        public static string GetFileExtension(this HttpPostedFileBase file)
        {
            return Path.GetExtension(GetFileName(file));
        }

        public static FileInformation GetFileInformation(this HttpPostedFileBase file)
        {
            return new FileInformation()
            {
                FileName = GetFileName(file),
                ContentType = GetContentType(file),
                FileExtension = GetFileExtension(file),
                BinaryData = GetBinaryData(file)
            };
        }
    }
}