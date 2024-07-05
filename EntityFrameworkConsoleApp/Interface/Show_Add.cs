using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Interface
{
    internal interface Show_Add <T>
    {
        void ShowAll();
        void Add();
        T Create();
    }
}
