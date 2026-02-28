using System;
using VetPrescriptionKiosk.Models;

namespace VetPrescriptionKiosk.Services
{
    public class PrescriptionCalculator
    {
        public Prescription Calculate(float weightKg, int ageWeeks, DogCondition condition)
        {
            // Puppy under 12 weeks: weight not required
            if (condition == DogCondition.Puppy && ageWeeks < 12)
            {
                return CalculatePuppy(new Prescription());
            }

            // For everything else, weight is required
            if (weightKg <= 0)
                throw new ArgumentException("Weight must be greater than zero.");

            if (weightKg > 40)
                throw new InvalidOperationException("Dog may be overweight. Please visit surgery for a check-up.");

            var prescription = new Prescription();

            switch (condition)
            {
                case DogCondition.Puppy:
                    return CalculateNormal(weightKg, prescription);

                case DogCondition.Nursing:
                    return CalculateNursing(weightKg, prescription);

                case DogCondition.Normal:
                default:
                    return CalculateNormal(weightKg, prescription);
            }
        }

        private Prescription CalculateNormal(float weightKg, Prescription prescription)
        {
            prescription.WormerTablets = GetNormalTabletAmount(weightKg);
            return prescription;
        }

        private Prescription CalculatePuppy(Prescription prescription)
        {
            prescription.JuniorTablets = 1;
            return prescription;
        }

        private Prescription CalculateNursing(float weightKg, Prescription prescription)
        {
            int tablets = (int)Math.Ceiling(weightKg / 5.0);

            prescription.NursingTablets = tablets;
            prescription.TapewormDrops = 1;

            return prescription;
        }

        private int GetNormalTabletAmount(float weightKg)
        {
            if (weightKg < 10) return 1;
            if (weightKg < 20) return 2;
            if (weightKg < 25) return 3;
            if (weightKg < 30) return 4;
            if (weightKg < 35) return 5;
            if (weightKg <= 40) return 6;

            throw new InvalidOperationException("Dog may be overweight. Please visit surgery for a check-up.");
        }
    }
}