using System;
using System.ComponentModel.DataAnnotations;

namespace EmreCrm.Model.Model
{
    public class UserModel
    {
        public UserModel()
        {
            this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Ýsim")]
        [Required(ErrorMessage = "Bu alaný doldurmanýz gerekli")]
        public string Name { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Soy Ýsim")]
        [Required(ErrorMessage = "Bu alaný doldurmanýz gerekli")]
        public string Surname { get; set; }

        [MaxLength(1024)]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        [Required(ErrorMessage = "Bu alaný doldurmanýz gerekli")]
        public string Email { get; set; }

        [MaxLength(250)]
        [Display(Name = "Telefon Numarasý")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Bu alaný doldurmanýz gerekli")]
        public DateTime CreatedDate { get; set; }
    }
}
