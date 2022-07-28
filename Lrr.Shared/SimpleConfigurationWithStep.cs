namespace Lrr.Shared
{
    public class SimpleConfigurationWithStep :SimpleConfiguration, IConfiguration, ISimpleConfigurationWithStep
    {
        public SimpleConfigurationWithStep()
            :base()
        {
            StepValueMultiple = 0.02;
        }
        public double StepValueMultiple { get; set; }
    }
}
