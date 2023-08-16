namespace Demo.Models
{
    public class RulesProvider
    {
        private readonly List<Rule> rules;

        public RulesProvider()
        {
            rules = new List<Rule>() {
                new Rule()
                {
                    Code = 1,
                    Description = "Only 1 piece of each item of clothing may be put on",
                    Condition = (p,cmd) =>
                    {
                        if(cmd.CommandType == CommandType.clothing)
                        {
                            if( cmd.Code == 5) //
                            {
                                if( p.hasJacket == true) //has jacket already
                                {
                                    return false;
                                }
                            }
                            else if( cmd.Code == 6)
                            {
                                if(p.pantType != null) //has pant already(short/pant)
                                {
                                    return false;
                                }
                            }
                            else if( cmd.Code == 4)
                            {
                                if(p.hasShirt == true) //has shirt already
                                {
                                    return false;
                                }
                            }

                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 2,
                    Description = "You cannot put on socks when it is hot",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 3)
                        {
                            if( p.Environment.TemperatureType == TemperatureType.HOT )
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 3,
                    Description = "You cannot put on jacket when it is hot",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 5)
                        {
                            if( p.Environment.TemperatureType == TemperatureType.HOT )
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 4,
                    Description = "Socks must be put on before footwear",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 1)
                        {
                            if( p.Environment.TemperatureType == TemperatureType.COLD && p.hasSocks != true )
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 5,
                    Description = "Shirt must be put on before headwear and jacket",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 2 || (cmd.Code == 5 && p.Environment.TemperatureType == TemperatureType.COLD))
                        {
                            if( p.hasShirt != true )
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 6,
                    Description = "Pants must be put on before footwear",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 1)
                        {
                            if( p.pantType == null ) //short or pant 
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 7,
                    Description = "Pajamas must be taken off before anything can be put on",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code >= 1 && cmd.Code <=6)
                        {
                            if( p.hasPajama == true )
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
                new Rule()
                {
                    Code = 8,
                    Description = "You cannot leave the house until all items of clothing are on (except socks and a jacket when it’s hot)",
                    Condition = (p,cmd) =>
                    {
                        if( cmd.Code == 7)
                        {
                            bool hasNoShirt = p.hasShirt != true;
                            bool hasNoSocks = p.Environment.TemperatureType == TemperatureType.COLD ? p.hasSocks != true : false;
                            bool hasNoJacket = p.Environment.TemperatureType == TemperatureType.COLD ? p.hasJacket != true : false;
                            bool hasNoFootwear = p.footWear == null;
                            bool hasNoHeadWear = p.headWear == null;
                            bool hasNoPantOrShort = p.pantType == null;

                            if( hasNoShirt || hasNoSocks || hasNoPantOrShort || hasNoFootwear || hasNoJacket || hasNoHeadWear)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                },
            };
        }

        public List<Rule> ExecuteRules(Person p, Command cmd)
        {
            List<Rule> failedRules = new List<Rule>();
            foreach (var rule in rules)
            {
                if (rule.Condition != null && !rule.Condition(p, cmd))
                {
                    failedRules.Add(rule);
                }
            }
            return failedRules;
        }
    }

}