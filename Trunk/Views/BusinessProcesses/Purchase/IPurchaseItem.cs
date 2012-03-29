using System.Runtime.Serialization;

namespace Views.BusinessProcesses.Purchase
{
    public interface IPurchaseItem : ISerializable 
    {
        int PuiId { get; set; }
        int? PuiNumber { get; set; }
        int? PuiPuhId { get; set; }
        int? PuiPrdId { get; set; }
        double? Puivat { get; set; }
        double? PuiDiscount { get; set; }
    }
}
