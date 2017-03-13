using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Resources;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Intepreter.Model.Operations;
using Microsoft.Win32.SafeHandles;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num32 = 0;
            //int operation = 1;
            //int register = 15;



            //num32 = OperationCore.SetOperation(num32, operation);
            //num32 = OperationCore.SetRegister(num32, register, 1);

            //num32 = Operations.ExecuteOperation(num32);

            //Console.WriteLine(OperationCore.GetRegister(num32, 3));
            //Console.WriteLine(OperationCore.GetRegister(num32, 2));
            //Console.WriteLine(OperationCore.GetRegister(num32, 1));
            //Console.WriteLine(OperationCore.GetOperation(num32));

            string xsdMarkup =
    @"<xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>  
       <xsd:element name='Root'>  
        <xsd:complexType>  
         <xsd:sequence>  
          <xsd:element name='Child1' minOccurs='1' maxOccurs='1'/>  
          <xsd:element name='Child2' minOccurs='1' maxOccurs='1'/>  
         </xsd:sequence>  
        </xsd:complexType>  
       </xsd:element>  
      </xsd:schema>";

            string testMarkup =
                @"<xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>  
                    <xsd:element name='File'>  
                        <xsd:complexType>  
                            <xsd:sequence>  
                                <xsd:element name='Number' minOccurs='1' maxOccurs='unbounded'/>  
                            </xsd:sequence>  
                        </xsd:complexType>  
                    </xsd:element>  
                    </xsd:schema>";

            string xml =
                @"<File>
                    <Num/>
                  </File>";

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", @"E:\Git\TheIntepreter\TheInterpreter_Solution\TestConsoleApp\TestMarkup.xsd");
            
            XDocument doc1 = new XDocument(
                new XElement("File",
                    new XElement("Number"),
                    new XElement("Number")
                )
            );

            XmlReaderSettings settings = new XmlReaderSettings();

            settings.Schemas.Add("", @"E:\Git\TheIntepreter\TheInterpreter_Solution\TestConsoleApp\TestMarkup.xsd");
            //settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;
            //settings.ValidationEventHandler += ValidationEventHandler;

            try
            {
                using (var reader = XmlReader.Create(new StringReader(xml), settings))
                {
                    while (reader.Read())
                    {

                    }

                    Console.WriteLine("Validated");
                }
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine(e);
            }

            //Console.WriteLine("Validating doc1");
            //bool errors = false;
            //doc1.Validate(schemas, (o, e) =>
            //{
            //    Console.WriteLine("{0}", e.Message);
            //    errors = true;
            //});

            //Console.WriteLine("doc1 {0}", errors ? "did not validate" : "validated");
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new XmlException(e.Message);
        }
    }
}
