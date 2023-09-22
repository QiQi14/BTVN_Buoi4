using System;
using System.Net;
using System.Text.RegularExpressions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static List<User> users;

        static List<Info> infos;

        static void Main(string[] args)
        {
            users = new List<User>();
            //
            infos = new List<Info>();
            //
            OptionUI();
        }

        private static void OptionUIInfo()
        {
            Console.WriteLine("1. Nhap Thong Tin ");
            Console.WriteLine("2. Xem Thong Tin ");
            Console.WriteLine("3. Xoa Thong Tin ");
            Console.WriteLine("4. Sua Thong Tin ");
            Console.WriteLine("5. Dang Xuat ");
            int chon = 0;
            do
            {
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        NhapThongTin();
                        break;
                    case 2:
                        XemThongTin();
                        break;
                    case 3:
                        XoaThongTin();
                        break;
                    case 4:
                        SuaThongTin();
                        break;
                    case 5:
                        QuayLai();
                        break;
                    default:
                        Console.WriteLine("Not default");
                        break;
                }
            } while (chon != 5);
        }

        private static void SuaThongTin()
        {
            Console.WriteLine("Nhap Ten Nguoi Dung Can Sua ");
            string ten = Console.ReadLine();

            Console.WriteLine("Nhap Lop Hoc: ");
            string lop = Console.ReadLine();
            Console.WriteLine("Nhap Noi Sinh: ");
            string noisinh = Console.ReadLine();
            Console.WriteLine("Nhap Ngay Sinh: ");
            string ngaysinh = Console.ReadLine();
            Console.WriteLine("Nhap Diem: ");
            double diem = double.Parse(Console.ReadLine());

            int dem = 0;
            foreach (Info info in infos)
            {
                if (ten == info.Name)
                {

                    info.Lop = lop;
                    if (lop == null)
                    {
                        info.Lop = info.Lop + lop;
                    }

                    info.NoiSinh = noisinh;
                    if (noisinh == null)
                    {
                        info.NoiSinh = info.NoiSinh + noisinh;
                    }
                    info.NgaySinh = ngaysinh;
                    if (ngaysinh == null)
                    {
                        info.NgaySinh = info.NgaySinh + ngaysinh;
                    }
                    info.Diem = diem;
                    if (diem == null)
                    {
                        info.Diem = info.Diem + diem;
                    }
                    infos.Add(info);
                    OptionUIInfo();
                }
                {
                    dem = 0;
                }
            }
            if (dem == 0)
            {
                Console.WriteLine("Ten Ban Nhap Chua Dung");
                OptionUIInfo();
            }
        }

        private static void QuayLai()
        {
            OptionUI();
        }

        private static void XoaThongTin()
        {
            Console.WriteLine("Xoa Thong Tin ");
            foreach (Info info in infos)
            {
                Console.WriteLine("Danh Sach Ten Nguoi Dung");
                Console.WriteLine("" + info.Name);
            }
            int dem = 0;
            Console.WriteLine("Nhap Ten Nguoi Dung Can Xoa: ");
            string name = Console.ReadLine();
            foreach (Info info1 in infos)
            {
                if (name == info1.Name)
                {
                    infos.Remove(info1);
                    Console.WriteLine("Thong Tin Ten " + info1.Name + " Da duoc xoa ");
                    dem = 1;
                    OptionUIInfo();
                    break;
                }
            }
            if (dem == 0)
            {
                Console.WriteLine("Ban Nhap Ten Khong co trong du lieu");
            }
        }

        private static void XemThongTin()
        {
            Console.WriteLine("Xem Thong Tin ");
            foreach (Info info in infos)
            {
                if (info.Name == null)
                {
                    Console.WriteLine("Ban Chua Nhap Thong Tin ");
                }
                else
                {
                    Console.WriteLine("Nguoi Dung " + info.Name + " co thong tin ");
                    Console.WriteLine("Ten: " + info.Name);
                    Console.WriteLine("Lop: " + info.Lop);
                    Console.WriteLine("Noi Sinh: " + info.NoiSinh);
                    Console.WriteLine("Ngay Sinh: " + info.NgaySinh);
                    Console.WriteLine("Diem: " + info.Diem);
                    Console.WriteLine("--------------");
                    break;
                }
            }
            OptionUIInfo();
        }

        private static void NhapThongTin()
        {
            Info info = new Info();
            Console.WriteLine("Nhap Thong Tin ");

            Console.WriteLine("Nhap Ten: ");
            info.Name = Console.ReadLine();
            Console.WriteLine("Nhap Lop Hoc: ");
            info.Lop = Console.ReadLine();
            Console.WriteLine("Nhap Noi Sinh: ");
            info.NoiSinh = Console.ReadLine();
            Console.WriteLine("Nhap Ngay Sinh: ");
            info.NgaySinh = Console.ReadLine();
            Console.WriteLine("Nhap Diem: ");
            info.Diem = double.Parse(Console.ReadLine());
            infos.Add(info);
            OptionUIInfo();
        }

        private static void Register()
        {
            User user = new User();
            Console.WriteLine("Nhap Tai Khoan ");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Nhap Mat Khau ");
            user.Password = Console.ReadLine();

            users.Add(user);

        }

        private static void Logout()
        {
            Console.WriteLine("Ban Da Thoat Chuong Trinh");
        }

        private static void OptionUI()
        {
            Console.WriteLine("1. Dang Ky ");
            Console.WriteLine("2. Dang Nhap ");
            Console.WriteLine("3. Thoat ");
            int chon = 0;
            do
            {
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        Register();
                        OptionUI();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Logout();
                        break;
                    default:
                        Console.WriteLine("Not default");
                        break;
                }
            } while (chon != 3);
        }

        private static void Login()
        {
            Console.WriteLine("Nhap Tai Khoan ");
            string username = Console.ReadLine();

            Console.WriteLine("Nhap Mat Khau ");
            string password = Console.ReadLine();
            int dem = 0;
            foreach (User user in users)
            {
                if (username == user.UserName && password == user.Password)
                {
                    dem = 1;
                }
            }
            if (dem == 1)
            {
                Console.WriteLine("Ban Da Dang Nhap");
                OptionUIInfo();
            }
            else if (dem == 0)
            {
                Console.WriteLine("Ban Da Dang Nhap That Bai");
                OptionUI();
            }
        }
    }

    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    class Info
    {
        public string Name { get; set; }
        public string Lop { get; set; }
        public string NoiSinh { get; set; }
        public string NgaySinh { get; set; }
        public Double Diem { get; set; }
    }
}