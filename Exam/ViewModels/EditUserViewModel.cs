using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Display(Name = "Autobiography")]
        public string Autobiography { get; set; }
    }
}
