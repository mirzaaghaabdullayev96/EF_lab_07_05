using EntityFrameworkConsoleApp.Interface;
using EntityFrameworkConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    public class LibraryService : DbContextCall, Show_Add<Library>
    {


        public void Add()
        {
            dbContext.Add(Create());
            Console.WriteLine($"{Create().Name} was added"); 
            dbContext.SaveChanges();
        }

        public Library Create()
        {
            string name = Program.GetInput("Enter your name");
            return new Library() { Name = name };
        }

        public void ShowAll()
        {
            var libraries = dbContext.Libraries.ToList();
            foreach (var library in libraries)
            {
                Console.WriteLine(library);
            }
        }

        public void ShowAllWithBooks()
        {
            var books = dbContext.Books.Include(x => x.Library).ToList();
            foreach (var book in books)
            {
                if (book.Library is null)
                    continue;
                Console.WriteLine($"Library - {book.Library.Name}, Book name - {book.Name}");
            }
        }

    }
}
