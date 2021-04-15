using System.Linq;

namespace Exam.Models
{
    public static class Seed
    {
        public static void Initialize(UserContextDB context)
        {
            if (!context.Users.Any())
            {
                context.AddRange(new User
                {
                    Name = "Vladimir",
                    Surname = "Rud",
                    Patronymic = "Olegovich",
                    Autobiography = "401 Group, Petro Mohyla Black Sea National University"
                });
                context.SaveChanges();
            }
        }
    }
}
