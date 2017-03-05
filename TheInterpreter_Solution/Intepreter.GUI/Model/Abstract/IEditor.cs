namespace Intepreter.GUI.Model.Abstract
{
    public interface IEditor
    {
        string Text { get; set; }

        void AppendText(string text);
    }
}