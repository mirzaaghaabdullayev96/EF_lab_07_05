using EntityFrameworkConsoleApp.Constants;

namespace EntityFrameworkConsoleApp.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Nationality Nationality { get; set; }
    public List<Book> Books { get; set; }
    public override string ToString()
    {
        return $"Id - {Id}, Name - {Name}, Nationality - {Nationality}";
    }
}
