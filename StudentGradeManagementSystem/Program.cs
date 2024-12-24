/* File: Program.cs
 * Author: JesseReadAu
 * Version: 1.0
 * Date: 2024/12/24
 * Description: This project was made for the Microsoft Foundations of Coding Full Stack course.
 *              It is a student grade management system to add students, assign subjects with grades, 
 *              average grades, and display a student record.
 */

namespace StudentGradeManagementSystem
{
    class Program
    {
        public static List<Student> students = new List<Student>();

        /// <summary>
        /// Main method to run the program, starts the program on the main menu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MainMenu();
        }

        /// <summary>
        /// Shows the Add Students menu which allows a user to add a new student.
        /// </summary>
        private static void ShowAddStudent()
        {
            bool passedValidation = true;

            MainHeader("Add a New Student");
            
            try
            {
                Console.Write("Student ID number: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Student Name: ");
                string name = Console.ReadLine();

                if(id.Equals(0))
                {
                    Console.WriteLine("A student ID of 0 is not allowed.");
                    ReturnToMainMenu();
                }

                foreach (Student student in students)
                {
                    if(student.Id == id) 
                    {
                        Console.WriteLine("That student ID has already been used!");
                        passedValidation = false;
                    }
                }

                if (passedValidation)
                {
                    students.Add(new Student(id, name));
                    Console.WriteLine("New Student Added");
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine($"There was a problem adding the student:\n {e.Message}"); 
            }

            ReturnToMainMenu();
        }

        /// <summary>
        /// Shows all students and allows the user to select one to see their ID, Name, Grades and Average Grade.
        /// </summary>
        private static void ShowStudents()
        {
            int selectedId = 0;

            do
            {

                MainHeader("List of All Students");

                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }

                Console.Write("Select a student id to review or write Menu to return: ");
                string answer = Console.ReadLine();

                if (answer.ToLower().Equals("menu"))
                    MainMenu();
                else if (int.TryParse(answer, out int number))
                {
                    foreach (Student student in students)
                    {
                        if (student.Id.Equals(number))
                        {
                            selectedId = number;
                            Console.WriteLine(student.ToString());
                            break;
                        }
                    }

                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid Selection.");
                    Thread.Sleep(1500);
                }
            } while (true);
        }


        /// <summary>
        /// Allows the user to add a grade to a student based on the user inputed student ID.
        /// </summary>
        private static void ShowAddGrade()
        {
            int selectedId = 0;
            int validatedGrade;
            string userSelectedGrade = null;

            

            do
            {
                userSelectedGrade = null;

                MainHeader("Add New Grade");

                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }

                Console.Write("Select student ID or type Menu to return: ");
                string userSelectedId = Console.ReadLine();

                if (userSelectedId.ToLower().Equals("menu"))
                    MainMenu();

                Console.Write("Enter the student's Class: ");
                string userSelectedClass = Console.ReadLine();

                do
                {
                    if (!String.IsNullOrWhiteSpace(userSelectedGrade))
                        Console.WriteLine("You need to enter a number for the student's grade!");
                    Console.Write("Students grade (Number): ");
                    userSelectedGrade = Console.ReadLine();
                }
                while (!int.TryParse(userSelectedGrade, out validatedGrade));
                

                
                if (int.TryParse(userSelectedId, out int number))
                {
                    foreach (Student student in students)
                    {
                        if (student.Id.Equals(number))
                        {
                            try
                            {
                                student.AddGrade(userSelectedClass, validatedGrade);
                                Console.WriteLine("New grade record added.");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine($"There was a problem adding that grade.\n{e}");

                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No student with that ID found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No student with that ID found.");
                    Thread.Sleep(1500);
                }

                Thread.Sleep(1500);

            } while (true);
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        private static void ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Application Closing");
            Environment.Exit(0);
        }


        /// <summary>
        /// Shows the main menu prompting the user to select an option. Add user, Student Profile, Add Grade or Exit.
        /// </summary>
        private static void MainMenu()
        {
            Console.Clear();
            MainHeader("Main Menu");
            Console.WriteLine("Select a menu options:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Student Profile");
            Console.WriteLine("3. Add Grade");
            Console.WriteLine("4. Exit");

            bool isValidSelection;
            do {
                Console.Write("-----\nYour Selection: ");
                string selection = Console.ReadLine();
                isValidSelection = true; // Assume it’s valid; set to false if it’s not.

                switch (selection)
                {
                    case "1":
                        ShowAddStudent();
                        break;
                    case "2":
                        ShowStudents();
                        break;
                    case "3":
                        ShowAddGrade();
                        break;
                    case "4":
                        
                        ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        isValidSelection = false;
                        break;
                }

            } while (!isValidSelection);
        }

        /// <summary>
        /// Simpifies the ability to add a header for each section of the application, title is followed with dashes the same size on a new line. 
        /// </summary>
        /// <param name="title">String put into the title</param>
        private static void MainHeader(string title)
        {
            Console.Clear();
            string str = $"{title} - Student Grade Management System\n";

            int strLen = str.Length - 1; //Needed for for loop otherwise the length keeps changing.
            for(int i = 0; i < strLen; i++)
            {
                str += "-";
            }
            
            Console.WriteLine(str);
        }

        /// <summary>
        /// Returns to the main menu after a specified time in milliseconds.
        /// </summary>
        /// <param name="time">Milliseconds to wait before going to main menu. Default: 1500</param>
        private static void ReturnToMainMenu(int time = 1500)
        {
            Thread.Sleep(time);

            MainMenu();
        }
    }
}