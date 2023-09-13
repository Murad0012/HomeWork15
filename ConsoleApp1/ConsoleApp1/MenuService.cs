using System;
using amqp.Data.Models;
using ConsoleTables;

namespace amqp.Services
{

    public class MenuService
    {
        private static ClassroomService classroomService = new();
        public static int selectedOption = new();

        public static void MenuAddClassroom()
        {
            try
            {
                Console.WriteLine("Enter classroom's name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter classroom's subject:");
                string subject = Console.ReadLine()!;

                int classRoomId = classroomService.AddClassroom(name, subject);

                Console.WriteLine($"Classroom with ID:{classRoomId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuDeleteClassroom()
        {
            try
            {
                Console.WriteLine("Enter classroom's id:");
                int id = int.Parse(Console.ReadLine()!);

                classroomService.DeleteClassroom(id);

                Console.WriteLine($"Classroom with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowClassrooms()
        {
            var table = new ConsoleTable("ID", "Name", "Subject");

            foreach (var classroom in classroomService.ShowClassrooms())
            {
                table.AddRow(classroom.Id, classroom.Name, classroom.Subject);
            }

            table.Write();
        }

        public static void MenuAddStudent()
        {
            try
            {
                Console.WriteLine("Enter student's name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter student's surname:");
                string surname = Console.ReadLine()!;

                Console.WriteLine("Enter student's birthday (MM/dd/yyyy):");
                DateOnly birthday = DateOnly.Parse(Console.ReadLine()!);

                int studentId = classroomService.AddStudent(name, surname, birthday);

                Console.WriteLine($"Student with ID:{studentId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuDeleteStudent()
        {
            try
            {
                Console.WriteLine("Enter students's id:");
                int id = int.Parse(Console.ReadLine()!);

                classroomService.DeleteStudent(id);

                Console.WriteLine($"Student with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowStudents()
        {
            var table = new ConsoleTable("ID", "Name", "Surname", "Birthday");

            foreach (var student in classroomService.ShowStudents())
            {
                table.AddRow(student.Id, student.Name, student.Surname, student.Birthday);
            }

            table.Write();
        }

        public static void MenuUpdateStudent()
        {
            try
            {
                Console.WriteLine("Enter students's id:");
                int id = int.Parse(Console.ReadLine()!);
                if (id < 0)
                    throw new Exception("Id can't be less than 0!");

                Console.WriteLine("Enter student's new name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter student's new surname:");
                string surname = Console.ReadLine()!;

                Console.WriteLine("Enter student's new birthday (MM/dd/yyyy):");
                DateOnly birthday = DateOnly.Parse(Console.ReadLine()!);

                classroomService.UpdateStudent(id, name, surname, birthday);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuUpdateClassRoom()
        {
            try
            {
                Console.WriteLine("Enter classroom's id:");
                int id = int.Parse(Console.ReadLine()!);
                if (id < 0)
                    throw new Exception("Id can't be less than 0!");

                Console.WriteLine("Enter classroom's name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter classroom's subject:");
                string subject = Console.ReadLine()!;

                classroomService.UpdateClassRoom(id, name, subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void MenuClean()
        {
            Console.Clear();
        }

        public static void MenuShowStudentMethods()
        {
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Show students");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Delete student");
                Console.WriteLine("4. Update student");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please, select an option:");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }
                switch (selectedOption)
                {
                    case 1:
                        MenuService.MenuShowStudents();
                        break;
                    case 2:
                        MenuService.MenuAddStudent();
                        break;
                    case 3:
                        MenuService.MenuDeleteStudent();
                        break;
                    case 4:
                        MenuService.MenuUpdateStudent();
                        break;
                    case 0:
                        Console.WriteLine("Return to home");
                        break;
                }
            } while (selectedOption != 0);
        }

        public static void MenuShowClassRoomMethods()
        {
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Show ClassRooms");
                Console.WriteLine("2. Add ClassRoom");
                Console.WriteLine("3. Delete ClassRoom");
                Console.WriteLine("4. Update ClassRoom");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please, select an option:");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }
                switch (selectedOption)
                {
                    case 1:
                        MenuService.MenuShowClassrooms();
                        break;
                    case 2:
                        MenuService.MenuAddClassroom();
                        break;
                    case 3:
                        MenuService.MenuDeleteClassroom();
                        break;
                    case 4:
                        MenuService.MenuUpdateClassRoom();
                        break;
                    case 0:
                        Console.WriteLine("Return to home");
                        break;
                }
            } while (selectedOption != 0);
        }
    }
}