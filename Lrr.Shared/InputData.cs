using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lrr.Shared
{
    public class InputData : IInputData
    {

        private Action Recalculate;
        public InputData(Action reCalculate)
        {
            WhiteBlackRatio = 60;
            PurchaseValue = 5000000;
            RegistrationDate = DateOnly.FromDateTime(DateTime.Today);
            Recalculate = reCalculate;
        }

        private int _whiteBlackRation = 100;

        [Required]
        [Range(1, 100, ErrorMessage = "WhiteBlackRatio invalid (1-100).")]
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
                if (Recalculate != null) Recalculate();

            }
        }

        private int _purchaseValue = 100;
        [Required]
        public int PurchaseValue
        {
            get;
            set;
        }
        [Required]
        public DateOnly RegistrationDate { get; set; }
        public int HighestBidIndex { get; set; } = -1;
        public DecisionEnum Decision { get; set; } = DecisionEnum.None;
    }
}
