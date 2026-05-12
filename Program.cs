using System.Collections.Generic;
using LibraryApp.Models;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("1984", "Оруэлл", 1949, 328);

            IBorrowable borrowable = book; 

            borrowable.Borrow("Анна"); 
            borrowable.Borrow("Иван"); 
            borrowable.Return(); 

            Console.ReadLine(); 
        }
    }
}
