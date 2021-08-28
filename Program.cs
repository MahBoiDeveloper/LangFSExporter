using System;
using System.IO;
using System.Text;
using System.Linq;

namespace LangFSExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) return;
            
            foreach (var arg in args)
            {
                using(StreamWriter sw = new StreamWriter(File.OpenWrite(arg + ".txt")))
                {
                    IniFile iniFile = new IniFile(arg);
                    var listOfSections = iniFile.GetSections().AsParallel().Where(x => iniFile.GetStringValue(x, "Name", string.Empty) != string.Empty).ToList();
                    listOfSections.Sort();
                    foreach (var section in listOfSections)
                    {
                        sw.WriteLine("[" + section + "]");
                        sw.WriteLine("Name=" + iniFile.GetStringValue(section, "Name", string.Empty));
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
