// Models/Prescription.cs
using System;
using System.Collections.Generic;
using System.Linq;
using VetPrescriptionKiosk.Helpers;

namespace VetPrescriptionKiosk.Models
{
    public class Prescription
    {
        public int WormerTablets { get; set; }
        public int JuniorTablets { get; set; }
        public int NursingTablets { get; set; }
        public int TapewormDrops { get; set; }

        public Guid TransactionId { get; set; } = Guid.NewGuid();

        public IReadOnlyList<ReceiptLine> Lines
        {
            get
            {
                var lines = new List<ReceiptLine>();

                if (WormerTablets > 0)
                    lines.Add(new ReceiptLine { Description = "Promax Wormer Tablet", Quantity = WormerTablets, UnitPrice = Constants.WormerTabletPrice });

                if (JuniorTablets > 0)
                    lines.Add(new ReceiptLine { Description = "Promax Junior Tablet", Quantity = JuniorTablets, UnitPrice = Constants.JuniorTabletPrice });

                if (NursingTablets > 0)
                    lines.Add(new ReceiptLine { Description = "Promax Nursing Tablet", Quantity = NursingTablets, UnitPrice = Constants.NursingTabletPrice });

                if (TapewormDrops > 0)
                    lines.Add(new ReceiptLine { Description = "Tapeworm Drop", Quantity = TapewormDrops, UnitPrice = Constants.TapewormDropPrice });

                // Prescription fee always shown when a prescription exists
                lines.Add(new ReceiptLine { Description = "Prescription Fee", Quantity = 1, UnitPrice = Constants.PrescriptionFee });

                return lines;
            }
        }

        public decimal TotalCost => Lines.Sum(l => l.LineTotal);
    }
}