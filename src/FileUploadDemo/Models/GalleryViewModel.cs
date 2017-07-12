using System;
using System.ComponentModel.DataAnnotations;

namespace FileUploadDemo.Models
{
    public class GalleryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Title")]
        public string Title { get; set; }

        [UIHint("Picture")]
        [Display(Name = "Select Picture")]
        public int PictureId { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string PictureUrl { get; set; }

        public string FileName { get; set; }
    }
}