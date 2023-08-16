namespace Demo.Models
{
    public class Rule
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public int[]? PreReqRules { get; set; }

        public Func<Person, Command, bool>? Condition { get; set; }

    }

}