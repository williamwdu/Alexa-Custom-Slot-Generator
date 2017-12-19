using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            using (StreamReader sr = new StreamReader(@"C:\Git\Alexa-Custom-Slot-Generator\Station List.csv"))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    
                    output = output + "{"+ Environment.NewLine;
                    output = output + "\"id\": null," + Environment.NewLine; //id field
                    output = output + "\"name\": {" + Environment.NewLine;
                    output = output + "\"value\": \"" + currentLine + "\"," + Environment.NewLine; //name field
                    output = output + "\"synonyms\": [" + Environment.NewLine;
                    output = output + "\"" + currentLine + "\"," + Environment.NewLine; //name field
                    output = output + "\"" + currentLine + " station\"" + Environment.NewLine; //name field
                    output = output + "]" + Environment.NewLine;
                    output = output + "}" + Environment.NewLine;
                    output = output + "},"+ Environment.NewLine;
                }
            }
            File.WriteAllText(@"C:\Git\Alexa-Custom-Slot-Generator\output.txt", output);



        }
    }
}
