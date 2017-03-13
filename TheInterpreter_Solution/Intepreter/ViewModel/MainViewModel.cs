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
using Intepreter.Service;
using Microsoft.Win32;

namespace Intepreter.ViewModel
{
    class MainViewModel :
        ViewModelBase
    {
        public SimpleTextEditorViewModel Editor { get; } = new SimpleTextEditorViewModel();
        public SimpleTextEditorViewModel Output { get; } = new SimpleTextEditorViewModel();

        #region Commands

        public ICommand EditorTextChangedCommand { get; }
        public ICommand PerformCommand { get; }
        public ICommand SaveAllToBinaryFileCommand { get; }
        public ICommand LoadAllFromBinaryFileCommand { get; }
        public ICommand TestCommand { get; }

        #endregion

        public MainViewModel(OperationPerfomerService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            _service = service;

            EditorTextChangedCommand = new MyCommand(OnEditorTextChangedCommand, canExecute => true);
            PerformCommand = new MyCommand(OnPerformCommand, canExecute => true);
            SaveAllToBinaryFileCommand = new MyCommand(OnSaveAllToBinaryFileCommand, canExecute => true);
            LoadAllFromBinaryFileCommand = new MyCommand(OnLoadAllFromBinaryFileCommand, canExecute => true);
            TestCommand = new MyCommand(OnTestCommand, canExecute => true);
        }



        #region Command Methods

        private void OnEditorTextChangedCommand(object args)
        {

        }

        private void OnPerformCommand(object args)
        {
            _service.PerformAll(Editor, Output);
        }

        private void OnSaveAllToBinaryFileCommand(object args)
        {
            _service.SaveAllToBinaryFile(Editor, Output);
        }

        private void OnLoadAllFromBinaryFileCommand(object args)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = "Бинарный файл(*.BIN)|*.BIN",
                CheckFileExists = true
            };

            if (openDlg.ShowDialog() == true)
            {
                _service.LoadAllFromBinaryFile(Editor, Output, openDlg.FileName);
            }
        }

        private void OnTestCommand(object args)
        {
            _service.PerformAll(Editor, Output);
        }


        #endregion

        private readonly OperationPerfomerService _service;
    }
}
