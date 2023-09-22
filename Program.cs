
namespace BTVN_Buoi4 {
    class Program
    {
        private static List<User> users = new List<User>();//tao list luu tru user
        private static User currentUser = null;//tao trang thai hien tai cua nguoi dung

        static void Main(string[] args)
        {
            int option = 0;
            simpleUI();
            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());

                if (currentUser == null)//trang thai nguoi dung = null thi chi hien thi dang ky, dang nhap, thoat
                {
                    if (option == 1)
                    {
                        Register();
                    }
                    else if (option == 2)
                    {
                        Login();
                    }
                    else if (option == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lua chon khong hop le, vui long thu lai.");
                        simpleUI();
                    }
                }
                else//trang thai nguoi dung da dang nhap thi hien thi cac muc them, sua, xoa thong tin
                {
                    if (option == 4)
                    {
                        Logout();
                    }
                    else if (option == 5)
                    {
                        AddUserInfo();
                    }
                    else if (option == 6)
                    {
                        ViewUserInfo();
                    }
                    else if (option == 7)
                    {
                        EditUserInfo();
                    }
                    else if (option == 8)
                    {
                        DeleteUserInfo();
                    }
                    else if (option == 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lua chon khong hop le, vui long thu lai.");
                        simpleUI();
                    }
                }
            }
        }

        private static void simpleUI()
        {
            Console.WriteLine("Chao mung den voi ung dung quan ly thong tin!");

            if (currentUser == null)
            {
                Console.WriteLine("1. Dang Ky");
                Console.WriteLine("2. Dang Nhap");
                Console.WriteLine("3. Thoat");
            }
            else
            {
                Console.WriteLine($"Xin Chao, {currentUser.Username}!");
                Console.WriteLine("4. Dang Xuat");
                Console.WriteLine("5. Nhap thong tin nguoi dung");
                Console.WriteLine("6. Xem thong tin nguoi dung");
                Console.WriteLine("7. Sua thong tin nguoi dung");
                Console.WriteLine("8. Xoa thong tin nguoi dung");
                Console.WriteLine("9. Thoat");
            }
        }

        static void Register()
        {
            Console.Write("Nhap tai khoan: ");
            string username = Console.ReadLine();
            Console.Write("Nhap mat khau: ");
            string password = Console.ReadLine();

            User newUser = new User(username, password);
            users.Add(newUser);

            Console.WriteLine("Dang ky thanh cong!");
            simpleUI();
        }

        static void Login()
        {
            Console.Write("Nhap tai khoan: ");
            string username = Console.ReadLine();
            Console.Write("Nhap mat khau: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    currentUser = user;
                    Console.WriteLine("Dang nhap thanh cong!");
                    simpleUI();
                    return;
                }
            }

            Console.WriteLine("Tai khoan hoac Mat khau khong dung.");
            simpleUI();
        }

        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Dang xuat thanh cong!");
            simpleUI();
        }

        static void AddUserInfo()
        {
            Console.WriteLine("Nhap thong tin nguoi dung:");

            Console.Write("Ten: ");
            string name = Console.ReadLine();
            Console.Write("Lop: ");
            string userClass = Console.ReadLine();
            Console.Write("Noi Sinh: ");
            string placeOfBirth = Console.ReadLine();
            Console.Write("Ngay sinh (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Diem: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            currentUser.Information.Name = name;
            currentUser.Information.Class = userClass;
            currentUser.Information.PlaceOfBirth = placeOfBirth;
            currentUser.Information.DateOfBirth = dateOfBirth;
            currentUser.Information.Grade = grade;

            Console.WriteLine("Thong tin nguoi dung da duoc cap nhat.");
            simpleUI();
        }

        static void ViewUserInfo()
        {
            Console.WriteLine("Thong tin nguoi dung:");

            Console.WriteLine($"Ten: {currentUser.Information.Name}");
            Console.WriteLine($"Lop: {currentUser.Information.Class}");
            Console.WriteLine($"Noi sinh: {currentUser.Information.PlaceOfBirth}");
            Console.WriteLine($"Ngay sinh: {currentUser.Information.DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Diem: {currentUser.Information.Grade}");
            simpleUI();
        }

        static void EditUserInfo()
        {
            Console.WriteLine("Sua thong tin nguoi dung:");

            Console.Write("Ten moi: ");
            string name = Console.ReadLine();
            Console.Write("Lop moi: ");
            string userClass = Console.ReadLine();
            Console.Write("Noi sinh moi: ");
            string placeOfBirth = Console.ReadLine();
            Console.Write("Ngay sinh moi (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Diem moi: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            currentUser.Information.Name = name;
            currentUser.Information.Class = userClass;
            currentUser.Information.PlaceOfBirth = placeOfBirth;
            currentUser.Information.DateOfBirth = dateOfBirth;
            currentUser.Information.Grade = grade;

            Console.WriteLine("Thong tin nguoi dung da duoc cap nhat.");
            simpleUI();
        }

        static void DeleteUserInfo()
        {
            Console.Write("Ban co chac muon xoa thong tin nguoi dung? (Y/N): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                currentUser.Information.ClearInfo();
                Console.WriteLine("Thong tin nguoi dung da duoc xoa.");
                simpleUI();
            }
        }
    }

    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class User : Account
    {
        public UserInfo Information { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Information = new UserInfo();
        }
    }

    class UserInfo
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Grade { get; set; }

        public void ClearInfo()
        {
            Name = null;
            Class = null;
            PlaceOfBirth = null;
            DateOfBirth = DateTime.MinValue;
            Grade = 0;
        }
    }
}