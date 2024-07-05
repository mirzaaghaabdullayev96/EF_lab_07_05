using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    public class DbContextCall
    {
        public static BooksContextDB dbContext = new BooksContextDB();
    }
}
