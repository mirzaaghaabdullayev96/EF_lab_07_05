using EntityFrameworkConsoleApp.Constants;
using EntityFrameworkConsoleApp.Interface;
using EntityFrameworkConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    public class AuthorService : DbContextCall, Show_Add<Author>
    {
        public void Add()
        {
            dbContext.Add(Create());
            Console.WriteLine($"{Create().Name} was added");
            dbContext.SaveChanges();
        }

        public Author Create()
        {
            string name = Program.GetInput("Enter your name");
            Console.WriteLine("Enter your nationality");
            Nationality nationality = (Nationality)Enum.Parse(typeof(Nationality), Console.ReadLine());
            return new Author() { Name = name, Nationality = nationality };
        }

        public void ShowAll()
        {
            var authors = dbContext.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
        }

        public void ShowByBook()
        {
            BookService bookService = new BookService();
            bookService.ShowAll();

            Console.WriteLine("Choose book");
            string book = Console.ReadLine();
            Console.WriteLine();

            var authors = dbContext.Authors.Include(x => x.Books).Where(x => x.Name == book).ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
        }

        public void FindAuthorByName()
        {
            string name = Program.GetInput("type author name");
            var authors = dbContext.Authors.Where(x => x.Name == name).ToList();
            if (authors.Count == 0)
            {
                Console.WriteLine("not found");
            }
            else
            {
                foreach (var author in authors)
                {
                    Console.WriteLine(author);
                }
            }
        }

        public void AssignToBook()
        {
            ShowAll();
            BookService bookService = new();
            Console.WriteLine();
            bookService.ShowAll();
            Console.WriteLine("Type author name");
            string authorName = Console.ReadLine();
            Console.WriteLine("Type book name");
            string bookName = Console.ReadLine();

            dbContext.AuthorsOfBooks.Add(
                new AuthorsOfBooks()
                {
                    Author = dbContext.Authors.FirstOrDefault(x => x.Name == authorName),
                    Book = dbContext.Books.FirstOrDefault(x => x.Name == bookName)
                }
                );
            dbContext.SaveChanges();

        }


    }
}
