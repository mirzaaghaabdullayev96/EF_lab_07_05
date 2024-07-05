namespace EntityFrameworkConsoleApp.Models;

public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
        return $"Id - {Id}, Name - {Name}";
    }
}
