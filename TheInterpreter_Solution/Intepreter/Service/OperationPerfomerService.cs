﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
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

            _fileName = "default";
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
        /// Берет операции из editor и кладет результат в output
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="output"></param>
        public void PerformAll(SimpleTextEditorViewModel editor, SimpleTextEditorViewModel output)
        {
            try
            {
                using (var reader = XmlReader.Create(new StringReader(editor.Text), _settings))
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
                        else if (reader.Name == "File")
                        {
                            if (reader[0] != null)
                            {
                                _fileName = reader[0];
                            }
                        }

                        output.Text = outputBuilder.ToString();
                    }
                }
            }
            catch (XmlException e)
            {
                output.AppendLine(e.Message);
            }
            catch (XmlSchemaValidationException e)
            {
                output.AppendLine(e.Message);
            }
            catch (ArgumentException e)
            {
                output.AppendLine(e.Message);
            }
        }

        public void SaveAllToBinaryFile(SimpleTextEditorViewModel editor, SimpleTextEditorViewModel output)
        {
            try
            {
                using (var binWriter = new BinaryWriter(File.Open(_fileName, FileMode.OpenOrCreate)))
                {
                    using (var reader = XmlReader.Create(new StringReader(editor.Text), _settings))
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
            catch (XmlException e)
            {
                output.AppendLine(e.Message);
            }
            catch (XmlSchemaValidationException e)
            {
                output.AppendLine(e.Message);
            }
            catch (ArgumentException e)
            {
                output.AppendLine(e.Message);
            }
        }

        public void LoadAllFromBinaryFile(SimpleTextEditorViewModel editor)
        {

        }

        private string _fileName;
        private readonly XmlReaderSettings _settings;
    }
}