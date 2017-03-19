using System;
using System.Windows;

using Intepreter.ViewModel.Editors;
using Intepreter.Service;
using Intepreter.Controls.GraphicOperationBuilder;
using Intepreter.Controls.TextOperationEditor;

using Microsoft.Win32;

using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;


namespace Intepreter.ViewModel
{
    public class MainViewModel :
        ViewModelBase
    {
        public TextOperationEditorViewModel TextEditor { get; } =       new TextOperationEditorViewModel();
        public SimpleTextEditorViewModel    Output { get; } =           new SimpleTextEditorViewModel();
        public GraphicOperationBuilderViewModel GraphicBuilder { get; } = new GraphicOperationBuilderViewModel();

        public MainViewModel()
        { }

        #region Commands

        [Command]
        public void Test(object args)
        {
            MessageBox.Show("Ok");
        }


        [Command]
        public void Perform(object args)
        {
            _service.PerformAllFromTextEditor(TextEditor, Output);
        }


        [Command]
        public void SaveAllToBinaryFile(object args)
        {
            _service.SaveAllToBinaryFile(TextEditor, Output);
        }

       [Command]
        public void LoadAllFromBinaryFile(object args)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = "Бинарный файл(*.BIN)|*.BIN",
                CheckFileExists = true
            };

            if (openDlg.ShowDialog() == true)
            {
                //_service.LoadAllFromBinaryFile_Test(TextEditor, GraphicEditor, Output, openDlg.FileName);
                _service.LoadAllFromBinaryFile(TextEditor, Output, openDlg.FileName);
            }
        }

        [Command]
        public void ClearOutput(object args)
        {
            Output.ClearAll();
        }

        #endregion

        private readonly OperationPerfomerService _service = new OperationPerfomerService();
    }
}
