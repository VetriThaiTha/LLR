namespace Lrr.Shared
{
    public class ConfigurationCurve: Configuration, ICurveConfiguration
    {
        public ConfigurationCurve()
            : base()
        {

        }

        public override double GetStartingValueMultiple(int regValue)
        {
            return 0;
        }

    }
}
