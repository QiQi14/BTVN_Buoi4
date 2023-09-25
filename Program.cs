using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
namespace BTVN_Buoi4
{
    class Program
    {
        private static List<User> listUser;

        static void Main(string[] args)
        {
            //Viết chương trình cho phép người dùng đăng nhập, đăng xuất và đăng ký tài khoản,
            //sau khi đăng ký thành công thì cho phép người dùng nhập / xem / xóa / sửa
            //thông tin học sinh với các thuộc tính: tên, lớp, nơi sinh, ngày sinh và điểm.
            //Lưu ý: Chương trình chỉ thoát khi người dùng chọn chức năng thoát
            listUser = new List<User>();
            simpleUI();
        }
        private static bool isLogin = false;
        private static void simpleUI()
        {
            Console.Clear();
            Console.WriteLine("Chuong trinh dang ky/dang nhap, moi ban chon chuc nang");
            if (isLogin)
            {
                Console.WriteLine("1. Xem danh sach hoc sinh");
                Console.WriteLine("2. Dang xuat");
                Console.WriteLine("3. Thoat");
                int option = 0;
                while (true)
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {

                        if (ManHinhDanhSachHS.ListStudent.Count > 0)
                        {
                            Console.WriteLine("Danh sach hoc sinh");
                            foreach (Student student in ManHinhDanhSachHS.ListStudent)
                            {
                                Console.Write(student.Ten + " - ");
                                Console.Write(student.Lop + " - ");
                                Console.Write(student.NoiSinh + " - ");
                                Console.Write(student.Namsinh + " - ");
                                Console.WriteLine(student.Grade);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Chua co hoc sinh nao");
                            Task.Delay(1000).Wait();
                            danhSachHocSinhUI();
                            break;
                        }

                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Ban Da Dang Xuat Thanh Cong");
                        Task.Delay(1000).Wait();
                        isLogin = false;
                        simpleUI();
                        break;
                    }
                }
            }
            else
            {
                string path = Environment.CurrentDirectory;
                string fileName = "accounts.txt";
                using (var sr = new StreamReader(path + "/" + fileName))
                {
                    Console.WriteLine("File da duoc doc");
                    //Console.WriteLine(sr.ReadToEnd());
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        // Xử lý dữ liệu từ từng dòng
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("1. Dang ky");
                Console.WriteLine("2. Dang nhap");
                Console.WriteLine("3. Thoat");
                int option = 0;
                while (true)
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        registerUI();
                        Console.WriteLine("Dang Ky Thanh Cong");
                        Task.Delay(1000).Wait();
                        simpleUI();
                    }
                    else if (option == 2)
                    {
                        string path1 = Environment.CurrentDirectory;
                        string fileName1 = "accounts.txt";
                        using (var sr = new StreamReader(path + "/" + fileName))
                        {

                            if (sr != null)
                            {
                                LoginUI();
                            }
                            else
                            {
                                Console.WriteLine("Chua co user nao trong he thong");
                                Task.Delay(1000).Wait();
                                simpleUI();
                            }
                        }

                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Ban Da Thoat Chuong Trinh Thanh Cong");
                        Task.Delay(1000).Wait();
                        break;
                    }
                }
            }
        }

        private static void danhSachHocSinhUI()
        {
            Console.Clear();
            int option = 0;
            Console.WriteLine("1. Them hoc sinh");
            Console.WriteLine("2. Xoa hoc sinh theo ten");
            Console.WriteLine("3. Sua hoc sinh theo ten");
            Console.WriteLine("4. Quay Lai");
            string path = Environment.CurrentDirectory;
            string fileName = "students.txt";
            using (var sr = new StreamReader(path + "/" + fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts[0] != null)
                    {
                        Console.WriteLine("Danh sach hoc sinh");
                        /*foreach (Student student in ManHinhDanhSachHS.ListStudent)
                        {
                            Console.Write(student.Ten + " - ");
                            Console.WriteLine(student.Grade);
                        }*/
                        Console.WriteLine(parts[0] + "-" + parts[1] + "-" + parts[2] + "-" + parts[3] + "-" + parts[4]);

                        //writeFileAsyncInfo();
                    }
                    else
                    {
                        Console.WriteLine("Chua co hoc sinh nao");
                    }

                }
            }


            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Danh sach hoc sinh");

