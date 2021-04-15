using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels
{
    public class AddUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Autobiography")]
        public string Autobiography { get; set; }
    }
}
