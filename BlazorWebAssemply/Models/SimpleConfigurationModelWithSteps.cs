namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SimpleConfigurationModelWithSteps:SimpleConfigurationModel
    {
        private double _StepValueMultiple;
        [Required] public double StepValueMultiple { get => _StepValueMultiple; set { _StepValueMultiple = value; Validate(); } }

        public override void Validate()
        {
            base.Validate();

            if (StepValueMultiple < 0.01)
                _errorMesages.Add("StepValueMultiple", "Auction step value multiple cannot be less than 0.01");
            if (StepValueMultiple >= 1.0)
                _errorMesages.Add("StepValueMultiple", "Auction step value multiple cannot be greater than equal to 1.0");
        }
    }
}
