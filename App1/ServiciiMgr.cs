using App1;
using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace app1
{
    internal class ServiciiMgr:ProdusAbstractMgr
    {
        public void ReadFromXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList nodeList = doc.SelectNodes("elemente/Serviciu");
            foreach (XmlNode node in nodeList)
            {
                string nume = node["Nume"].InnerText;
                string codIntern = node["CodIntern"].InnerText;
                decimal pret = decimal.Parse(node["Pret"].InnerText);
                string categorie = node["Categorie"].InnerText;

                elemente.Add(new Serviciu((uint)elemente.Count + 1, nume, codIntern, pret, categorie));
            }
        }
        public override void ReadElement()
        {
            {
                Console.WriteLine("Introdu un serviciu");
                Console.Write("Numele:");
                string? nume = Console.ReadLine();
                Console.Write("Codul intern:");
                string? codIntern = Console.ReadLine();
                Console.Write("Pret:");
                decimal pret = decimal.Parse(Console.ReadLine() ?? "0");
                Console.Write("Categorie:");
                string? categorie = Console.ReadLine();

                Serviciu serv = new Serviciu((uint)elemente.Count, nume, codIntern, pret, categorie);

                if (!InserareConditionata(serv))
                {
                    elemente.Add(serv); // în loc de elemente[CountElemente++] = prod;
                    
                }
                else
                {
                    Console.WriteLine("Serviciul exista deja in tablou!");
                   
                }
            }
        }

        public void WriteServicii()
        {
            Console.WriteLine("Serviciile sunt:");
            for (int cnt = 0; cnt < elemente.Count; cnt++)
            {
                Console.WriteLine(elemente[cnt].Descriere());
            }
        }

        public bool InserareConditionata(Serviciu obj)
        {
            for (int j = 0; j < elemente.Count; j++)
            {
                if (elemente[j].Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contine(string? nume)
        {
            foreach (var serviciu in elemente)
            {
                if (serviciu != null && serviciu.Nume == nume)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
