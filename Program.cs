
using System.Runtime.CompilerServices;

namespace BTVN_Buoi4 {
    class Program
    {

        private static List<User> listUser;
        private static int currentScreen = 0;
        static void Main(string[] args) {
            //Viết chương trình cho phép người dùng đăng nhập, đăng xuất và đăng ký tài khoản,
            //sau khi đăng ký thành công thì cho phép người dùng nhập / xem / xóa / sửa
            //thông tin học sinh với các thuộc tính: tên, lớp, nơi sinh, ngày sinh và điểm.
            //Lưu ý: Chương trình chỉ thoát khi người dùng chọn chức năng thoát
            listUser = new List<User>();
            int option = 0;

            simpleUI();

            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    if (currentScreen == 0)
                    {
                        registerUI();
                        Console.WriteLine("Dang ky thanh cong");
                        Task.Delay(1000).Wait();
                        simpleUI();
                    } else if (currentScreen == 1) {
                        danhSachHocSinhUI();
                    } else if (currentScreen == 2)
                    {
                        Student student = inputStudent();
                        ManHinhDanhSachHS.addStudent(student);
                        danhSachHocSinhUI();
                    }
                }
                else if (option == 2)
                {
                    if (currentScreen == 0)
                    {
                        if (listUser.Count > 0)
                        {
                            LoginUI();
                        }
                        else
                        {
                            Console.WriteLine("Chua co user nao trong he thong");
                        }
                        simpleUI();
                    } else if (currentScreen == 2)
                    {
                        Console.WriteLine("Nhap ten hs muon xoa: ");
                        string ten = Console.ReadLine();

                        bool ketQua = ManHinhDanhSachHS.removeStudent(ten);
                        if (ketQua)
                        {
                            Console.WriteLine("Xoa thanh cong");
                        } else
                        {
                            Console.WriteLine("Khong ton tai hoc sinh nay");
                        }

                        Task.Delay(1000).Wait();
                        danhSachHocSinhUI();
                    }
                }
                else if (option == 3)
                {
                    if (currentScreen == 0)
                    break;

                    Console.WriteLine("Nhap ten hs muon sua: ");
                    string ten = Console.ReadLine();
                    Student student = inputStudent();

                    bool ketQua = ManHinhDanhSachHS.editStudent(ten, student);
                    if (ketQua)
                    {
                        Console.WriteLine("Sua thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("Khong ton tai hoc sinh nay");
                    }

                    Task.Delay(1000).Wait();
                    danhSachHocSinhUI();
                }
                else
                {
                    Console.WriteLine("Khong co tinh nang nay");
                    simpleUI();
                }
            }
        }

        private static bool isLogin = false;
        private static void simpleUI()
        {
            currentScreen = 0;
            Console.Clear();
            Console.WriteLine("Chuong trinh dang ky/dang nhap, moi ban chon chuc nang");

            if (isLogin)
            {
                currentScreen = 1;
                Console.WriteLine("1. Xem danh sach hoc sinh");
                Console.WriteLine("2. Dang xuat");
                Console.WriteLine("3. Thoat");
            } else
            {
                Console.WriteLine("1. Dang ky");
                Console.WriteLine("2. Dang nhap");
                Console.WriteLine("3. Thoat");
            }
        }

        private static void danhSachHocSinhUI()
        {
            currentScreen = 2;
            Console.Clear();

            Console.WriteLine("1. Them hoc sinh");
            Console.WriteLine("2. Xoa hoc sinh theo ten");
            Console.WriteLine("3. Sua hoc sinh theo ten");
            if (ManHinhDanhSachHS.ListStudent.Count > 0)
            {
                Console.WriteLine("Danh sach hoc sinh");
                foreach (Student student in ManHinhDanhSachHS.ListStudent)
                {
                    Console.Write(student.Ten + " - ");
                    Console.WriteLine(student.Grade);
                }
            } else
            {
                Console.WriteLine("Chua co hoc sinh nao");
            }
        }

        private static Student inputStudent()
        {
            Student student = new Student();
            Console.WriteLine("Nhap ten hs: ");
            student.Ten = Console.ReadLine();
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
        }

        private static void LoginUI()
        {
            Console.WriteLine("Vui long nhap username: ");
            string n = Console.ReadLine();

            Console.WriteLine("Vui long nhap password: ");
            string pw = Console.ReadLine();

            foreach (User user in listUser)
            {
                if (string.Equals(n, user.Username) && string.Equals(pw, user.Password))
                {
                    isLogin = true;
                    Console.WriteLine("Dang nhap thanh cong");
                    return;
                }
            }
            Console.WriteLine("Dang nhap that bai");
        }
    }

    class User {
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
        private string dob;
        public string DoB 
        {
            get { return dob; }
            set { dob = value; }
        }
        private float grade;
        public float Grade 
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