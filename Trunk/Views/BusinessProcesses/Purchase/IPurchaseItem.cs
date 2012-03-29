using System.Runtime.Serialization;

namespace Views.BusinessProcesses.Purchase
{
    public interface IPurchaseItem : ISerializable 
    {
        int PuiId { get; set; }
        int PuiNumber { get; set; }
        int PuiPuhId { get; set; }
        int PuiPrdId { get; set; }
        float Puivat { get; set; }
        float PuiDiscount { get; set; }
    }
}
