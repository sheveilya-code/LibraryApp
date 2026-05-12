using System;
using System.Collections.Generic;
using LibraryApp.Models;
using LibraryApp.Services;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Библиотека ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Добавить журнал");
                Console.WriteLine("3. Показать все");
                Console.WriteLine("4. Поиск по автору");
                Console.WriteLine("5. Выдать книгу");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddBook(library); break;
                    case "2": AddMagazine(library); break;
                    case "3": ShowAll(library); break;
                    case "4": SearchByAuthor(library); break;
                    case "5": BorrowBook(library); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Неверный выбор. Нажмите любую клавишу..."); Console.ReadKey(); break;
                }
            }
        }

        static void AddBook(Library library)
        {
            try
            {
                Console.Write("Название: "); string title = Console.ReadLine();
                Console.Write("Автор: "); string author = Console.ReadLine();
                Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("Страницы: "); int pages = int.Parse(Console.ReadLine());
                library.AddItem(new Book(title, author, year, pages));
                Console.WriteLine("Книга добавлена!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void AddMagazine(Library library)
        {
            try
            {
                Console.Write("Название: "); string title = Console.ReadLine();
                Console.Write("Автор: "); string author = Console.ReadLine();
                Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("Номер выпуска: "); int issueNumber = int.Parse(Console.ReadLine());
                library.AddItem(new Magazine(title, author, year, issueNumber));
                Console.WriteLine("Журнал добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void ShowAll(Library library)
        {
            Console.WriteLine("\n=== Все издания ===");
            var items = library.GetAllItems();
            if (items.Count == 0)
            {
                Console.WriteLine("В библиотеке нет изданий.");
            }
            else
            {
                items.ForEach(item => item.DisplayInfo());
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void SearchByAuthor(Library library)
        {
            Console.Write("Введите имя автора для поиска: ");
            string author = Console.ReadLine();
            var books = library.GetBooksByAuthor(author);

            Console.WriteLine($"\n=== Книги автора '{author}' ===");
            if (books.Count == 0)
            {
                Console.WriteLine("Книги этого автора не найдены.");
            }
            else
            {
                books.ForEach(b => b.DisplayInfo());
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void BorrowBook(Library library)
        {
            Console.Write("Введите название книги для выдачи: ");
            string title = Console.ReadLine();

            var book = library.GetAllItems()
                .OfType<Book>()
                .FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null)
            {
                book.Borrow("Пользователь");
            }
            else
            {
                Console.WriteLine($"Книга '{title}' не найдена в библиотеке.");
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}