namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lrr.Shared;
    public class SimpleConfigurationModel : ConfigurationModel
    {
        private double _StartingValueMultiple;
        [Required] public double StartingValueMultiple { get => _StartingValueMultiple; set { _StartingValueMultiple = value; Validate(); } }

        public override void Validate()
        {
            base.Validate();
            if (StartingValueMultiple < 1.0)
                _errorMesages.Add("StartingValueMultiple", "Auction starting value multiple cannot be less than 1.0");
            if (StartingValueMultiple > 10.0)
                _errorMesages.Add("StartingValueMultiple", "Auction starting value multiple cannot be greater than 10.0");
        }
    }
}
