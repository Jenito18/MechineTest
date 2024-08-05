using ConsoleAppLibraryManagementSystem.System;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleAppLibraryManagementSystem
{
    public class LibraryApp
    {
        // fields

        private readonly ILibrarySystem _libiraryManagement;

        // Constructor Injection

        public LibraryApp(ILibrarySystem libiraryManagement)

        {
            _libiraryManagement = libiraryManagement;
        }
        static void Main(string[] args)
        {
            //object creation 


            var libSystem = new LibraryApp(new LibrarySystemImpl());



            //Menu
            while (true)
            {


                Console.WriteLine("\n Libirary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Search Book ID");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. List All Books");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your Choice: ");


                //validate Choice 
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice .Please try again");
                    continue;

                }

                switch (choice)
                {
                    case 1:
                        //add book

                        libSystem._libiraryManagement.AddBook();
                        break;


                    case 2:

                        //update book details

                        Console.WriteLine("Enter Book ID to update: ");

                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            libSystem._libiraryManagement.UpdateBook(updateId);
                        }
                        else
                        {

                            Console.WriteLine("Invalid Book ID entered");

                        }
                        break;


                    case 3:

                        //Search book

                        Console.WriteLine("Enter Book ID to Search: ");

                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            libSystem._libiraryManagement.SearchById(searchId);
                        }
                        else
                        {

                            Console.WriteLine("Invalid Book ID");

                        }
                        break;

                    case 4:

                        //Delete book

                        Console.WriteLine("Enter Book ID to Delete: ");

                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            libSystem._libiraryManagement.DeleteBook(deleteId);
                        }
                        else
                        {

                            Console.WriteLine("Invalid Book ID");

                        }
                        break;

                    //Listallbooks
                    case 5:
                        libSystem._libiraryManagement.ListAllBooks();
                        break;


                    //exit case

                    case 6:
                        return;


                        Console.ReadKey();

                }


            }
        }
    }
}
