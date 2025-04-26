using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    public abstract class CarbonFootprintCalculator
    {
        public abstract string CalculationType { get; }
        public abstract double Calculate();
    }

    public abstract class HouseholdVehicleCalculation : CarbonFootprintCalculator
    {
        public override string CalculationType => "Household Vehicle";
        public abstract double CalculateHV(double Miles, EmissionPeriod period);

        public override double Calculate()
        {
            throw new NotImplementedException("Use CalculateHV with specific parameters for vehicle calculations");
        }
    }

    public abstract class HomeEnergyCalculation : CarbonFootprintCalculator
    {
        public override string CalculationType => "Home Energy";
        public abstract double CalculateHE(EnergyType energyType, UnitType unitType, double input);

        public override double Calculate()
        {
            throw new NotImplementedException("Use CalculateHE with specific parameters for energy calculations");
        }
    }

    public abstract class HouseholdAppliancesCalculation : CarbonFootprintCalculator
    {
        public override string CalculationType => "Household Appliances";
        public abstract double CalculateCarbonFootprint(string deviceType, int numberOfDevices,
            double powerConsumption, double usageTime, string timePeriod);
        public abstract double GetDefaultPowerConsumption(string deviceType);

        public override double Calculate()
        {
            throw new NotImplementedException("Use CalculateCarbonFootprint with specific parameters for appliance calculations");
        }
    }
}
