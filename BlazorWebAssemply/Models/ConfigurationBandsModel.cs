namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lrr.Shared;
    public class ConfigurationBandsModel : ConfigurationModel
    {
        private int _band1EndValue;
        [Required] public int Band1EndValue { get => _band1EndValue; set { _band1EndValue = value; Validate(); } }
        private double _band1StartingValueMultiple;
        [Required] public double Band1StartingValueMultiple { get => _band1StartingValueMultiple; set { _band1StartingValueMultiple = value; Validate(); } }

        private int _band2EndValue;
        [Required] public int Band2EndValue { get => _band2EndValue; set { _band2EndValue = value; Validate();} }
        private double _band2StartingValueMultiple;
        [Required] public double Band2StartingValueMultiple { get => _band2StartingValueMultiple; set { _band2StartingValueMultiple = value; Validate(); } }

        private int _band3EndValue;
        [Required] public int Band3EndValue { get => _band3EndValue; set { _band3EndValue = value; Validate(); } }
        private double _band3StartingValueMultiple;
        [Required] public double Band3StartingValueMultiple { get => _band3StartingValueMultiple; set { _band3StartingValueMultiple = value; Validate(); } }

        private int _band4EndValue;
        [Required] public int Band4EndValue { get => _band4EndValue; set { _band4EndValue = value; Validate(); } }
        private double _band4StartingValueMultiple;
        [Required] public double Band4StartingValueMultiple { get => _band4StartingValueMultiple; set { _band4StartingValueMultiple = value; Validate(); } }

        private int _band5EndValue;
        [Required] public int Band5EndValue { get => _band5EndValue; set { _band5EndValue = value; Validate(); } }
        private double _band5StartingValueMultiple;
        [Required] public double Band5StartingValueMultiple { get => _band5StartingValueMultiple; set { _band5StartingValueMultiple = value; Validate(); } }


        private int _band6EndValue;
        [Required] public int Band6EndValue { get => _band6EndValue; set { _band6EndValue = value; Validate(); } }
        private double _band6StartingValueMultiple;
        [Required] public double Band6StartingValueMultiple { get => _band6StartingValueMultiple; set { _band6StartingValueMultiple = value; Validate(); } }

        public override void Validate()
        {
            base.Validate();

            if (Band1EndValue < 0)
                _errorMesages.Add("Band1EndValue", "Band1 end value cannot be less than 0");
            if (Band2EndValue <= Band1EndValue)
                _errorMesages.Add("Band2EndValue", $"Band2 end value cannot be less than { FormattingHelper.CommaSeperated(Band1EndValue)}");
            if (Band3EndValue <= Band2EndValue)
                _errorMesages.Add("Band3EndValue", $"Band3 end value cannot be less than {FormattingHelper.CommaSeperated(Band2EndValue)}");
            if (Band4EndValue <= Band3EndValue)
                _errorMesages.Add("Band4EndValue", $"Band4 end value cannot be less than {FormattingHelper.CommaSeperated(Band3EndValue)}");
            if (Band5EndValue <= Band4EndValue)
                _errorMesages.Add("Band5EndValue", $"Band5 end value cannot be less than {FormattingHelper.CommaSeperated(Band4EndValue)}");
            if (Band6EndValue <= Band5EndValue)
                _errorMesages.Add("Band6EndValue", $"Band6 end value cannot be less than {FormattingHelper.CommaSeperated(Band5EndValue)}");

            if (Band1StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band1StartingValueMultiple", "Band1 Starting value Multiple cannot be less than equal to 1.0");
            if (Band2StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band2StartingValueMultiple", "Band2 starting value multiple cannot be less than equal to 1.0");
            if (Band3StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band3StartingValueMultiple", "Band3 starting value multiple cannot be less than equal to 1.0");
            if (Band4StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band4StartingValueMultiple", "Band4 starting value multiple cannot be less than equal to 1.0");
            if (Band5StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band5StartingValueMultiple", "Band5 starting value multiple cannot be less than equal to 1.0");
            if (Band6StartingValueMultiple <= 1.0)
                _errorMesages.Add("Band6StartingValueMultiple", "Band6 starting value multiple cannot be less than equal to 1.0");

        }

    }
}
