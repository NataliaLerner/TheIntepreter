using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Intepreter.Model.Abstract;
using Intepreter.Model.Operations;
using Intepreter.ViewModel.Editors;

namespace Intepreter.Service
{
    public class OperationPerfomerService
    {
        public OperationPerfomerService()
        {
            _settings = new XmlReaderSettings();
            _settings.Schemas.Add("",
                @"E:\Git\TheIntepreter\TheInterpreter_Solution\Intepreter\Model\IntepreterSchema.xsd");
            _settings.ValidationType = ValidationType.Schema;

            _fileName = "default.bin";
        }

        //В планах
        public void SyncEditorWithOutput(SimpleTextEditorViewModel editor, SimpleTextEditorViewModel output)
        {
            if (editor == null)
            {
                throw new ArgumentNullException(nameof(editor));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var splitedOperations = editor.Text.Split(';');
        }

        
        /// <summary>
        /// Берет операции из TextEditor и кладет результат в output
        /// </summary>
        public void PerformAllFromTextEditor(IOperationEditor editor, SimpleTextEditorViewModel output)
        {
            try
            {
                using (var reader = XmlReader.Create(new StringReader(_currentXmlMarkup.OuterXml)) /*editor.CreateXmlReader(_settings)*/)
                {
                    var outputBuilder = new StringBuilder();

                    while (reader.Read())
                    {
                        if (reader.Name == "Number")
                        {
                            var num32 = 0;

                            num32 = OperationCore.SetRegister(num32, int.Parse(reader[0]), 1);
                            num32 = OperationCore.SetRegister(num32, int.Parse(reader[1]), 2);
                            num32 = OperationCore.SetRegister(num32, int.Parse(reader[2]), 3);
                            num32 = OperationCore.SetOperation(num32, int.Parse(reader[3]));

                            num32 = Operations.ExecuteOperation(num32);

                            outputBuilder.AppendFormat(
                                "Operation {0} = register1: {1}, regisetr2: {2} register3: {3}\n",
                                OperationCore.GetOperation(num32),
                                OperationCore.GetRegister(num32, 1),
                                OperationCore.GetRegister(num32, 2),
                                OperationCore.GetRegister(num32, 3));
                        }
                        else if (reader.Name == "File" && reader.NodeType != XmlNodeType.EndElement)
                        {
                            if (reader[0] != null)
                            {
                                _fileName = reader[0];
                            }
                        }
                    }

                    output.Text = outputBuilder.ToString();
                }
            }
            catch (XmlException e)
            {
                output.AppendLine(e.Message);
            }
        }

        /// <summary>
        /// Сохранение в содержимого Edit в бинарный файл. Output для вывода ошибок
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="output"></param>
        public void SaveAllToBinaryFile(IOperationEditor editor, ISimpleTextEditor output)
        {
            try
            {
                using (var binWriter = new BinaryWriter(File.Open(_fileName, FileMode.OpenOrCreate)))
                {
                    using (var reader = XmlReader.Create(new StringReader(_currentXmlMarkup.OuterXml)) /*editor.CreateXmlReader(_settings)*/)
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "Number")
                            {
                                var num32 = 0;

                                num32 = OperationCore.SetRegister(num32, int.Parse(reader[0]), 1);
                                num32 = OperationCore.SetRegister(num32, int.Parse(reader[1]), 2);
                                num32 = OperationCore.SetRegister(num32, int.Parse(reader[2]), 3);
                                num32 = OperationCore.SetOperation(num32, int.Parse(reader[3]));

                                binWriter.Write(num32);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                output.AppendLine(e.Message);
            }
        }

        public void LoadAllFromBinaryFile(IOperationEditor textEditor, SimpleTextEditorViewModel output, string fileName)
        {
            if (fileName != null)
            {
                _fileName = fileName;
            }

            try
            {
                using (var binReader = new BinaryReader(File.Open(_fileName, FileMode.Open)))
                {
                    var markup = new XmlDocument();

                    var root = markup.CreateElement("File");
                    root.SetAttribute("name", _fileName);

                    while (binReader.BaseStream.Position != binReader.BaseStream.Length)
                    {
                        var num32 = binReader.ReadInt32();
                        var xmlNum32 = markup.CreateElement("Number");
                        xmlNum32.SetAttribute("r1", OperationCore.GetStringRegister(num32, 1, 10));
                        xmlNum32.SetAttribute("r2", OperationCore.GetStringRegister(num32, 2, 10));
                        xmlNum32.SetAttribute("r3", OperationCore.GetStringRegister(num32, 3, 10));
                        xmlNum32.SetAttribute("op", OperationCore.GetStringOperation(num32));
                        root.AppendChild(xmlNum32);
                    }

                    markup.AppendChild(root);

                    _currentXmlMarkup = markup;
                    textEditor.LoadXmlMarkup(_currentXmlMarkup);
                }
            }
            catch (Exception e)
            {
                output.AppendLine(e.Message);
            }
        }

        private XmlDocument _currentXmlMarkup;
        private string _fileName;
        private readonly XmlReaderSettings _settings;
    }
}