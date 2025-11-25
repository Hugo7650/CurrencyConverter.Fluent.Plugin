using Blast.Core.Interfaces;
using Blast.Core.Objects;
using Blast.Core.Results;

namespace CurrencyConverter.Fluent.Plugin
{
    public sealed class CurrencyConversionSearchResult : SearchResultBase
    {
        public CurrencyConversionSearchResult(double amount, string fromCurrency, string toCurrency, 
            double convertedAmount, string searchAppName, string resultName, string searchedText,
            string resultType, double score, IList<ISearchOperation> supportedOperations, 
            ICollection<SearchTag> tags, ProcessInfo? processInfo = null) : base(searchAppName,
            resultName, searchedText, resultType, score, supportedOperations, tags, processInfo)
        {
            Amount = amount;
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            ConvertedAmount = convertedAmount;
            
            // Machine Learning features for search predictions
            MlFeatures = new Dictionary<string, string>
            {
                ["FromCurrency"] = FromCurrency,
                ["ToCurrency"] = ToCurrency,
                ["ConvertedAmount"] = ConvertedAmount.ToString("F2")
            };
        }

        public double Amount { get; }
        public string FromCurrency { get; }
        public string ToCurrency { get; }
        public double ConvertedAmount { get; }
        public string ResultDescription { get; set; }

        protected override void OnSelectedSearchResultChanged()
        {
            // Leave this method empty for now.
        }
    }
}