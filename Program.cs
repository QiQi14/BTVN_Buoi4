using System.Runtime.CompilerServices;

namespace BTVN_04
{
    class Program
    {
        private static List<User> list_users = new List<User>();
        private static List<Student> list_student = new List<Student>();

        public static void Main(string[] args)
        {
            int option = 0;

            StartUI();

            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    LogInUI();
                }
                else if (option == 2)
                {
                    RegisterUI();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Khong co chuc nang nay, ban hay nhap lai!!!");
                }
            }
        }

        private static void LogInUI() 
        {
            Console.WriteLine("Moi ban dang nhap tai khoan");
            Console.WriteLine("Nhap username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Nhap password: ");
            string password = Console.ReadLine();
            foreach (User user in list_users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine("Ban da dang nhap thanh cong");
                    break;
                }
                else
                {
                    Console.WriteLine("User nay khong ton tai!!!");
                }
            }
            StudentUI();
        }

        private static void RegisterUI()
        {
            Console.WriteLine("Moi ban dang ky tai khoan");
            Console.WriteLine("Nhap username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Nhap password: ");
            string password = Console.ReadLine();
            if (list_users.Count > 0)
            {
                foreach (User user in list_users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        Console.WriteLine("User da ton tai!!!");
                        break;
                    }
                    else
                    {
                        User new_user = new User(username, password);
                        list_users.Add(new_user);

                    }
                }
            }
            else {
                User new_user = new User(username, password);
                list_users.Add(new_user);
            }
            StartUI();
        }
        private static void StudentUI()
        {
            int option = 0;

            OptionStudentUI();

            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    InputStudentUI();
                }
                else if (option == 2)
                {
                    ViewStudentInformation();
                }
                else if (option == 3)
                {
                    DeleteStudent();
                }
                else if (option == 4)
                {
                    EditStudent();
                }
                else if (option == 5)
                {
                    StartUI();
                }
                else
                {
                    Console.WriteLine("Khong co chuc nang nay, ban hay nhap lai!!!");
                }
            }
        }
        private static void StartUI()
        {
            Console.WriteLine("Moi ban chon chuc nang mong muon: ");
            Console.WriteLine("1. Dang nhap");
            Console.WriteLine("2. Dang ky");
            Console.WriteLine("3. Dang xuat");
        }

        private static void InputStudentUI()
        {
            Console.WriteLine("Nhap ten hoc sinh: ");
            string ten_hs = Console.ReadLine();
            Console.WriteLine("Nhap lop hoc sinh: ");
            string lop = Console.ReadLine();
            Console.WriteLine("Nhap noi sinh hoc sinh: ");
            string noi_sinh = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh: ");
            string ngay_sinh = Console.ReadLine();
            Console.WriteLine("Nhap diem: ");
            int diem = Convert.ToInt16(Console.ReadLine());
            Student new_student = new Student(ten_hs, lop, noi_sinh, ngay_sinh, diem);
            list_student.Add(new_student);

            OptionStudentUI();
        }

        private static void ViewStudentInformation()
        {
            foreach (Student student in list_student)
            {
                Console.WriteLine(student.Ten_hs);
                Console.WriteLine(student.Lop);
                Console.WriteLine(student.Noi_sinh);
                Console.WriteLine(student.Ngay_sinh);
                Console.WriteLine(student.Diem);
                Console.WriteLine();
            }
            OptionStudentUI();
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("Nhap ten hoc sinh muon xoa: ");
            string student_name = Console.ReadLine();
            foreach (Student student in list_student)
            {
                if (student.Ten_hs == student_name)
                {
                    list_student.Remove(student);
                    break;
                }
            }
            Console.WriteLine("Da xoa hoc sinh thanh cong!!!");
            OptionStudentUI();
        }
        private static void EditStudent() 
        {
            Console.WriteLine("Nhap ten hoc sinh muon sua: ");
            string student_name = Console.ReadLine();
            foreach (Student student in list_student)
            {
                if (student.Ten_hs == student_name)
                {
                    Console.WriteLine("Nhap ten hoc sinh: ");
                    string ten_hs = Console.ReadLine();
                    student.Ten_hs = ten_hs;
                    Console.WriteLine("Nhap lop hoc sinh: ");
                    string lop = Console.ReadLine();
                    student.Lop = lop;
                    Console.WriteLine("Nhap noi sinh hoc sinh: ");
                    string noi_sinh = Console.ReadLine();
                    student.Noi_sinh = noi_sinh;
                    Console.WriteLine("Nhap ngay sinh: ");
                    string ngay_sinh = Console.ReadLine();
                    student.Ngay_sinh = ngay_sinh;
                    Console.WriteLine("Nhap diem: ");
                    int diem = Convert.ToInt16(Console.ReadLine());
                    student.Diem = diem;
                    break;
                }
            }

            Console.WriteLine("Da update thong tin hoc sinh thanh cong!!!");
            OptionStudentUI();
        }
        private static void OptionStudentUI()
        {
            Console.WriteLine("Ban co muon thuc hien chuc nang: ");
            Console.WriteLine("1. Nhap thong tin hoc sinh");
            Console.WriteLine("2. Xem thong tin hoc sinh");
            Console.WriteLine("3. Xoa thong tin hoc sinh");
            Console.WriteLine("4. Sua thong tin hoc sinh");
            Console.WriteLine("5. Quay lai");
        }
        class User
        {
            private string username;
            private string password;



            public string Username { get => username; set => username = value; }
            public string Password { get => password; set => password = value; }

            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
            }


        }

        class Student
        {
            private string ten_hs;
            private string lop;
            private string noi_sinh;
            private string ngay_sinh;
            private int diem;

            public string Ten_hs { get => ten_hs; set => ten_hs = value; }
            public string Lop { get => lop; set => lop = value; }
            public string Noi_sinh { get => noi_sinh; set => noi_sinh = value; }
            public string Ngay_sinh { get => ngay_sinh; set => ngay_sinh = value; }
            public int Diem { get => diem; set => diem = value; }

            public Student(string ten_hs, string lop, string noi_sinh, string ngay_sinh, int diem)
            {
                this.ten_hs = ten_hs;
                this.lop = lop;
                this.noi_sinh = noi_sinh;
                this.ngay_sinh = ngay_sinh;
                this.diem = diem;
            }
        }

    }
}