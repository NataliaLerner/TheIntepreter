using System;

namespace Intepreter.Behavior
{
    public interface IDropable
    {
        Type DataType { get; }

        void Drop(object data, int index = -1);
    }
}
