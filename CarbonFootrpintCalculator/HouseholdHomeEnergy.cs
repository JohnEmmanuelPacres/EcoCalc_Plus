using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    public enum EnergyType
    {
        NaturalGas,
        FuelOil,
        Propane,
        Electricity,
        None
    }

    public enum UnitType
    {
        Bill,
        CubicFeet,
        Therm,
        Gallons,
        kWh,
        None
    }

    class HouseholdHomeEnergy : HomeEnergyCalculation
    {
        private double input;
        private EnergyType energy;
        private UnitType unit;
        private double NGpricePerCubicFt = 10.68, NGemf = 119.577540412585, NGtherm = 11.68890913124;
        private double pricePerkwh = 13.52, PHElectricity_emf = 1.37, pricePerGallonPropane = 2.47, pricePerGallonFuelOil = 4.02;
        private double Pemf = 12.4260044803915, FOemf = 22.6131018642659, monthsInYear = 12.00;

        public double Input
        {
            get { return this.input; }
            set { this.input = value; }
        }

        public EnergyType Energy
        {
            get { return this.energy; }
            set { this.energy = value; }
        }

        public UnitType Unit
        {
            get { return this.unit; }
            set { this.unit = value; }
        }

        public HouseholdHomeEnergy()
        {
            this.Input = 0;
            this.Energy = EnergyType.None;
            this.Unit = UnitType.None;
        }

        public HouseholdHomeEnergy(EnergyType energyType, UnitType unitType, double input)
        {
            this.Input = input;
            this.Energy = energyType;
            this.Unit = unitType;
        }

        public override double CalculateHE(EnergyType energyType, UnitType unitType, double input)
        {
            if (energyType == EnergyType.None || unitType == UnitType.None)
                return 0; // No emissions if no valid energy/unit is provided

            return energyType switch
            {
                EnergyType.NaturalGas => CalculateNaturalGasEmission(unitType, input),
                EnergyType.FuelOil => CalculateFuelOilEmission(unitType, input),
                EnergyType.Propane => CalculatePropaneEmission(unitType, input),
                EnergyType.Electricity => CalculateElectricityEmission(unitType, input),
                _ => throw new ArgumentException("Invalid energy type.")
            };
        }

        private double CalculateNaturalGasEmission(UnitType unitType, double value)
        {
            if (unitType == UnitType.None)
                return 0;

            return unitType switch
            {
                UnitType.Bill => ((value * 0.017) / NGpricePerCubicFt) * NGemf * monthsInYear,
                UnitType.CubicFeet => value * NGemf * monthsInYear,
                UnitType.Therm => value * NGtherm * monthsInYear,
                _ => throw new ArgumentException("Invalid unit for natural gas.")
            };
        }

        private double CalculateFuelOilEmission(UnitType unitType, double value)
        {
            if (unitType == UnitType.None)
                return 0;

            return unitType switch
            {
                UnitType.Bill => ((value * 0.017) / pricePerGallonFuelOil) * FOemf * monthsInYear,
                UnitType.Gallons => value * FOemf * monthsInYear,
                _ => throw new ArgumentException("Invalid unit for fuel oil.")
            };
        }

        private double CalculatePropaneEmission(UnitType unitType, double value)
        {
            if (unitType == UnitType.None)
                return 0;

            return unitType switch
            {
                UnitType.Bill => ((value * 0.017) / pricePerGallonPropane) * Pemf * monthsInYear,
                UnitType.Gallons => value * Pemf * monthsInYear,
                _ => throw new ArgumentException("Invalid unit for propane.")
            };
        }

        private double CalculateElectricityEmission(UnitType unitType, double value)
        {
            if (unitType == UnitType.None)
                return 0;

            return unitType switch
            {
                UnitType.Bill => ((value * 0.017) / pricePerkwh) * PHElectricity_emf * monthsInYear,
                UnitType.kWh => value * PHElectricity_emf * monthsInYear,
                _ => throw new ArgumentException("Invalid unit for electricity.")
            };
        }
    }
}
