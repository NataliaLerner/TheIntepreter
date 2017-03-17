using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Intepreter.Command;
using Intepreter.ViewModel.Editors;
using Intepreter.ViewModel.Editors.GraphicEditor;
using Intepreter.Service;

using Microsoft.Win32;

using DevExpress.Mvvm.DataAnnotations;

namespace Intepreter.ViewModel
{
    public class MainViewModel :
        DevExpress.Mvvm.ViewModelBase
    {
        public OperationTextEditorViewModel    TextEditor { get; } =    new OperationTextEditorViewModel();
        public SimpleTextEditorViewModel       Output { get; } =        new SimpleTextEditorViewModel();

        public OperationListViewModel Names { get; } = new OperationListViewModel();

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

        
        public void Test1(object args)
        {
            _service.PerformAllFromTextEditor(TextEditor, Output);
        }

       
        public void ClearOutput(object args)
        {
            Output.ClearAll();
        }

        #endregion

        private readonly OperationPerfomerService _service = new OperationPerfomerService();
    }
}
