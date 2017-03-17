using System;

namespace Intepreter.Model.Abstract
{
    public interface IDropable
    {
        Type DataType { get; }

        void Drop(object data, int index = -1);
    }
}
