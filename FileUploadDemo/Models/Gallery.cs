//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileUploadDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PictureId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }
    
        public virtual Picture Picture { get; set; }
    }
}
