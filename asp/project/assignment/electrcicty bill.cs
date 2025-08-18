using System;

namespace ElectricityBillingProject
{
    public class ElectricityBill
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get { return consumerNumber; }
            set
            {
                if (!value.StartsWith("EB") || value.Length != 7 || !int.TryParse(value.Substring(2), out _))
                {
                    throw new FormatException("Invalid Consumer Number");
                }
                consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get { return consumerName; }
            set { consumerName = value; }
        }

        public int UnitsConsumed
        {
            get { return unitsConsumed; }
            set { unitsConsumed = value; }
        }

        public double BillAmount
        {
            get { return billAmount; }
            set { billAmount = value; }
        }
    }
}
