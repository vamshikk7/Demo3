using Demo.Models;

public enum CommandType
{
    clothing
}
public class Command
{
    public int Code { get; set; }
    public CommandType CommandType { get; set; }
    public string? Description { get; set; }
    public Func<Person, string>? Execute { get; set; }

}