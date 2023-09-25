using Program;
using Screen;

namespace User {
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginScreen : IUserAction {
        public bool login(string username, string password)
        {
            foreach (UserModel u in AppData.listUser)
            {
                if (u.Username == username && u.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool register(UserModel user)
        {
            foreach(UserModel u in AppData.listUser)
            {
                if (u.Username == user.Username)
                {
                    return false;
                }
            }
            AppData.listUser.Add(user);
            return true;
        }

        public void render()
        {
            Console.WriteLine("Chuong trinh quan ly hoc vien");
            Console.WriteLine("1.Dang ky");
            Console.WriteLine("2.Dang nhap");
        }

        public bool renderRegisterForm()
        {
            Console.WriteLine();
            Console.WriteLine("Vui long nhap username: ");
            UserModel newUser = new UserModel();
            newUser.Username = Console.ReadLine();

            Console.WriteLine("Vui long nhap password: ");
            newUser.Password = Console.ReadLine();
            return register(newUser);
        }

        public bool renderLoginForm()
        {
            Console.WriteLine();
            Console.WriteLine("Vui long nhap username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Vui long nhap password: ");
            string password = Console.ReadLine();
            return login(username, password);
        }

        public ScreenName selected(int option)
        {
            switch (option)
            {
                case 1: 
                    {
                        bool result = renderRegisterForm();
                        if (result)
                        {
                            Console.WriteLine("Dang ky thanh cong");
                        } else
                        {
                            Console.WriteLine("User da ton tai");
                        }
                        Task.Delay(500).Wait();
                        return ScreenName.LOGIN; 
                    }
                case 2:
                    {
                        bool result = renderLoginForm();
                        if (result)
                        {
                            Console.WriteLine("Dang nhap thanh cong");
                            Task.Delay(500).Wait();
                            return ScreenName.ONBOARD;
                        }
                        else
                        {
                            Console.WriteLine("Sai tai khoan hoac mat khau");
                            Task.Delay(500).Wait();
                            return ScreenName.LOGIN;
                        }
                    }
                default: 
                    {
                        Console.WriteLine("Khong co tinh nang nay");
                        Task.Delay(500).Wait();
                        return ScreenName.LOGIN;
                    }
            }
        }
    }

    public class OnboardScreen : IScreenAction {
        public void render()
        {
            string name = AppData.user == null ? "" : AppData.user.Username;
            Console.WriteLine("Xin chao {0}, vui long chon chuc nang: ", name);
            Console.WriteLine("1. Xem danh sach hoc vien");
            Console.WriteLine("2. Dang xuat");
        }

        public ScreenName selected(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        return ScreenName.STUDENT;
                    }
                case 2:
                    {
                        AppData.user = null;
                        return ScreenName.LOGIN;
                    }
                default:
                    {
                        Console.WriteLine("Khong co tinh nang nay");
                        return ScreenName.ONBOARD;
                    }
            }
        }
    }

    public interface IUserAction : IScreenAction
    {
        bool register(UserModel user);
        bool login(string username, string password);
    }
}
