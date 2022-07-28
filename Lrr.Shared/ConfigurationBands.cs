namespace Lrr.Shared
{
    public class ConfigurationBands : Configuration, IBandConfiguration
    {
        public ConfigurationBands()
            : base()
        {

        }

        public override double GetStartingValueMultiple(int regValue)
        {
            return 0;
        }

    }
}
