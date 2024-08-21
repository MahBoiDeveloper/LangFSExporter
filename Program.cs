using System;
using System.IO;
using System.Linq;

namespace LangFSExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rules.ini", output = "LangFS.ini";
            if (CheckForHelpFlag(args))
            {
                PrintHelp();
                return;
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
        static void PrintHelp()
        {
            Console.WriteLine("LangFS Names Exporter by mah_boi\n" +
                              "Powered with Rampastring.Tool by Rampastring\n\n" +
                              
                              "This utillity export all sections that contains Name key.\n" +
                              "It must help you with finding and preparing LangFS.ini file\n" +
                              "for next translation it to any language.\n\n" +

                              "Available flags:\n" +
                              "\t-h, -help, --help, /?, /h, /help -- prints info about utility\n" +
                              "\t-i, --input                      -- set path to Rules.ini file\n" +
                              "\t-o, --output                     -- set path to LangFS.ini file\n\n" +

                              "Arguments example:\n" +
                              "\tLangFSExporter --help\n" +
                              "\tLangFSExporter rules.ini\n" +
                              "\tLangFSExporter rules.ini language.ini\n" +
                              "\tLangFSExporter -i ..\\src\\rules.ini -o langfs.txt\n" +
                              "\tLangFSExporter --input src\\rules.ini --output src\\langfs.ini\n");
        }
        static bool CheckForHelpFlag(string[] args)
        {
            foreach (var flag in args)
            {
                switch(flag)
                {
                    case "/?":
                        return true;
                    case "-h":
                        return true;
                    case "/h":
                        return true;
                    case "-help":
                        return true;
                    case "/help":
                        return true;
                    case "--help":
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}
