using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class FormattingHelper
    {
        const int thousand = 1000;
        const int lakh = thousand * 100;
        const int crore = lakh * 100;
        const int hunderedCrore = crore * 100;

        public string ShortFormat(int value)
        {
                

                if (value < lakh)
                    return string.Empty;
                var cVal = value / crore;
                var lVal = (value / lakh) % 100;

                var rtnVal = $"{lVal} lakh(s).";

                if (value >= crore)
                {

                    rtnVal = $"{cVal} crore(s) {rtnVal}";
                }
                return $"₹{rtnVal}";


        }

        public string CommaSeperatedValue(int value)
        {
            return FormattingHelper.CommaSeperated(value);
        }

        public static string CommaSeperated(int val)
        {
            if (val < thousand)
                return val.ToString("##0");

            if (val < lakh)
                return val.ToString("##\\,##0");
            if (val < crore)
                return val.ToString("##\\,##\\,##0");
            if (val < hunderedCrore)
                return val.ToString("##\\,##\\,##\\,##0");

            return val.ToString("##\\,##\\,##\\,##\\,##0");
        }
    }
}
