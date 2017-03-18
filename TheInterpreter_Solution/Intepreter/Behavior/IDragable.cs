using System;

namespace Intepreter.Behavior
{
    public interface IDragable
    {
        Type DataType { get; }
        void Drag();
    }
}
