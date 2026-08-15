using System.ComponentModel.DataAnnotations;

namespace LTDLLesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string choise;
            List<Student> students = new List<Student>()
            {
                new Student
             {
                    mssv = "001",
                    name = "John Doe"
                },

                new Student
                {
                    mssv = "002",
                    name = "Jane Smith"
                }
            };
            do
            {
                menu();
                Console.WriteLine("Enter your choice: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        // Them sv
                        break;
                    case "2":
                        //Hien thi sv
                        break;
                    case "14":
                        Console.WriteLine("Ban da ket thuc chuc nang");
                        break;
                    default: Console.WriteLine("Sai chuc nang, vui long chon lai");
                        break;
                }
            } while (choise != "0");
        }
   
        static void menu()
        {
            Console.WriteLine("============CHUC NANG============");
            Console.WriteLine("1. Them sinh vien"); 


        }
    }

}