                    Student student = inputStudent();
                    ManHinhDanhSachHS.addStudent(student);
                    writeFileAsyncInfo();
                    Task.Delay(1000).Wait();
                    readFileInfo();
                    danhSachHocSinhUI();

                }
                else if (option == 2)
                {
                    Console.WriteLine("Nhap ten hs muon xoa: ");
                    string ten = Console.ReadLine();

                    bool ketQua = ManHinhDanhSachHS.removeStudent(ten);
                    if (ketQua)
                    {
                        Console.WriteLine("Xoa thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("Khong ton tai hoc sinh nay");
                    }
                    Task.Delay(1000).Wait();
                    danhSachHocSinhUI();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Nhap ten hs muon sua: ");
                    string ten = Console.ReadLine();

                    string path1 = Environment.CurrentDirectory;
                    string fileName1 = "students.txt";
                    using (var sr = new StreamReader(path1 + "/" + fileName1))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');

                            if (ten == parts[0])
                            {
                                inputStudent();
                                Console.WriteLine("Sua thanh cong");
                                writeFileAsyncInfo();
                                danhSachHocSinhUI();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Khong ton tai hoc sinh nay");
                            }
                            Task.Delay(1000).Wait();
                            danhSachHocSinhUI();

                        }
                    }

                }
                else if (option == 4)
                {
                    simpleUI();
                    break;
                }
                else
                {
                    Console.WriteLine("Khong co tinh nang nay");
                    simpleUI();
                }
            }
        }

        private static Student inputStudent()
        {
            Student student = new Student();
            Console.WriteLine("Nhap ten hs: ");
            student.Ten = Console.ReadLine();

            Console.WriteLine("Nhap lop hs: ");
            student.Lop = Console.ReadLine();
            Console.WriteLine("Nhap noi sinh hs: ");
            student.NoiSinh = Console.ReadLine();
            Console.WriteLine("Nhap nam sinh hs: ");
            student.Namsinh = Console.ReadLine();
            Console.WriteLine("Nhap diem hs: ");

            while (true)
            {
                try
                {
                    student.Grade = (float)Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Diem phai la so");
                }
            }
            return student;
        }

        private static void registerUI()
        {
            User user = new User();
            Console.WriteLine("Vui long nhap username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Vuu long nhap password: ");
            user.Password = Console.ReadLine();
            listUser.Add(user); // 2 user vua nhap
            writeFileAsync();
        }

        private static void LoginUI()
        {
            Console.WriteLine("Danh Sach Tai Khoan");
            readFile();
            Console.WriteLine("Vui long nhap username: ");
            string n = Console.ReadLine();
            Console.WriteLine("Vui long nhap password: ");
            string pw = Console.ReadLine();
            string path = Environment.CurrentDirectory;
            string fileName = "accounts.txt";
            using (var sr = new StreamReader(path + "/" + fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts[0] == n && parts[1] == pw)
                    {
                        isLogin = true;
                        Console.WriteLine("Dang nhap thanh cong");
                        simpleUI();

                    }
                }
            }

            Console.WriteLine("Dang nhap that bai");
        }
        private static void readFile()
        {
            try
            {
                string path = Environment.CurrentDirectory;
                string fileName = "accounts.txt";
                using (var sr = new StreamReader(path + "/" + fileName))
                {
                    Console.WriteLine("File da duoc doc");
                    //Console.WriteLine(sr.ReadToEnd());
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static void readFileInfo()
        {
            try
            {
                string path = Environment.CurrentDirectory;
                string fileName = "students.txt";
                using (var sr = new StreamReader(path + "/" + fileName))
                {
                    Console.WriteLine("File da duoc doc");
                    //Console.WriteLine(sr.ReadToEnd());
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static async void writeFileAsync()
        {
            await Task.Run(() =>
            {
                string docPath = Environment.CurrentDirectory;
                Console.WriteLine(docPath);
                using (StreamWriter outputFile = new(Path.Combine(docPath, "accounts.txt")))
                {
                    foreach (User user in listUser)
                    {
                        outputFile.WriteLine($"{user.Username},{user.Password}");
                    }

                }
                Console.WriteLine("Complete");
            });
        }

        private static async void writeFileAsyncInfo()
        {
            await Task.Run(() =>
            {
                string docPath = Environment.CurrentDirectory;
                Console.WriteLine(docPath);
                using (StreamWriter outputFile = new(Path.Combine(docPath, "students.txt")))
                {
                    foreach (Student student in ManHinhDanhSachHS.ListStudent)
                    {
                        outputFile.WriteLine($"{student.Ten},{student.Lop},{student.NoiSinh},{student.Namsinh},{student.Grade}");

                    }

                }
                Console.WriteLine("Complete");
            });
        }

    }

    class User
    {
        private string username; //bb
        public string Username // =>aa
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public User() { }

        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getUsername()
        {
            return username; // => aa
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public string getPassword()
        {
            return password;
        }
    }

    class Student
    {
        private string ten;
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string lop;
        public string Lop
        {
            get { return lop; }
            set { lop = value; }
        }
        private string noiSinh;
        public string NoiSinh
        {
            get { return noiSinh; }
            set { noiSinh = value; }
        }
        private string namsinh;
        public string Namsinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }
        private double grade;
        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }

    static class ManHinhDanhSachHS
    {
        private static List<Student> listStudent = new List<Student>();
        public static List<Student> ListStudent
        {
            get { return listStudent; }
            set { listStudent = value; }
        }
        public static void addStudent(Student st)
        {
            listStudent.Add(st);
        }

        public static bool editStudent(string ten, Student student)
        {
            for (int i = 0; i < listStudent.Count; i++)
            {
                Student st = listStudent[i];
                if (ten == st.Ten)
                {
                    listStudent.RemoveAt(i);
                    listStudent.Insert(i, student);
                    return true;
                }
            }
            return false;
        }

        public static bool removeStudent(string ten)
        {
            foreach (Student st in listStudent)
            {
                if (ten == st.Ten)
                {
                    listStudent.Remove(st);
                    return true;
                }
            }
            return false;
        }
    }
}