using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    class HouseholdAppliances : HouseholdAppliancesCalculation
    {
        private Dictionary<string, double> embodiedEmissions = new Dictionary<string, double>
        {
            { "Smartphone", 50 },
            { "Feature Phone", 20 },
            { "Tablet", 100 },
            { "Laptop", 200 },
            { "Desktop PC", 350 },
            { "PC Display", 100 },
            { "CPE", 30 },
            { "Television", 150 },
            { "Air Conditioner", 300 },
            { "Electric Fan", 20 },
            { "Washing Machine", 250 },
            { "Heater", 400 },
            { "Refrigerator", 200 }
        };

        private Dictionary<string, double> defaultPowerConsumption = new Dictionary<string, double>
        {
            { "Smartphone", 5 },
            { "Feature Phone", 3 },
            { "Tablet", 10 },
            { "Laptop", 50 },
            { "Desktop PC", 100 },
            { "PC Display", 30 },
            { "CPE", 10 },
            { "Television", 100 },
            { "Air Conditioner", 1500 },
            { "Electric Fan", 50 },
            { "Washing Machine", 500 },
            { "Heater", 1500 },
            { "Refrigerator", 150 }
        };

        public override double CalculateCarbonFootprint(string deviceType, int numberOfDevices, double powerConsumption, double usageTime, string timePeriod)
        {
            // Use default power consumption if the user leaves it blank
            if (powerConsumption == 0)
            {
                powerConsumption = defaultPowerConsumption[deviceType];
            }

            // Calculate time period factor
            int timePeriodFactor = GetTimePeriodFactor(timePeriod);

            // Calculate energy consumption (kWh)
            double energyConsumption = (powerConsumption * usageTime * timePeriodFactor) / 1000;

            // Get embodied emissions
            double embodiedEmission = embodiedEmissions[deviceType];

            // Calculate total carbon footprint
            double carbonFootprint = (numberOfDevices * embodiedEmission) + (energyConsumption * 0.5); // 0.5 kg CO₂/kWh is the carbon intensity

            return carbonFootprint;
        }

        private int GetTimePeriodFactor(string timePeriod)
        {
            switch (timePeriod)
            {
                case "Per Day": return 365;
                case "Per Week": return 52;
                case "Per Month": return 12;
                case "Per Year": return 1;
                default: return 365;
            }
        }

        // Method to get the list of devices
        public List<string> GetDeviceList()
        {
            return embodiedEmissions.Keys.ToList();
        }

        // Method to get default power consumption for a device
        public override double GetDefaultPowerConsumption(string deviceType)
        {
            if (defaultPowerConsumption.ContainsKey(deviceType))
            {
                return defaultPowerConsumption[deviceType];
            }
            else
            {
                throw new ArgumentException($"Device type '{deviceType}' not found in default power consumption dictionary.");
            }
        }
    }
}
