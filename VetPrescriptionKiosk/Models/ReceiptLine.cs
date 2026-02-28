
// Models/ReceiptLine.cs
namespace VetPrescriptionKiosk.Models
{
    public class ReceiptLine
    {
        public string Description { get; init; } = "";
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal LineTotal => Quantity * UnitPrice;
    }
}