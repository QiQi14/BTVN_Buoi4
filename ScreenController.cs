
using Student;
using User;

namespace Screen {
    public enum ScreenName
    {
        LOGIN, // Trước login
        ONBOARD, // Sau login
        STUDENT //Danh Sach Hoc vien
    }
    public class ScreenController {
        private ScreenName currentScreen; //Lưu lại màn hình hiện tại của ng dùng
        public ScreenName CurrentScreen
        {
            get { return currentScreen; }
            set
            {
                currentScreen = value;
            }
        }

        public required IScreenAction iAction;

        public ScreenController(ScreenName initialScreen) {
            currentScreen = initialScreen;
            navigate(initialScreen);
        }

        //Chuong trinh quan ly hoc vien
        //1 Dang nhap
        //2 Dang ky
        //Phần dùng chung:
        //9 Quay ve
        //0 Thoat chuong trinh

        public void navigate(ScreenName screenName)
        {
            switch (screenName)
            {
                case ScreenName.LOGIN: iAction = new LoginScreen(); break;
                case ScreenName.ONBOARD: iAction = new OnboardScreen(); break;
                case ScreenName.STUDENT: iAction = new StudentScreen(); break;
                default: Console.WriteLine("Khong co tinh nang nay");  break;
            }
        }

        public void render()
        {
            Console.Clear();
            iAction.render();
            if (currentScreen != ScreenName.LOGIN)
            {
                Console.WriteLine("9.Quay ve");
            }
            Console.WriteLine("0.Thoat");
        }

        public void selected(int option)
        {
            navigate(iAction.selected(option));
        }
    }

    public interface IScreenAction
    {
        void render();
        ScreenName selected(int option);
    }
}
