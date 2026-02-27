using System;

namespace VetPrescriptionKiosk.Models
{
    public class Prescription
    {
        public int WormerTablets { get; set; }
        public int JuniorTablets { get; set; }
        public int NursingTablets { get; set; }
        public int TapewormDrops { get; set; }

        public decimal TotalCost { get; set; }

        public Guid TransactionId { get; set; } = Guid.NewGuid();
    }
}