using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImageUploadApp.Models
{
    [Table("Persons")]
    public class PersonModels
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonMobile { get; set; }
        public string PersonPhoto { get; set; }
    }
}