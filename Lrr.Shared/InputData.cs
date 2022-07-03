using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class InputData : IInputData
    {
        public InputData()
        {
            WhiteBlackRatio = 60;
            PurchaseValue = 5000000;
            RegistrationDate = DateOnly.FromDateTime(DateTime.Today) ;

        }

        private int _whiteBlackRation = 100;
        public int WhiteBlackRatio
        {
            get
            { return _whiteBlackRation; }
            set
            {
                if (value <= 1)
                    _whiteBlackRation = 1;
                else if (value >= 100)
                    _whiteBlackRation = 100;
                else
                    _whiteBlackRation = value;
            }
        }
        public int PurchaseValue { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public int HighestBidValue { get; set; }
        public DecisionEnum Decision { get; set; }
    }
}
