namespace Demo.Models
{
    public class Person
    {
        private readonly Environment environment;

        public string? footWear { get; set; }
        public string? headWear { get; set; }
        public bool? hasSocks { get; set; }
        public bool? hasShirt { get; set; }
        public bool? hasJacket { get; set; }
        public string? pantType { get; set; }
        public bool? hasPajama { get; set; }
        public bool? inHouse { get; set; }
        public Environment Environment { get { return environment; } }
        public Person(Environment environment)
        {
            this.environment = environment;
        }

        public string PutOnFootwear()
        {
            this.footWear = this.environment.TemperatureType == TemperatureType.HOT ? "Sandals" : "Boots";
            return this.footWear;
        }

        public string PutOnHeadwear()
        {
            this.headWear = this.environment.TemperatureType == TemperatureType.HOT ? "Sunglasses" : "Hat";
            return this.headWear;
        }

        public string PutOnSocks()
        {
            if (this.environment.TemperatureType == TemperatureType.HOT)
            {
                return "FAIL";
            }
            else
            {
                this.hasSocks = true;
                return "Socks";
            }
        }
        public string PutOnShirt()
        {
            this.hasShirt = true;
            return "Shirt";
        }

        public string PutOnJacket()
        {
            if (this.environment.TemperatureType == TemperatureType.HOT)
            {
                return "FAIL";
            }
            else
            {
                this.hasJacket = true;
                return "Jacket";
            }
        }
        public string PutOnPants()
        {
            this.pantType = this.environment.TemperatureType == TemperatureType.HOT ? "Shorts" : "Pants";
            return this.pantType;
        }

        public string LeaveHouse()
        {
            this.inHouse = false;
            return "leaving house";
        }

        public string TakeOffPajamas()
        {
            this.hasPajama = false;
            return "Removing PJs";
        }
    }

}