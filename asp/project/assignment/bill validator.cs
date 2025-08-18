
using System;

namespace ElectricityBillingProject
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            if (unitsConsumed < 0)
            {
                return "Given units is invalid";
            }
            return null; // Valid
        }
    }
}
