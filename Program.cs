using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTVNB4
{
    internal class Homework
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static Dictionary<string, Student> students = new Dictionary<string, Student>();
        static string currentUser = null;
        class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public string BirthPlace { get; set; }
            public string BirthDate { get; set; }
            public float Scores { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please choose 1 to 5 option below to continue!");
            int choice;

            do
            {
                Select();
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Login(); break;
                    case 2: Logout(); break;
                    case 3: Register(); break;
                    case 4: ManageStudent(); break;
                    case 5: Exit(); break;
                    default: Console.WriteLine("Your selection is invalid!"); break;
                }
            } while (choice != 5);
        }

        public static void Select()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Register new account");
            Console.WriteLine("4. Manage students");
            Console.WriteLine("5. Exit the program");
        }

        public static void Login()
        {
            Console.WriteLine(" ");
            Console.WriteLine("You chose login your account");
            Console.Write("Your login name: ");
            string username = Console.ReadLine();
            Console.Write("Your password: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username] == password)
            {
                currentUser = username;
                Console.WriteLine("You login successful");
            }
            else
            {
                Console.WriteLine("Login fail");
            }
        }

        public static void Logout()
        {
            currentUser = null;
            Console.WriteLine("logout succeed");
        }

        public static void Register()

        {
            Console.Write("Your new login name: ");
            string username = Console.ReadLine();
            Console.WriteLine("Your new login name is: " + username);

            if (users.ContainsKey(username))
            {
                Console.WriteLine("Username existed");
                return;
            }
            Console.Write("Your new password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Your new password is: " + password);

            //dùng để lưu trữ dữ liệu vào dictionary
            users[username] = password;
            Console.WriteLine("Your account is registered successfull");
        }

        public static void ManageStudent()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please logging in to manage students' list");
                return;
            }

            int choice;
            do
            {
                Console.WriteLine("1. Input student's information");
                Console.WriteLine("2. See student's information");
                Console.WriteLine("3. Delete student's information");
                Console.WriteLine("4. Custom student's information");
                Console.WriteLine("5. Return");
                Console.Write("Select: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: ViewStudent(); break;
                    case 3: DeleteStudent(); break;
                    case 4: EditStudent(); break;
                    case 5: break;
                    default: Console.WriteLine("Your selection is invalid!"); break;
                }
            } while (choice != 5);
        }

        public static void AddStudent()
        {
            Student student = new Student();

            Console.Write("Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Class: ");
            student.Class = Console.ReadLine();

            Console.Write("Birth place: ");
            student.BirthPlace = Console.ReadLine();

            Console.Write("Birth date: ");
            student.BirthDate = Console.ReadLine();

            Console.Write("Scores: ");
            student.Scores = float.Parse(Console.ReadLine());

            students[student.Name] = student;
        }

        public static void ViewStudent()
        {
            foreach (var student in students.Values)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Class: {student.Class} ");
                Console.WriteLine($"Birth Place: {student.BirthPlace}");
                Console.WriteLine($"Birth Date: {student.BirthDate}");
                Console.WriteLine($"Scores: {student.Scores}");
            }
        }

        public static void DeleteStudent()
        {
            Console.Write("Input the name of student needs to Delete: ");
            string name = Console.ReadLine();

            if (students.ContainsKey(name))
            {
                students.Remove(name);
                Console.WriteLine("Delete this student succeed");
            }
            else
            {
                Console.WriteLine("Can't find this student");
            }
        }

        public static void EditStudent()
        {
            Console.Write("Input the name of student needs to edit: ");
            string name = Console.ReadLine();

            if (students.ContainsKey(name))
            {
                Student student = students[name];
                Console.Write("Class (press enter to keep the old infor): ");
                string newClass = Console.ReadLine();

                if (!string.IsNullOrEmpty(newClass))
                {
                    student.Class = newClass;
                }

                Console.Write("Birth Place (press enter to keep the old infor): ");
                string newBirthPlace = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBirthPlace))
                {
                    student.BirthPlace = newBirthPlace;
                }

                Console.Write("Birth Date (press enter to keep the old infor): ");
                string newBirthDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBirthDate))
                {
                    student.BirthDate = newBirthDate;
                }

                Console.Write("Scores (press enter to keep the old infor): ");
                string newScore = Console.ReadLine();
                if (!string.IsNullOrEmpty(newScore))
                {
                    student.Scores = float.Parse(newScore);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy học sinh.");
            }
        }
        public static void Exit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("You chose exit the program");
            Console.WriteLine("The program is exiting...");
        }
    }
}



