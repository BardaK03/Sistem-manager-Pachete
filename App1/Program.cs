using App1;
using entitati;
using System;

namespace app1
{
    internal class Program
    { private const string FilePath = @"C:\Users\barda\Downloads\POSlab4\App1\XMLFile1.xml";
        static void Main(string[] args)
        {
            Console.WriteLine("Selectati optiunea:");
            Console.WriteLine("1. Incarcati Pachet fisier XML");
            Console.WriteLine("2. Introduceti manual Pachet");
            int optiune = int.Parse(Console.ReadLine() ?? "0");
            PachetMgr mgrPachete = new PachetMgr();
            if (optiune == 1)
            {
                mgrPachete.loadFromXML(FilePath);
                mgrPachete.save2XML(FilePath);
                mgrPachete.WriteElemente();
            }
            else if (optiune == 2)
            {

                Console.Write("Nr pachete: ");
                uint nrPachete = uint.Parse(Console.ReadLine() ?? string.Empty);
                mgrPachete.ReadElemente(nrPachete);
                mgrPachete.WriteElemente();
            }
            else
            {
                Console.WriteLine("Optiune GRESITA!!!");
            }
        }
        
    }
}
