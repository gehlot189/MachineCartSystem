using System;

namespace MachineCartSystem.Configuration.PolicyMaker
{
    public interface IIdentifiable
    {
        Guid Identifier { get; }
    }
}
