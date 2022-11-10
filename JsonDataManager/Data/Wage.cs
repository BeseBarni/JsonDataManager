namespace JsonDataManager.Data
{
    public class Wage
    {
        public double Gross { get; set; }
        public double Net { get; set; }

        public Wage(double gross, double net)
        {
            Gross = gross;
            Net = net;
        }
    }
}
