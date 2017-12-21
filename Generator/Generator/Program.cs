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
            using (StreamReader sr = new StreamReader(@"C:\Git\Alexa-Custom-Slot-Generator\Station List multi.csv"))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] pass = currentLine.Split(',');
                    pass = pass.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //remove empties 
                    int number = pass.Count();
                    if (number == 1)
                    {
                        output = output + "{" + Environment.NewLine;
                        output = output + "\"id\": null," + Environment.NewLine; //id field
                        output = output + "\"name\": {" + Environment.NewLine;
                        output = output + "\"value\": \"" + currentLine + "\"," + Environment.NewLine; //name field
                        output = output + "\"synonyms\": [" + Environment.NewLine;
                        output = output + "\"" + currentLine + "\"," + Environment.NewLine; //name field
                        output = output + "\"" + currentLine + " station\"" + Environment.NewLine; //name field
                        output = output + "]" + Environment.NewLine;
                        output = output + "}" + Environment.NewLine;
                        output = output + "}," + Environment.NewLine;
                    }
                    else
                    {
                        output = output + "{" + Environment.NewLine;
                        output = output + "\"id\": null," + Environment.NewLine; //id field
                        output = output + "\"name\": {" + Environment.NewLine;
                        output = output + "\"value\": \"" + pass[0] + "\"," + Environment.NewLine; //name field
                        output = output + "\"synonyms\": [" + Environment.NewLine;
                        for (int i = 0; i < number; i++)
                        {
                            if (i != number - 1)
                            { 
                                output = output + "\"" + pass[i] + "\"," + Environment.NewLine; //name field
                            }
                            else
                            {
                                output = output + "\"" + pass[i] + "\"" + Environment.NewLine; //name field
                            }
                        }

                        output = output + "]" + Environment.NewLine;
                        output = output + "}" + Environment.NewLine;
                        output = output + "}," + Environment.NewLine;
                    }
                }
            }
            File.WriteAllText(@"C:\Git\Alexa-Custom-Slot-Generator\output.txt", output);



        }
    }
}
