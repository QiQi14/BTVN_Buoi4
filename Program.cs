using System;
using System.Runtime.InteropServices;


namespace BTVNB4
{
   class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static Dictionary<string, Student> students = new Dictionary<string, Student>();
        static string currentUser = null;
        static void Main(string[] args)
        {
            
            optionUI();
        }
        
        class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public string BirthPlace { get; set; }
            public string BirthDate { get; set; }
            public float Grades { get; set; }
        }

        private static void optionUI()
        {
            Console.WriteLine("        STUDENTS MANAGEMENT PROGRAM!!!        ");
            
            int option;
            do
            {
                Console.WriteLine("Please choose 1 to 5 option below to continue!");
                Option();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: 
                        Login(); 
                        break;
                    case 2: 
                        Logout(); 
                        break;
                    case 3: 
                        Register(); 
                        break;
                    case 4: 
                        ManageStudent(); 
                        break;
                    case 5: 
                        Exit(); 
                        break;
                    default: 
                        Console.WriteLine("Please select again!!"); 
                        break;
                }
            } while (option != 5);
        }

        public static void Option()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Register new account");
            Console.WriteLine("4. Manage students");
            Console.WriteLine("5. Exit the program");
        }
        public static void Logout()
        {
            Console.WriteLine("           STUDENTS MANAGEMENT PROGRAM!!!          ");
            currentUser = null;
            Console.WriteLine("Logout succeed");
        }

        public static void Register()

        {
            Console.Write("Your new login name: ");
            string username = Console.ReadLine();
            if (users.ContainsKey(username))
            {
                Console.WriteLine("Username existed");
                return;
            }
            Console.Write("Your new password: ");
            string password = Console.ReadLine();


            Console.WriteLine("Your new login name is: " + username);
            Console.WriteLine("Your new password is: " + password);

            users[username] = password;

            Console.WriteLine("Your account is registered successfull");
        }
        public static void Login()
        {
            Console.WriteLine("\n");
            Console.Write("Your login name: ");
            string username = Console.ReadLine();
            Console.Write("Your password: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username] == password)
            {
                currentUser = username;
                Console.WriteLine("Login success");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
        public static void ManageStudent()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please logging in to manage students' list");
                return;
            }
            int option;
            do
            {
                Console.WriteLine("1. Input student Info");
                Console.WriteLine("2. View students Info");
                Console.WriteLine("3. Delete student Info");
                Console.WriteLine("4. Update student Info");
                Console.WriteLine("5. Return");
                Console.Write("Select: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: 
                        AddStudent(); 
                        break;
                    case 2: 
                        ViewStudent(); 
                        break;
                    case 3: 
                        DeleteStudent(); 
                        break;
                    case 4: 
                        UpdateStudent(); 
                        break;
                    case 5: 
                        break;
                    default: 
                        Console.WriteLine("Your selection is invalid!"); 
                        break;
                }
            } while (option != 5);
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

            Console.Write("Grades: ");
            student.Grades = float.Parse(Console.ReadLine());

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
                Console.WriteLine($"Grades: {student.Grades}");
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
                Console.WriteLine("NO STUDENT FOUND");
            }
        }

        public static void UpdateStudent()
        {
            Console.Write("Input the name of student needs to update: ");
            string name = Console.ReadLine();

            if (students.ContainsKey(name))
            {
                Student student = students[name];
                Console.Write("Class (Enter to skip): ");
                string newClass = Console.ReadLine();

                if (!string.IsNullOrEmpty(newClass))
                {
                    student.Class = newClass;
                }

                Console.Write("Birth Place (Enter to skip): ");
                string newBirthPlace = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBirthPlace))
                {
                    student.BirthPlace = newBirthPlace;
                }

                Console.Write("Birth Date (Enter to skip): ");
                string newBirthDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBirthDate))
                {
                    student.BirthDate = newBirthDate;
                }

                Console.Write("Grades (Enter to skip): ");
                string newGrade = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGrade))
                {
                    student.Grades = float.Parse(newGrade);
                }
            }
            else
            {
                Console.WriteLine("NO STUDENT FOUND");
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