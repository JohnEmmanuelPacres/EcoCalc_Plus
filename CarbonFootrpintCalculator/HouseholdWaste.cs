using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    public interface IWasteCalculator
    {
        double CalculateWasteEmission(int houseMembers, RecyclingOptions recyclingOptions);
        double GetAverageWastePerPerson();
        double GetPotentialSavings(RecyclingOptions options);

    }
    public struct RecyclingOptions
    {
        public bool RecyclesMetal { get; set; }
        public bool RecyclesPlastic { get; set; }
        public bool RecyclesGlass { get; set; }
        public bool RecyclesNewspaper { get; set; }
        public bool RecyclesMagazine { get; set; }
    }

    public class HouseholdWasteCalculator : IWasteCalculator
    {
        private const double AverageWastePerPersonPerYear = 691.5; 
        private const double MetalRecyclingReduction = 89.38;      
        private const double PlasticRecyclingReduction = 35.56;    
        private const double GlassRecyclingReduction = 25.39;      
        private const double NewspaperRecyclingReduction = 113.14; 
        private const double MagazineRecyclingReduction = 27.46;   

        public double CalculateWasteEmission(int houseMembers, RecyclingOptions recyclingOptions)
        {
            ValidateHouseMembers(houseMembers);

            double emission = houseMembers * AverageWastePerPersonPerYear;

            if (recyclingOptions.RecyclesMetal)
                emission -= houseMembers * MetalRecyclingReduction;

            if (recyclingOptions.RecyclesPlastic)
                emission -= houseMembers * PlasticRecyclingReduction;

            if (recyclingOptions.RecyclesGlass)
                emission -= houseMembers * GlassRecyclingReduction;

            if (recyclingOptions.RecyclesNewspaper)
                emission -= houseMembers * NewspaperRecyclingReduction;

            if (recyclingOptions.RecyclesMagazine)
                emission -= houseMembers * MagazineRecyclingReduction;
            return Math.Max(0, emission);
        }
        private void ValidateHouseMembers(int houseMembers)
        {
            if (houseMembers <= 0)
                throw new ArgumentException("Household members must be a positive number", nameof(houseMembers));
        }
        public double GetAverageWastePerPerson()
        {
            return AverageWastePerPersonPerYear;
        }

        public double GetPotentialSavings(RecyclingOptions options)
        {
            double totalSavings = 0;

            if (options.RecyclesMetal) totalSavings += MetalRecyclingReduction;
            if (options.RecyclesPlastic) totalSavings += PlasticRecyclingReduction;
            if (options.RecyclesGlass) totalSavings += GlassRecyclingReduction;
            if (options.RecyclesNewspaper) totalSavings += NewspaperRecyclingReduction;
            if (options.RecyclesMagazine) totalSavings += MagazineRecyclingReduction;

            return totalSavings;
        }
    }
}
