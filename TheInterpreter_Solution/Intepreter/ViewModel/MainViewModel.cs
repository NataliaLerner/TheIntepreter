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

namespace Intepreter.ViewModel
{
    class MainViewModel :
        ViewModelBase
    {
        public SimpleTextEditorViewModel Editor { get; } = new SimpleTextEditorViewModel();
        public SimpleTextEditorViewModel Output { get; } = new SimpleTextEditorViewModel();

        public ICommand EditorTextChangedCommand { get; }
        public ICommand TestCommand { get; }
        public ICommand PerformCommand { get; }

        public MainViewModel(OperationPerfomerService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            _service = service;

            EditorTextChangedCommand = new MyCommand(OnEditorTextChangedCommand, canExecute => true);
            PerformCommand = new MyCommand(OnPerformCommand, canExecute => true);
            TestCommand = new MyCommand(OnTestCommand, canExecute => true);
        }

        private void OnEditorTextChangedCommand(object args)
        {
            
        }

        private void OnTestCommand(object args)
        {
            _service.PerformAll(Editor, Output);
        }

        private void OnPerformCommand(object args)
        {
            _service.PerformAll(Editor, Output);
        }

        private readonly OperationPerfomerService _service;
    }
}
