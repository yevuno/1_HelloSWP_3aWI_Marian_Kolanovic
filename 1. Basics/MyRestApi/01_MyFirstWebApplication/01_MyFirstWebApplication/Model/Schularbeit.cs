namespace _01_MyFirstWebApplication.Models;

public class Schularbeit
{
    public int Id { get; set; }
    public string Fach { get; set; }
    public DateTime Datum { get; set; }
    public int Note { get; set; }

    public int SchuelerId { get; set; }
}