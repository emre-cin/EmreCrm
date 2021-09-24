using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmreCrm.Model.DbEntity
{
    [Table("User")]
    public class User : BaseEntity
    {
        public User()
        {
            this.CreatedDate = DateTime.Now;
        }

        [MaxLength(1024)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [MaxLength(1024)]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [MaxLength(1024)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CreatedDate { get; set; }

    }
}
