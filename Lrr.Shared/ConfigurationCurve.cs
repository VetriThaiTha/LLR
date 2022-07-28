namespace Lrr.Shared
{

    public class CurvePoint : ICurvePoint
    {
        public int Value { get; set; }
        public double StartingValueMultiple { get; set; }
    }
    public class ConfigurationCurve: Configuration, ICurveConfiguration
    {
        public ConfigurationCurve()
            : base()
        {
            Point1 = new CurvePoint { Value = 0, StartingValueMultiple = 5};
            Point2 = new CurvePoint { Value = FormattingHelper.lakh, StartingValueMultiple = 3 };
            Point3 = new CurvePoint { Value = FormattingHelper.lakh*10, StartingValueMultiple = 2 };
            Point4 = new CurvePoint { Value = FormattingHelper.lakh*25, StartingValueMultiple = 1.5 };
            Point5 = new CurvePoint { Value = FormattingHelper.crore, StartingValueMultiple = 1.5 };
            Point6 = new CurvePoint { Value = FormattingHelper.hunderedCrore, StartingValueMultiple = 1.25 };
            Point7 = new CurvePoint { Value = int.MaxValue, StartingValueMultiple = 1.2 };
        }

        public override double GetStartingValueMultiple(int regValue)
        {
            if (regValue <= Point1.Value)
                return Point1.StartingValueMultiple;

            if (regValue <= Point2.Value)
                return Interpolate(Point1, Point2, regValue);

            if (regValue <= Point3.Value)
                return Interpolate(Point2, Point3, regValue);

            if (regValue <= Point4.Value)
                return Interpolate(Point3, Point4, regValue);

            if (regValue <= Point5.Value)
                return Interpolate(Point4, Point5, regValue);

            if (regValue <= Point6.Value)
                return Interpolate(Point5, Point6, regValue);

            return Interpolate(Point6, Point7, regValue);
        }

        public double Interpolate(ICurvePoint p1, ICurvePoint p2, int val)
        {
            if (p1.Value == val)
                return p1.StartingValueMultiple;

            if (p2.Value == val)
                return p2.StartingValueMultiple;

            if (Math.Abs(p1.StartingValueMultiple - p2.StartingValueMultiple) < 0.01)
                return p1.StartingValueMultiple;
            
            if (!((p1.Value < val) && (p2.Value > val)))
                return 0;

            double ratio = ( (double) (val - p1.Value)) / ((double)(p2.Value - p1.Value));

            double range = p2.StartingValueMultiple - p1.StartingValueMultiple;

            if(range > 0)
                return p1.StartingValueMultiple + (ratio * range) ;

            return p2.StartingValueMultiple + ( Math.Abs( range ) * (1.0- ratio));

        }

        public ICurvePoint Point1 { get; set; }
        public ICurvePoint Point2 { get; set; }
        public ICurvePoint Point3 { get; set; }
        public ICurvePoint Point4 { get; set; }
        public ICurvePoint Point5 { get; set; }
        public ICurvePoint Point6 { get; set; }
        public ICurvePoint Point7 { get; set; }
    }
}
