using EntityFrameworkConsoleApp.Constants;
using System;

namespace EntityFrameworkConsoleApp.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime PublishYear { get; set; }
    public Genre Genre { get; set; }
    public int LibraryId { get; set; }
    public Library Library { get; set; }
    public List<Author> Authors { get; set; }
    

    public override string ToString()
    {
        return $"Id - {Id}, Name - {Name}, PublishYear - {PublishYear}, Genre - {Genre}";
    }

}
