namespace CurrencyConverter.Fluent.Plugin
{
    public class CurrencyItem
    {
        public bool IsEnabled { get; set; } = true;
        public required string Code { get; init; }

        private bool Equals(CurrencyItem other)
        {
            return Code == other.Code && IsEnabled == other.IsEnabled;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CurrencyItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
