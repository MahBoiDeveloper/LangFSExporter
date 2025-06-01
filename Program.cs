using System;
using System.IO;
using System.Linq;
using Rampastring.Tools;

namespace LangFSExporter
{
    class Program
    {
        private static string[] helpFlagVariations = { "/?", "-h", "/h", "-help", "/help", "--help" };
        public static void Main(string[] args)
        {
            string input = "Rules.ini", output = "LangFS.ini";
            foreach (string flag in helpFlagVariations)
            {
                if (args.Contains(flag))
                {
                    PrintHelp();
                    return;
                }
            }

            switch (args.Length)
            {
                case 0:
                    PrintHelp();
                    return;
                case 1:
                    input  = args[0];
                    break;
                case 2:
                    input  = args[0];
                    output = args[1];
                    break;
                case 4:
                    if (!((args[0] == "-i" ||
                           args[0] == "--input") &&
                          (args[2] == "-o" ||
                           args[2] == "--output")))
                    {
                        PrintHelp();
                        return;
                    }
                    else
                    {
                        input  = args[1];
                        output = args[3];
                    }
                    break;
                default:
                    PrintHelp();
                    return;
            }

            if (input == output)
            {
                Console.WriteLine("Output file cannot be the same as the input file!");
                return;
            }

            using (StreamWriter sw = new StreamWriter(File.OpenWrite(output)))
            {
                IniFile iniFile = new IniFile(input);
                var listOfSections = iniFile.GetSections()
                                            .AsParallel()
                                            .Where(x => iniFile.GetStringValue(x, "Name", string.Empty) != string.Empty)
                                            .ToList();
                listOfSections.Sort();
                foreach (var section in listOfSections)
                {
                    sw.WriteLine("[" + section + "]");
                    sw.WriteLine("Name=" + iniFile.GetStringValue(section, "Name", string.Empty));
                    sw.WriteLine();
                }
            }
        }
        private static void PrintHelp()
            =>
                Console.WriteLine
                (
                    """
                    LangFS Names Exporter by mah_boi
                    Powered with Rampastring.Tool by Rampastring
                                  
                    This utillity export all sections that contains Name key.
                    It must help you with finding and preparing LangFS.ini file
                    for next translation it to any language.

                    Available flags:
                        -h, -help, --help, /?, /h, /help -- prints info about utility
                        -i, --input                      -- set path to Rules.ini file
                        -o, --output                     -- set path to LangFS.ini file

                    Arguments example:
                        LangFSExporter --help
                        LangFSExporter rules.ini
                        LangFSExporter rules.ini language.ini
                        LangFSExporter -i ..\src\rules.ini -o langfs.txt
                        LangFSExporter --input src\rules.ini --output src\langfs.
                    """
                );
    }
}
