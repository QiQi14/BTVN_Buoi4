using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BTVN_04
{
    class Program
    {
        private static List<User> list_users = new List<User>();
        private static List<Student> list_student = new List<Student>();

        public static async void writeFileAsync()
        {
            await Task.Run(() =>
            {
                string docPath = Environment.CurrentDirectory;
                using (StreamWriter outputFile = new(Path.Combine(docPath, "accounts.txt")))
                {
                    foreach (var user in list_users)
                    {
                        outputFile.WriteLineAsync(user.Username);
                        outputFile.WriteLineAsync(user.Password);
                    }
                }

                using (StreamWriter outputFile = new(Path.Combine(docPath, "students.txt")))
                {
                    foreach (var student in list_student)
                    {
                        outputFile.WriteLineAsync(student.Ten_hs);
                        outputFile.WriteLineAsync(student.Lop);
                        outputFile.WriteLineAsync(student.Noi_sinh);
                        outputFile.WriteLineAsync(student.Ngay_sinh);
                        outputFile.WriteLine(student.Diem);
                    }
                }
            });
        }
        public static List<string> readFile(string fileName)
        {
            List<string> list_lines = new List<string>();
            try
            {
                string path = Environment.CurrentDirectory;
                using (var sr = new StreamReader(path + "/" + fileName))

                {
                    while (!sr.EndOfStream)
                    {
                        //Console.WriteLine(sr.ReadLine());
                        list_lines.Add(sr.ReadLine());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return list_lines;
        }

        public static void Main(string[] args)
        {
            List<string> lines_file_users = new List<string>();
            lines_file_users  = readFile("accounts.txt");

            if(lines_file_users.Count > 0)
            {
                for (int i = 0; i < lines_file_users.Count; i = i + 2)
                {
                    string username = lines_file_users[i];
                    string passworld = lines_file_users[i + 1];
                    User old_user = new User(username, passworld);
                    list_users.Add(old_user);
                }
            }

            List<string> lines_file_student = new List<string>();
            lines_file_student = readFile("students.txt");

            if(lines_file_student.Count > 0)
            {
                for (int i = 0; i < lines_file_student.Count; i = i + 5)
                {
                    string ten_hs = lines_file_student[i];
                    string lop = lines_file_student[i + 1];
                    string noi_sinh = lines_file_student[i + 2];
                    string ngay_sinh = lines_file_student[i + 3];
                    int diem = Convert.ToInt16(lines_file_student[i + 4]);


                    Student old_student = new Student(ten_hs, lop, noi_sinh, ngay_sinh, diem);
                    list_student.Add(old_student);
                }
            }

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
            bool Correct_User = false;
            foreach (User user in list_users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Correct_User = true;
                    Console.WriteLine("Ban da dang nhap thanh cong");
                    StudentUI();
                    break;
                }
            }
            if (Correct_User == false)
            {
                Console.WriteLine("Dang nhap khong thanh cong!!!");
                StartUI();
            }
            
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
                        Console.WriteLine("Dang ky thanh cong!!!");
                        User new_user = new User(username, password);
                        list_users.Add(new_user);
                        writeFileAsync();
                        break;
                    }
                }
            }
            else {
                Console.WriteLine("Dang ky thanh cong!!!");
                User new_user = new User(username, password);
                list_users.Add(new_user);
                writeFileAsync();
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
                    break;
                }
                else
                {
                    Console.WriteLine("Khong co chuc nang nay, ban hay nhap lai!!!");
                }
            }
        }
        private static void StartUI()
        {
            Task.Delay(1000).Wait();
            Console.Clear();
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
            writeFileAsync();
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
            Task.Delay(1000).Wait();
            Console.Clear();
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