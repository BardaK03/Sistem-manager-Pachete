using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using entitati;
using App1;

namespace app1
{
    internal class ProduseMgr : ProdusAbstractMgr
    {
       
        public void ReadFromXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList nodeList = doc.SelectNodes("elemente/Produs");
            foreach (XmlNode node in nodeList)
            {
                string nume = node["Nume"].InnerText;
                string codIntern = node["CodIntern"].InnerText;
                string producator = node["Producator"].InnerText;
                decimal pret = decimal.Parse(node["Pret"].InnerText);
                string categorie = node["Categorie"].InnerText;

                elemente.Add(new Produs((uint)elemente.Count + 1, nume, codIntern, producator, pret, categorie));
            }
        }
        public override void ReadElement()
        {
            
            {
                Console.WriteLine("Introdu un produs");
                Console.Write("Numele:");
                string? nume = Console.ReadLine();
                Console.Write("Codul intern:");
                string? codIntern = Console.ReadLine();
                Console.Write("Producator:");
                string? producator = Console.ReadLine();
                Console.Write("Pret:");
                decimal pret = decimal.Parse(Console.ReadLine() ?? "0");
                Console.Write("Categorie:");
                string? categorie = Console.ReadLine();

                Produs prod = new Produs((uint) elemente.Count, nume, codIntern, producator, pret, categorie);

                if (!InserareConditionata(prod))
                {
                    elemente.Add(prod); // inloc de elemente[CountElemente++] = prod;
                }
                else
                {
                    Console.WriteLine("Produsul exista deja in tablou!");
                    
                }
            }
        }

        

        public bool InserareConditionata(Produs obj)
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
            foreach (var produs in elemente)
            {
                if (produs != null && produs.Nume == nume)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
