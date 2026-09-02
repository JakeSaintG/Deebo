using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models;

public class Superhero
{
    [Key]
    public required String Id { get; set; }
    public string? Column1 { get; set; }
    public string? Column2 { get; set; }
}
