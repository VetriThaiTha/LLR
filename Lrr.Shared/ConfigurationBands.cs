namespace Lrr.Shared
{
    public class Band : IBand
    {
        public int EndValue { get; set; }
        public double StartingValueMultiple { get; set; }
    }
    public class ConfigurationBands : Configuration, IBandConfiguration
    {
        public ConfigurationBands()
            : base()
        {
            Band1 = new Band{EndValue = FormattingHelper.lakh, StartingValueMultiple = 10};
            Band2 = new Band { EndValue = FormattingHelper.lakh * 10, StartingValueMultiple = 2 };
            Band3 = new Band { EndValue = FormattingHelper.lakh * 25, StartingValueMultiple = 1.75 };
            Band4 = new Band { EndValue = FormattingHelper.crore, StartingValueMultiple = 1.5 };
            Band5 = new Band { EndValue = FormattingHelper.hunderedCrore, StartingValueMultiple = 1.25 };
            Band6 = new Band { EndValue = int.MaxValue, StartingValueMultiple = 1.2 };
        }

        public override double GetStartingValueMultiple(int regValue)
        {
            if (regValue <= Band1.EndValue)
                return Band1.StartingValueMultiple;

            if (regValue <= Band2.EndValue)
                return Band2.StartingValueMultiple;

            if (regValue <= Band3.EndValue)
                return Band3.StartingValueMultiple;
            if (regValue <= Band4.EndValue)
                return Band4.StartingValueMultiple;
            if (regValue <= Band5.EndValue)
                return Band5.StartingValueMultiple;
            if (regValue > Band5.EndValue)
                return Band6.StartingValueMultiple;

            return 0;
        }



        public IBand Band1 { get; set; }
        public IBand Band2 { get; set; }
        public IBand Band3 { get; set; }
        public IBand Band4 { get; set; }
        public IBand Band5 { get; set; }
        public IBand Band6 { get; set; }

    }
}
