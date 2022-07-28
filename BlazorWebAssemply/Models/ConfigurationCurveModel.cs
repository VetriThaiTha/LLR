namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lrr.Shared;
    public class ConfigurationCurveModel : ConfigurationModel
    {
        private int _point1Value;
        [Required] public int Point1Value { get => _point1Value; set { _point1Value = value; Validate(); } }
        private double _point1StartingValueMultiple;
        [Required] public double Point1StartingValueMultiple { get => _point1StartingValueMultiple; set { _point1StartingValueMultiple = value; Validate(); } }

        private int _point2Value;
        [Required] public int Point2Value { get => _point2Value; set { _point2Value = value; Validate(); } }
        private double _point2StartingValueMultiple;
        [Required] public double Point2StartingValueMultiple { get => _point2StartingValueMultiple; set { _point2StartingValueMultiple = value; Validate(); } }

        private int _point3Value;
        [Required] public int Point3Value { get => _point3Value; set { _point3Value = value; Validate(); } }
        private double _point3StartingValueMultiple;
        [Required] public double Point3StartingValueMultiple { get => _point3StartingValueMultiple; set { _point3StartingValueMultiple = value; Validate(); } }

        private int _point4Value;
        [Required] public int Point4Value { get => _point4Value; set { _point4Value = value; Validate(); } }
        private double _point4StartingValueMultiple;
        [Required] public double Point4StartingValueMultiple { get => _point4StartingValueMultiple; set { _point4StartingValueMultiple = value; Validate(); } }

        private int _point5Value;
        [Required] public int Point5Value { get => _point5Value; set { _point5Value = value; Validate(); } }
        private double _point5StartingValueMultiple;
        [Required] public double Point5StartingValueMultiple { get => _point5StartingValueMultiple; set { _point5StartingValueMultiple = value; Validate(); } }

        private int _point6Value;
        [Required] public int Point6Value { get => _point6Value; set { _point6Value = value; Validate(); } }
        private double _point6StartingValueMultiple;
        [Required] public double Point6StartingValueMultiple { get => _point6StartingValueMultiple; set { _point6StartingValueMultiple = value; Validate(); } }

        private int _point7Value;
        [Required] public int Point7Value { get => _point7Value; set { _point7Value = value; Validate(); } }
        private double _point7StartingValueMultiple;
        [Required] public double Point7StartingValueMultiple { get => _point7StartingValueMultiple; set { _point7StartingValueMultiple = value; Validate(); } }

        public override void Validate()
        {
            base.Validate();

            if(Point1Value < 0)
                _errorMesages.Add("Point1Value", "Point1 value cannot be less than 0");
            if (Point2Value <= Point1Value)
                _errorMesages.Add("Point2Value", $"Point2 value cannot be less than { FormattingHelper.CommaSeperated(Point1Value)}");
            if (Point3Value <= Point2Value)
                _errorMesages.Add("Point3Value", $"Point3 value cannot be less than { FormattingHelper.CommaSeperated(Point2Value)}");
            if (Point4Value <= Point3Value)
                _errorMesages.Add("Point4Value", $"Point4 value cannot be less than { FormattingHelper.CommaSeperated(Point3Value)}");
            if (Point5Value <= Point4Value)
                _errorMesages.Add("Point5Value", $"Point5 value cannot be less than { FormattingHelper.CommaSeperated(Point4Value)}");
            if (Point6Value <= Point5Value)
                _errorMesages.Add("Point6Value", $"Point6 value cannot be less than { FormattingHelper.CommaSeperated(Point5Value)}");
            if (Point7Value <= Point6Value)
                _errorMesages.Add("Point7Value", $"Point7 value cannot be less than { FormattingHelper.CommaSeperated(Point6Value)}");


            if (Point1StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point1StartingValueMultiple", "Point1 Starting value Multiple cannot be less than equal to 1.0");
            if (Point2StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point2StartingValueMultiple", "Point2 Starting value Multiple cannot be less than equal to 1.0");
            if (Point3StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point3StartingValueMultiple", "Point3 Starting value Multiple cannot be less than equal to 1.0");
            if (Point4StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point4StartingValueMultiple", "Point4 Starting value Multiple cannot be less than equal to 1.0");
            if (Point5StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point5StartingValueMultiple", "Point5 Starting value Multiple cannot be less than equal to 1.0");
            if (Point6StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point6StartingValueMultiple", "Point6 Starting value Multiple cannot be less than equal to 1.0");
            if (Point7StartingValueMultiple <= 1.0)
                _errorMesages.Add("Point7StartingValueMultiple", "Point7 Starting value Multiple cannot be less than equal to 1.0");
        }
    }
}
