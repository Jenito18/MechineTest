using ConsoleAppLibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryManagementSystem.System
{
    public class LibrarySystemImpl:ILibrarySystem
    {

        //Creating dictionary to store book details

        public static Dictionary<int, Library> libraryData = new Dictionary<int, Library>();


        //giving book id from 100

        public static int bookStockId = 100;

        #region AddBook


        //implementing add method
        public void AddBook()
        {
            //Exception Handling  

            try
            {
                // variable for book name
                string bookName;

                Console.WriteLine("Enter The Book Details ");

                while (true)
                {
                    Console.Write("Book Name : ");
                    bookName = Console.ReadLine();

                    //validation
                    if (!string.IsNullOrEmpty(bookName))

                    {
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Invalid input for Book Name.\n Please enter the correct details");

                    }

                }

                //Author name

                string authorName;

                while (true)
                {
                    Console.Write("Author Name : ");
                    authorName = Console.ReadLine();

                    //validation
                    if (!string.IsNullOrEmpty(authorName))

                    {
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Invalid Author name enter correct details");

                    }

                }

                //publishing date

                DateTime publishedDay;

                while (true)
                {

                    Console.Write("Published Date (YYYY-MM-DD) : ");


                    //validation for book published date

                    if (DateTime.TryParse(Console.ReadLine(), out publishedDay) &&

                       publishedDay <= DateTime.Now)
                    {

                        break;
                    }
                    //return if wrong date entered
                    {

                        Console.WriteLine("Invalid input for Published date. Future Date should not be Entered");
                    }


                }

                //ISBN number
                long isbnNumber;

                while (true)
                {

                    //validation for isbn number
                    Console.WriteLine("Enter the ISBN number :  ");
                    if (long.TryParse(Console.ReadLine(), out isbnNumber))

                    {

                        break;
                    }
                    // return if wrong input entered
                    else
                    {

                        Console.WriteLine("Invalid input for ISBN number! Enter the correct input");

                    }




                }


                //for stock in libirary
                bool avalibility = false;
                while (true)
                {

                    Console.WriteLine("Is the book stock is avalible ? (Yes/NO)");

                    //to get the first character in small form
                    char avalibilityStock = Console.ReadLine().Trim().ToLower()[0];

                    //validation for book avalibility

                    if (avalibilityStock == 'y')
                    {
                        avalibility = true;
                        break;
                    }
                    else if (avalibilityStock == 'n')
                    {
                        avalibility = false;
                        break;
                    }

                    //if wrong input entered return output
                    else
                    {
                        Console.WriteLine("Invalid input .Please Enter yes or no");

                    }



                }


                //autogeneration book id

                int bookId = bookStockId++;

                //generated id will be printed

                Console.WriteLine($"Generated Book Id :{bookId}");



                libraryData.Add(bookId, new Library
                {
                    Id = bookStockId,
                    BookName = bookName,
                    AuthorName = authorName,
                    PublishedDate = publishedDay,
                    ISBN = isbnNumber,
                    Avalibility = avalibility

                });

                Console.WriteLine("Book details added sucessfully");
                Console.WriteLine($"Number of books : {libraryData.Count()}");


            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occured:  {ex.Message}");


            }

        }


        #endregion


        #region DeleteBook


        public void DeleteBook(int bookId)
        {
            try
            {
                //to check whether the id is present in the libirary

                if (!libraryData.ContainsKey(bookId))

                //if not present gives output to user
                {
                    Console.WriteLine("Book details entered not found ");
                    return;


                }

                var Library = libraryData[bookId];

                //Confirmation

                //getting conformation from user

                Console.WriteLine($"Do you want to delete the book details {bookId}({Library.BookName}) Enter yes or no: ");

                //getting first letter from the input from user in small letters

                char confirmation = Console.ReadLine().Trim().ToLower()[0];

                if (confirmation == 'y')
                {
                    Library.Avalibility = false;
                    Console.WriteLine("Book details deleted sucessfully");
                    SearchById(bookId);
                }
                else
                {
                    Console.WriteLine("Deletion of books Cancelled");

                }




            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occured:  {ex.Message}");


            }
        }

        #endregion



        #region Listallbooks

        public void ListAllBooks()
        {
            try
            {
                if (libraryData.Count == 0)
                {

                    Console.WriteLine("No Books details Found");
                    return;

                }
                else

                    foreach (var library in libraryData.Values)
                    {

                        Console.WriteLine($"ID :{library.Id,-5} |BookName: {library.BookName,-20} |AuthorName:{library.AuthorName,-25} | publishedDate:{library.PublishedDate,-30}|  ISBN number:{library.ISBN,-45} ");


                    }


            }


            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);


            }
        }




        #endregion


        #region SearchBook

        public void SearchById(int bookId)
        {
            try
            {

                if (libraryData.TryGetValue(bookId, out Library library))
                {
                    Console.WriteLine($" |BookId: {library.Id} |BookName: {library.BookName}| | Author Name:{library.AuthorName}|");
                }
                else
                {
                    Console.WriteLine("Invalid Book Id enter a valid Book id!");
                    return;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        #endregion



        #region UpdateBook

        public void UpdateBook(int bookId)
        {
            try
            {
                //checking the avalibility of the book details
                if (!libraryData.ContainsKey(bookId))
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }
                else
                {
                    //lfinding book 
                    var library = libraryData[bookId];

                    //ISBN number
                    //show old number and request new number
                    Console.WriteLine($"Current ISBN number : {library.ISBN}");

                    long newISBN;

                    while (true)
                    {


                        Console.WriteLine("Enter the New ISBN number :  ");
                        if (long.TryParse(Console.ReadLine(), out newISBN))
                        {
                            library.ISBN = newISBN;
                            Console.WriteLine($"The new ISBN number is {newISBN} ");
                            break;
                        }

                        else
                        {

                            Console.WriteLine("Invalid ISBN number enter the correct one");

                        }




                    }


                }

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);


            }

            #endregion


            Console.ReadKey();
        }
    }
}

