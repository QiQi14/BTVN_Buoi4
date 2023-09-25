
using Program;
using Screen;

namespace Student {
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Grade { get; set; }
    }

    public class StudentScreen : IStudentAction {
        public bool add(StudentModel student)
        {
            AppData.listStudent.Add(student); 
            return true;
        }

        public bool edit(int id, StudentModel student)
        {
            if (remove(id))
            {
                AppData.listStudent.Insert(id, student);
                return true;
            }

            Console.WriteLine("Khong co hoc vien nao co id: {0}", id);
            return false;
        }

        public bool remove(int id)
        {
            foreach(StudentModel student in AppData.listStudent)
            {
                if (student.Id == id)
                {
                    AppData.listStudent.Remove(student);
                    return true;
                }
            }
            return false;
        }

        public void render()
        {
            if (AppData.listStudent.Count == 0)
            {
                Console.WriteLine("Chua co hoc vien trong danh sach");
            }
            else
            {
                drawHeader();
                foreach (StudentModel student in AppData.listStudent)
                {
                    drawRow(student);
                }
            }

            Console.WriteLine("===========");
            Console.WriteLine("Chuc nang: ");
            Console.WriteLine("1. Them");
            Console.WriteLine("2. Xoa");
            Console.WriteLine("3. Sua");
        }

        private void drawHeader()
        {
            Console.Write("ID");
            Console.Write("\t|\t");
            Console.Write("Name");
            Console.Write("\t|\t");
            Console.WriteLine("Grade");
        }

        private void drawRow(StudentModel student)
        {
            Console.Write(student.Id);
            Console.Write("\t\t");
            Console.Write(student.Name);
            Console.Write("\t");
            Console.WriteLine(student.Grade);
        }

        public ScreenName selected(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        StudentModel student = new StudentModel();
                        student.Id = AppData.listStudent.Count + 1;
                        Console.WriteLine("Nhap thong tin hoc vien: ");
                        Console.WriteLine("Ten hoc vien: ");
                        student.Name = Console.ReadLine();
                        Console.WriteLine("Diem cua hoc vien: ");
                        student.Grade = (float) Convert.ToDecimal(Console.ReadLine());
                        add(student);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Nhap id hoc vien can xoa: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        remove(id);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Nhap id hoc vien can sua: ");
                        StudentModel student = new StudentModel();
                        student.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap thong tin hoc vien: ");
                        Console.WriteLine("Ten hoc vien: ");
                        student.Name = Console.ReadLine();
                        Console.WriteLine("Diem cua hoc vien: ");
                        student.Grade = (float)Convert.ToDecimal(Console.ReadLine());
                        edit(student.Id, student);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Khong co chuc nang nay");
                        break;
                    }
            }

            return ScreenName.STUDENT;
        }
    }

    public interface IStudentAction : IScreenAction
    {
        bool add(StudentModel student);
        bool remove(int id);
        bool edit(int id, StudentModel student);
    }
}
