using Screen;
using Student;
using User;
using FileController;

namespace Program {
    class Program
    {
        static void Main(string[] args)
        {
            //Viết chương trình cho phép người dùng đăng nhập, đăng xuất và đăng ký tài khoản,
            //sau khi đăng ký thành công thì cho phép người dùng nhập / xem / xóa / sửa
            //thông tin học sinh với các thuộc tính: tên, lớp, nơi sinh, ngày sinh và điểm.
            //Ghi và đọc file những dữ liệu mà ng dùng đã nhập - 2 hướng, lưu file mỗi khi ng dùng nhập input mới hoặc lưu lại sau khi kết thúc
            //Lưu ý: Chương trình chỉ thoát khi người dùng chọn chức năng thoát // vòng lặp
            // Trước đăng nhập/Đăng nhập thành công/Chọn xem ds
            // danh sách user & user hiện tại có thể được truy cập ở mọi class

            ReadWriteFile.readUserFile();
            ScreenController controller = new ScreenController(ScreenName.LOGIN) { iAction = new LoginScreen()};
            while (true)
            {
                controller.render();
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    ReadWriteFile.writeUserFile();
                    break;
                }
                controller.selected(option);
            }
        }
    }

    public static class AppData
    {
        public static UserModel? user;
        public static List<UserModel> listUser = new();
        public static List<StudentModel> listStudent = new();
    }
}