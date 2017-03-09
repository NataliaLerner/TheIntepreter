﻿namespace Intepreter.Model.Abstract
{
    public interface ISimpleTextEditor :
        IEditor
    {
        string Text { get; set; }

        void AppendNum(int num32);
        void AppendLine(string line);
    }
}

//Текстовый редактор с возможностью вывода информации