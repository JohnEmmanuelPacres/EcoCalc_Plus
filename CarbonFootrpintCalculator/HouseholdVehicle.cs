using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    public enum EmissionPeriod
    {
        Weekly,
        Monthly,
        Yearly
    }

    class HouseholdVehicle : HouseholdVehicleCalculation
    {
        private double miles;
        private double GHGratio = 1.0136847440446, emissionFactor = 19.4,
            fuelEfficiency = 27.5; //2024 update https://www.iseecars.com/green-car-adoption-study
        public double Miles
        {
            get { return this.miles; }
            set { this.miles = value; }
        }

        public HouseholdVehicle()
        {
            this.Miles = 0;
        }

        public HouseholdVehicle(double Miles)
        {
            this.Miles = Miles;
        }

        public override double CalculateHV(double miles, EmissionPeriod period)
        {
            double emissions;
            if (period == EmissionPeriod.Weekly)
            {
                double weeksInYear = 52;
                emissions = ((miles * weeksInYear) / fuelEfficiency) * emissionFactor * GHGratio;
            }
            else if (period == EmissionPeriod.Monthly)
            {
                double weeksInMonth = 4.33; // Approximate weeks per month
                emissions = ((miles * weeksInMonth) / fuelEfficiency) * emissionFactor * GHGratio;
            }
            else // Yearly
            {
                emissions = (miles / fuelEfficiency) * emissionFactor * GHGratio;
            }
            return emissions;
        }
    }
}
