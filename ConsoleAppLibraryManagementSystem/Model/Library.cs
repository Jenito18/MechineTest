using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryManagementSystem.Model
{
    public class Library
    {
        //data members

        public int Id { get; set; } //auto generated id for the books in library

        public string BookName { get; set; } //bookname

        public string AuthorName { get; set; }//author name

        public DateTime PublishedDate { get; set; }//published date

        public long ISBN { get; set; } //accepts only digits

        public bool Avalibility { get; set; }



    }
}
