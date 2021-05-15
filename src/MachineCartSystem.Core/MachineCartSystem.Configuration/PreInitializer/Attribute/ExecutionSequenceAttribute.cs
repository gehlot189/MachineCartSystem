using System;
using System.Collections.Generic;

namespace MachineCartSystem.Configuration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExecutionSequence : Attribute
    {
        private List<string> _names = new List<string> { nameof(MiddlewareCommon) };

        public ExecutionSequence(params string[] name)
        {
            _names.AddRange(name);
        }

        public List<string> Sequence => _names;
    }
}
