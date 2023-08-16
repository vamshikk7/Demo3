namespace Demo.Models
{
    public class CommandsProvider
    {
        private readonly List<Command> commands;

        public CommandsProvider()
        {
            commands = new List<Command>() {
                new Command()
                {
                    Code = 1,
                    Description = "Put on footwear",
                    Execute = (p) => p.PutOnFootwear(),
                },
                new Command()
                {
                    Code = 2,
                    Description = "Put on headwear",
                    Execute = (p) => p.PutOnHeadwear()
                },
                new Command()
                {
                    Code = 3,
                    Description = "Put on socks",
                    Execute = (p) => p.PutOnSocks()
                },
                new Command()
                {
                    Code = 4,
                    Description = "Put on shirt",
                    Execute = (p) => p.PutOnShirt()
                },
                new Command()
                {
                    Code = 5,
                    Description = "Put on jacket",
                    Execute = (p) => p.PutOnJacket()
                },
                new Command()
                {
                    Code = 6,
                    Description = "Put on pants",
                    Execute = (p) => p.PutOnPants()
                },
                new Command()
                {
                    Code = 7,
                    Description = "Leave house",
                    Execute = (p) => p.LeaveHouse()
                },
                new Command()
                {
                    Code = 8,
                    Description = "Take off pajamas",
                    Execute = (p) => p.TakeOffPajamas()
                }
            };
        }

        public List<Command> Commands { get { return commands; } }
    }

}