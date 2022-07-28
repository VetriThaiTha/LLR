namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class ConfigurationModel
    {

        protected internal Dictionary<string, string> _errorMesages = new();
        public bool hasErrorMesages { get { return _errorMesages.Count() > 0; } }
        public void Invalidate()
        {
            _errorMesages.Clear();
            _errorMesages.Add("All", "Invalid state.");
        }
        private double _stampChargePercentage;
        [Required] public double StampChargePercentage { get => _stampChargePercentage; set { _stampChargePercentage = value; Validate(); } }
        private double _RegistrationChargePercentage;
        [Required] public double RegistrationChargePercentage { get => _RegistrationChargePercentage; set { _RegistrationChargePercentage = value; Validate(); } }
        private int _AuctionDuration;
        [Required] public int AuctionDuration { get => _AuctionDuration; set { _AuctionDuration = value; Validate(); } }
        
        private double _GiveUpProvBuyerIncentiveRatio;

        [Required] public double GiveUpProvBuyerIncentiveRatio { get => _GiveUpProvBuyerIncentiveRatio; set { _GiveUpProvBuyerIncentiveRatio = value; Validate(); } }
        private double _GiveUpSellerIncentiveRatio;
        [Required] public double GiveUpSellerIncentiveRatio { get => _GiveUpSellerIncentiveRatio; set { _GiveUpSellerIncentiveRatio = value; Validate(); } }
        private double _Brokerage;
        [Required] public double Brokerage { get => _Brokerage; set { _Brokerage = value; Validate(); } }
        private double _MatchSellerIncentiveRatio;

        [Required] public double MatchSellerIncentiveRatio { get => _MatchSellerIncentiveRatio; set { _MatchSellerIncentiveRatio = value; Validate(); } }
        private double _MatchBidderIncentiveRatio;

        [Required] public double MatchBidderIncentiveRatio { get => _MatchBidderIncentiveRatio; set { _MatchBidderIncentiveRatio = value; Validate(); } }

        public string GetErrorMessage(string property)
        {
            return _errorMesages.TryGetValue(property, out var errorMesages) ?errorMesages:String.Empty;
        }

        public virtual void Validate()
        {
            _errorMesages.Clear();

            if (StampChargePercentage < 0.0)
                _errorMesages.Add("StampChargePercentage", "Stamp charge multiple cannot be less than 0");
            if (StampChargePercentage > 1.0)
                _errorMesages.Add("StampChargePercentage", "Stamp charge multiple cannot be greater than 1.0");

            if (RegistrationChargePercentage < 0.0)
                _errorMesages.Add("RegistrationChargePercentage", "Registration fee multiple cannot be less than 0");
            if (RegistrationChargePercentage > 1.0)
                _errorMesages.Add("RegistrationChargePercentage", "Registration fee multiple cannot be greater than 1.0");

            if (AuctionDuration <= 0)
                _errorMesages.Add("AuctionDuration", "Auction duration cannot be less than equal to 0");
            if (AuctionDuration > 12)
                _errorMesages.Add("AuctionDuration", "Auction duration cannot be greater than 12");

            

            

            if (GiveUpSellerIncentiveRatio < 0.0)
                _errorMesages.Add("GiveUpSellerIncentiveRatio", "Seller's incentive multiple cannot be less than 1.0");
            if (GiveUpSellerIncentiveRatio >= 1.0)
                _errorMesages.Add("GiveUpSellerIncentiveRatio", "Seller's incentive multiple cannot be greater than equal to 1.0");

            if (GiveUpProvBuyerIncentiveRatio < 0.0)
                _errorMesages.Add("GiveUpProvBuyerIncentiveRatio", "Provisional buyer's incentive multiple cannot be less than 1.0");
            if (GiveUpProvBuyerIncentiveRatio >= 1.0)
                _errorMesages.Add("GiveUpProvBuyerIncentiveRatio", "Provisional buyer's incentive multiple cannot be greater than equal to 1.0");

            if (MatchBidderIncentiveRatio < 0.0)
                _errorMesages.Add("MatchBidderIncentiveRatio", "Bidder's incentive multiple cannot be less than 1.0");
            if (MatchBidderIncentiveRatio >= 1.0)
                _errorMesages.Add("MatchBidderIncentiveRatio", "Bidder 's incentive multiple cannot be greater than equal to 1.0");

            if (MatchSellerIncentiveRatio < 0.0)
                _errorMesages.Add("MatchSellerIncentiveRatio", "Seller's incentive multiple cannot be less than 1.0");
            if (MatchSellerIncentiveRatio >= 1.0)
                _errorMesages.Add("MatchSellerIncentiveRatio", "Seller's incentive multiple cannot be greater than equal to 1.0");

            if (Brokerage < 0.0)
                _errorMesages.Add("Brokerage", "Brokerage multiple cannot be less than 1.0");
            if (Brokerage >= 1.0)
                _errorMesages.Add("Brokerage", "Brokerage multiple cannot be greater than equal to 1.0");
        }
    }
}
