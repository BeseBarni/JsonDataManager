namespace JsonDataManager.Data
{
    public class Wage
    {
        public double Gross { get; set; }
        public double Net { get { return Gross * 0.665; } }
        public double TaxKey { get; set; }

        public Wage(double gross, double taxKey)
        {
            Gross = gross;
            TaxKey = taxKey;
        }
    }
}
