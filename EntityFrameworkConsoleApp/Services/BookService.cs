using EntityFrameworkConsoleApp.Constants;
using EntityFrameworkConsoleApp.Interface;
using EntityFrameworkConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    internal class BookService : DbContextCall, Show_Add<Book>
    {
        public void Add()
        {
            dbContext.Add(Create());
            Console.WriteLine($"{Create().Name} was added");
            dbContext.SaveChanges();
        }

        public Book Create()
        {
            string name = Program.GetInput("Enter your name");
            Console.WriteLine("Enter your genre");
            Genre genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine());
            return new Book() { Name = name, Genre = genre, PublishYear = DateTime.Now };
        }

        public void ShowAll()
        {
            var books = dbContext.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void ShowByLibrary()
        {
            LibraryService libraryService = new LibraryService();
            libraryService.ShowAll();

            Console.WriteLine("Choose library");
            string library = Console.ReadLine();
            Console.WriteLine();

            var books = dbContext.Books.Include(x => x.Library).Where(x => x.Library.Name == library).ToList();

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void ShowByAuthor()
        {
            AuthorService authorService = new AuthorService();
            authorService.ShowAll();

            Console.WriteLine("Choose author");
            string author = Console.ReadLine();
            Console.WriteLine();

            //var books = dbContext.Books.Include(x => x.Authors).Where(x => x.Authors.Contains(dbContext.Authors.FirstOrDefault(x => x.Name == author))).ToList(); //error
            
            var books=dbContext.AuthorsOfBooks.Where(x=>x.Author.Name == author).Include(x=>x.Author).Include(x=>x.Book).ToList();

            //var booksByAuthor = dbContext.Authors.Where(x => x.Name == author).Include(x => x.Books).ToList();

            foreach (var book in books)
            {
                Console.WriteLine(book.Book);
            }

            //foreach (var aut in booksByAuthor)
            //{
            //    var bookss = aut.Books;
            //    foreach (var book in bookss)
            //    {
            //        Console.WriteLine(book);
            //    }

            //}
        }

        public void ShowAllWithAuthors()
        {
            var books = dbContext.Books.Include(x => x.Authors).ToList();
            foreach (var book in books)
            {
                if (book.Authors.Count == 0)
                    continue;
                book.Authors.ForEach(x => Console.WriteLine($"Book Id - {book.Id}, Name - {book.Name}, Genre - {book.Genre}, Publish date - {book.PublishYear}, Author - {x.Name}"));
            }
        }

        public void FindBookByName()
        {
            string name = Program.GetInput("type book name");
            Console.WriteLine();
            var books = dbContext.Books.Where(x => x.Name == name).ToList();
            if (books.Count == 0)
            {
                Console.WriteLine("not found");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public void FindBookByGenre()
        {
            string name = Program.GetInput("type book genre");
            var books = dbContext.Books.Where(x => x.Genre.ToString() == name).ToList();
            if (books.Count == 0)
            {
                Console.WriteLine("not found");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
