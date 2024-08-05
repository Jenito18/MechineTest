using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryManagementSystem.System
{
    public interface ILibrarySystem
    {
        //CRED operations

        //methods for CRED operations
        void AddBook();

        void ListAllBooks();

        void SearchById(int bookId);
        
        void UpdateBook(int bookId);

        void DeleteBook(int bookId);
    }
}
