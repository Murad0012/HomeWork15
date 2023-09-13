
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using amqp.Data.Models;
using amqp.Services;

namespace amqp
{
    public class Program
    {
        public static void Main()
        {

            int selectedOption;

            do
            {

                Console.WriteLine("1. Show student methods");
                Console.WriteLine("2. Show classroom methods");
                Console.WriteLine("3. Clean");
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
                        MenuService.MenuShowStudentMethods();
                        break;
                    case 2:
                        MenuService.MenuShowClassRoomMethods();
                        break;
                    case 3:
                        MenuService.MenuClean();
                        break;
                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (selectedOption != 0);
        }
    }
}