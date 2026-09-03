using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models;

public class TestSet
{
    [Key]
    public required String Id { get; set; }
    public string? Column1 { get; set; }
    public string? Column2 { get; set; }
}
