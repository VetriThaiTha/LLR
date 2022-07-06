using System.ComponentModel.DataAnnotations;
using Lrr.Shared;

namespace Lrr.Models
{

    public class RegistrationInputModel
    {
        private LrrState _state;
        private Action _refreshAction;

        [Range(typeof(int), "-51", "106",
            ErrorMessage =
            "Enter a valid Celsius range (-51 to 106).")]
        public int? TemperatureC { get; set; }

        [Range(typeof(int), "1", "100" , ErrorMessage = "WhiteBlackRatio invalid (1-100).")]
        public int WhiteBlackRatio
        {
            get { return _state.InputData.WhiteBlackRatio; }
            set
            {
                
                if (value <= 0 | value > 100)
                    return;

                if (_state.InputData.WhiteBlackRatio != value)
                {
                    _state.InputData.WhiteBlackRatio = value;
                    _refreshAction();
                }
            }
        }

        
        [Range (1, int.MaxValue, ErrorMessage ="Positive integer expected")]
        [Required]
        public int PurchaseValue
        {
            get { return _state.InputData.PurchaseValue; }
            set
            {
                if (value < 1)
                    return;
                if (_state.InputData.PurchaseValue != value)
                {
                    _state.InputData.PurchaseValue = value;
                    _refreshAction();
                }
            }
        }

        public void updateState(LrrState lrrState, Action refreshAction)
        {
            _state = lrrState;
            _refreshAction = refreshAction;

        }


    }
}
