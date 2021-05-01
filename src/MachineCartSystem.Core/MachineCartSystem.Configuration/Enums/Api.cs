using System.ComponentModel;

namespace MachineCartSystem.Configuration
{
    public enum ApiName
    {
        [Description("Gateway Api")]
        Gateway,
        [Description("Identity Server")]
        Identity,
        [Description("Basket Api")]
        Basket,
        [Description("Order Api")]
        Order,
        [Description("Catalog Api")]
        Catalog
    }
}
