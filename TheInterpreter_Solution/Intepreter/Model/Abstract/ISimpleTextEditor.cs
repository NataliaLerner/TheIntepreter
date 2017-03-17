namespace Intepreter.Model.Abstract
{
    public interface ISimpleTextEditor
    {
        string Text { get; set; }

        void AppendNum(int num32);
        void AppendLine(string line);
        void ClearAll();
    }
}

//Текстовый редактор с возможностью вывода информации