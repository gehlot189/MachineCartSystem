using MachineCartSystem.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway
{
    public abstract class GatewayBaseController<T> : BaseController<T> where T : BaseController<T>
    {

    }
}
