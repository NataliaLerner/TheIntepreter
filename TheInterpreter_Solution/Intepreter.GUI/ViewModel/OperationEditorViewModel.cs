using System;
using System.IO;

using Intepreter.Core;
using Intepreter.GUI.Model.Abstract;

namespace Intepreter.GUI.ViewModel
{
    public class OperationEditorViewModel :
        SimpleEditorViewModel, IOperationPeformer
    {
        public string FilePath { get; } 

        public OperationEditorViewModel(string path, string initialText) : base(initialText)
        {
            if (File.Exists(path) == false)
            {
                FileStream defaultFile;

                using (defaultFile = File.Create(Path.Combine(Environment.CurrentDirectory, "in.txt")))
                {
                    FilePath = defaultFile.Name;
                }
            }

            FilePath = path;
        }

        public OperationEditorViewModel() : base("")
        {
            FileStream defaultFile;

            using (defaultFile = File.Create(Path.Combine(Environment.CurrentDirectory, "in.txt")))
            {
                FilePath = defaultFile.Name;
            }
        }

        public void WriteToBinaryFile(string path, int num32)
        {
            using (var writer = new BinaryWriter(File.Open(FilePath, FileMode.Append)))
            {
                writer.Write(num32);
            }
        }

        //TODO -  IMPLEMENT THIS
        public bool TryExecuteOperation(int num32, out Tuple<int, string> resultTuple)
        {
            return Operations.TryExecuteOperation(num32, out resultTuple);
        }

        //TODO -  IMPLEMENT THIS
        public int TryExecuteOperation(int num32)
        {
            throw new NotImplementedException();
        }
    }
}