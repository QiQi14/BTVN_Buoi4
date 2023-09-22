using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BTVN_Buoi4 {
    class Program
    {
        private static List<User> listUser;
        private static List<SinhVien> ListSinhVien;


        public class SinhVien
        {

            public string Name { get; set; }
            public string lop { get; set; }
            public string ngaysinh { get; set; }
            public double Diem { get; set; }

            public string noisinh { get; set; }

        }

     /*   public class Qlsv
        {
            private static List<SinhVien> ListSinhVien;

            public Qlsv()
            {
                ListSinhVien = new List<SinhVien>();
            }

           

            private void NhapSinhVien()
            {
                // Khởi tạo một sinh viên mới
                SinhVien sv = new SinhVien();

                Console.Write("Nhap ten sinh vien: ");
                sv.Name = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap lop vien: ");
                sv.lop = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap ngay sinh vien: ");
                sv.ngaysinh = Convert.ToString(Console.ReadLine());


                Console.Write("Nhap noi sinh vien: ");
                sv.noisinh = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap diem : ");
                sv.Diem = Convert.ToDouble(Console.ReadLine());



                ListSinhVien.Add(sv);
            }


            private void UpdateSinhVien()
            {

                SinhVien sv = new SinhVien();

                if (sv != null)
                {
                    Console.Write("Nhap ten sinh vien: ");
                    string namesv = Convert.ToString(Console.ReadLine());

                    if (namesv != null && namesv.Length > 0)
                    {
                        sv.Name = namesv;
                    }

                    Console.Write("Nhap lop sinh vien: ");

                    string lopsv = Convert.ToString(Console.ReadLine());
                    if (lopsv != null && lopsv.Length > 0)
                    {
                        sv.lop = lopsv;
                    }

                    Console.Write("Nhap ngay sinh sv : ");
                    string ngaysinhsv = Convert.ToString(Console.ReadLine());

                    if (ngaysinhsv != null && ngaysinhsv.Length > 0)
                    {
                        sv.ngaysinh = Convert.ToString(ngaysinhsv);
                    }

                    Console.Write("Nhap noi sinh sv: ");
                    string noisinhsv = Convert.ToString(Console.ReadLine());

                    if (noisinhsv != null && noisinhsv.Length > 0)
                    {
                        sv.noisinh = Convert.ToString(noisinhsv);
                    }

                    Console.Write("Nhap diem toan: ");
                    string diemsv = Convert.ToString(Console.ReadLine());
                    // Nếu không nhập gì thì không cập nhật điểm toán
                    if (diemsv != null && diemsv.Length > 0)
                    {
                        sv.Diem = Convert.ToDouble(diemsv);
                    }


                }
                else
                {
                    Console.WriteLine("");
                }
            }


            private bool DeleteSV(string Namesv)
            {
                bool IsDeleted = false;

                SinhVien sv = ListSinhVien.FirstOrDefault(x => x.Name == Namesv);
                if (sv != null)
                {
                    IsDeleted = ListSinhVien.Remove(sv);
                }
                return IsDeleted;
            }
        }


        */
        public static void Main(string[] args)
        {
            listUser = new List<User>();
            
            ListSinhVien = new List<SinhVien>();
            

            int option = 0;

            simpleUI();

            while (true)
            {
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    registerUI();
                    Console.WriteLine("Dang ky thanh cong");
                    simpleUI();

                }
                else if (option == 2)
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
                }
                else if (option == 3)
                {
                    NhapSinhVien();
                }
                else if (option == 4)
                {
                    UpdateSinhVien();
                }
                else if (option == 5)
                {
                   if(ListSinhVien.Count > 0)
                    {
                        string name= Convert.ToString(Console.ReadLine());
                        DeleteSV(name); Console.WriteLine();
                       
                    }
                   
                }
                else if (option == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Khong co tinh nang nay");
                    simpleUI();
                }
            }
        }



        private static void simpleUI()
        {
            Console.WriteLine("Chuong trinh dang ky/dang nhap, moi ban chon chuc nang");
            Console.WriteLine("1. Dang ky");
            Console.WriteLine("2. Dang nhap");
            Console.WriteLine("3. Them");
            Console.WriteLine("4. Sua");
            Console.WriteLine("5. Xoa");
            Console.WriteLine("6. Thoat");
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


    private static void NhapSinhVien()
     {
            // Khởi tạo một sinh viên mới
            SinhVien sv = new SinhVien();

            Console.Write("Nhap ten sinh vien: ");
            sv.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap lop vien: ");
            sv.lop = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap ngay sinh vien: ");
            sv.ngaysinh = Convert.ToString(Console.ReadLine());


            Console.Write("Nhap noi sinh vien: ");
            sv.noisinh = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap diem : ");
            sv.Diem = Convert.ToDouble(Console.ReadLine());



            ListSinhVien.Add(sv);
        }


    private static void UpdateSinhVien()
        {

            SinhVien sv = new SinhVien();

            if (sv != null)
            {
                Console.Write("Nhap ten sinh vien: ");
                string namesv = Convert.ToString(Console.ReadLine());

                if (namesv != null && namesv.Length > 0)
                {
                    sv.Name = namesv;
                }

                Console.Write("Nhap lop sinh vien: ");

                string lopsv = Convert.ToString(Console.ReadLine());
                if (lopsv != null && lopsv.Length > 0)
                {
                    sv.lop = lopsv;
                }

                Console.Write("Nhap ngay sinh sv : ");
                string ngaysinhsv = Convert.ToString(Console.ReadLine());

                if (ngaysinhsv != null && ngaysinhsv.Length > 0)
                {
                    sv.ngaysinh = Convert.ToString(ngaysinhsv);
                }

                Console.Write("Nhap noi sinh sv: ");
                string noisinhsv = Convert.ToString(Console.ReadLine());

                if (noisinhsv != null && noisinhsv.Length > 0)
                {
                    sv.noisinh = Convert.ToString(noisinhsv);
                }

                Console.Write("Nhap diem : ");
                string diemsv = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (diemsv != null && diemsv.Length > 0)
                {
                    sv.Diem = Convert.ToDouble(diemsv);
                }


            }
            else
            {
                Console.WriteLine("");
            }
        }


    private static bool DeleteSV(string Namesv)
        {

            bool IsDeleted = false;

            SinhVien sv = ListSinhVien.FirstOrDefault(x => x.Name == Namesv);
            if (sv != null)
            {
                IsDeleted = ListSinhVien.Remove(sv);
            }
            return IsDeleted;

            
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
                    Console.WriteLine("Dang nhap thanh cong");
                    return;
                }
            }
            Console.WriteLine("Dang nhap that bai");
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
}