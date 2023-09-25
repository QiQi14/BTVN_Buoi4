using Program;
using User;

namespace FileController {
    public class ReadWriteFile
    {
        public static string userFileName = "user.txt";
        public static string studentFileName = "student.txt";
        public static void writeUserFile()
        {
                string path = Environment.CurrentDirectory;
                using (StreamWriter output = new(Path.Combine(path, userFileName)))
                {
                    foreach (UserModel user in AppData.listUser)
                    {
                        string line = user.Id.ToString();
                        line += "-" + user.Username;
                        line += "-" + user.Password;
                        output.WriteLine(line);
                    }
                }
        }

        public static void readUserFile()
        {
            string path = Environment.CurrentDirectory;
            using (StreamReader input = new(Path.Combine(path, userFileName)))
            {
                string inputString = input.ReadToEnd().Trim();
                Console.WriteLine(inputString);
                string[] parts = inputString.Split(new char[] { '-', });
                Console.WriteLine(parts[0]); Console.WriteLine(parts[1]); Console.WriteLine(parts[2]);
                UserModel user = new UserModel();
                user.Id = Convert.ToInt32(parts[0]);
                user.Username = parts[1];
                user.Password = parts[2];
                AppData.listUser.Add(user);
            }
        }
    }
}
