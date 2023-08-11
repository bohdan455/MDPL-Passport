using MDPL_Passport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPL_Passport.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> users = new List<User>
        {
            new User { Name = "Джейсон Смокінг", Position = "Президент МДПЛ", Login = "jason_smoking", Password = "password1" },
            new User { Name = "Шінджі Ікарі", Position = "Віце-президент МДПЛ", Login = "shinji_ikari", Password = "password2" },
            new User { Name = "Стулиписок Шморгло", Position = "Міністр Культури МДПЛ", Login = "stulypysok_shmorglo", Password = "password3" },
            new User { Name = "Антон Мельник", Position = "Міністр Оброни МДПЛ", Login = "anton_melnik", Password = "password4" },
            new User { Name = "Вадим Анімешник", Position = "Міністр Інформаційних Технологій МДПЛ", Login = "vadim_animashnyk", Password = "password5" },
            new User { Name = "Джо Байден", Position = "Міністр Економіки МДПЛ", Login = "joe_biden", Password = "password6" },
            new User { Name = "Юзеф Волинський", Position = "Журналіст", Login = "yuzev_volynsky", Password = "password7" },
            new User { Name = "Ангел Соняшник Сонячний", Position = "Міністр Охорони Здоров’я МДПЛ", Login = "angel_sonyashnik", Password = "password8" },
            new User { Name = "Тарас Коновалець", Position = "Головнокомандувач ЗС МДПЛ", Login = "taras_konoval", Password = "password9" },
            new User { Name = "Джугашвілі Макар Сталін", Position = "Дармоїд і Куколд", Login = "djuga_stalin", Password = "password10" },
            new User { Name = "Бомбив Віталій", Position = "Командир Національної гвардії МДПЛ", Login = "bombiv_vitaliy", Password = "password11" },
            new User { Name = "Іоанн Цойх", Position = "Колектор", Login = "ioann_tsoikh", Password = "password12" },
            new User { Name = "Максим Марцинкевич", Position = "Адвокат", Login = "max_marcinkevich", Password = "password13" },
            new User { Name = "Владислав Мілкочленний", Position = "Прокурор", Login = "vlad_milkochlenny", Password = "password14" }
        };

        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(Preferences.Default.Get("IsAuthenticated", false));
        }


        public Task<bool> TryLogin(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Login == username && u.Password == password);

            if (user == null)
            {
                return Task.FromResult(false);
            }

            Preferences.Default.Set("Name", user.Name);

            Preferences.Default.Set("Position", user.Position);

            Preferences.Default.Set("IsAuthenticated", true);

            return Task.FromResult(true);
        }

        public Task Logout()
        {
            Preferences.Default.Clear("Name");

            Preferences.Default.Clear("Position");

            Preferences.Default.Clear("IsAuthenticated");

            return Task.CompletedTask;
        }
    }
}
