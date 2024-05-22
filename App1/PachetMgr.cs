using app1;
using entitati;
using System;
using System.Xml;

namespace App1
{
    public class PachetMgr : ProdusAbstractMgr
    {
        private ServiciiMgr? mgrServicii;
        private ProduseMgr? mgrProduse;

        public PachetMgr()
        {
            mgrServicii = new ServiciiMgr();
            mgrProduse = new ProduseMgr();
        }
        public override void ReadElement ()
        {
            string? numeTmp, codInternTmp, categorieTmp;
            List<IPackageable> li = new List<IPackageable>();

            Console.WriteLine("Introdu pachetul impreuna cu produsul si serviciile:");

            Console.Write("Numele pachetului: ");
            numeTmp = Console.ReadLine();

            Console.Write("Codul intern al pachetului: ");
            codInternTmp = Console.ReadLine();

            Console.Write("Categoria pachetului:");
            categorieTmp = Console.ReadLine();

            Console.Write($"Cate produse va avea pachetul? (Maxim {Pachet.MaxProduse}): ");

            uint nrProduse;
              nrProduse = uint.Parse(Console.ReadLine() ?? string.Empty);

            if (nrProduse > Pachet.MaxProduse)
            {
                nrProduse = Pachet.MaxProduse;
                Console.WriteLine($"Numarul maxim de produse al unui pachet este {Pachet.MaxProduse}");
            }

            mgrProduse!.ReadElemente(nrProduse);

            Console.Write($"Cate servicii va avea pachetul (Maxim {Pachet.MaxServicii}): ");

            uint nrServicii;
          nrServicii = uint.Parse(Console.ReadLine() ?? string.Empty);


            if (nrServicii > Pachet.MaxServicii)
            {
                nrServicii = Pachet.MaxServicii;
                Console.WriteLine($"Numarul maxim de servicii al unui pachet este {Pachet.MaxServicii}");
            }
            mgrServicii!.ReadElemente(nrServicii);

            foreach (IPackageable p in mgrProduse.GetElemente())
                li.Add(p);
            foreach (IPackageable p in mgrServicii.GetElemente())
                li.Add(p);

            Pachet pac = new Pachet(
                (uint)elemente.Count,
                numeTmp,
                codInternTmp,
                categorieTmp,
                li);

            if (!(elemente.Contains(pac)))
                elemente.Add(pac);
        }
        public void InitElemXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
           doc.Load(filePath);

            XmlNodeList? lista_noduri = doc.SelectNodes("elemente/Pachet");

            if (lista_noduri != null)
                foreach (XmlNode nod in lista_noduri) //each Pachet
                {
                    List<IPackageable>? elem_pachet = new List<IPackageable>();

                    foreach (XmlNode elem in nod["Elemente"]!.ChildNodes) 
                    {
                        if (elem.Name == "Produs")
                        {
                            Produs prod = new Produs(
                                (uint)elemente.Count,
                                elem["Nume"]!.InnerText,
                                elem["CodIntern"]!.InnerText,
                                elem["Producator"]!.InnerText,
                                decimal.Parse(elem["Pret"]!.InnerText),                                
                                elem["Categorie"]!.InnerText);

                            if (!(elem_pachet.Contains(prod)))
                                elem_pachet.Add(prod);
                        }
                        else if (elem.Name == "Serviciu")
                        {
                            Serviciu serv = new Serviciu(
                                (uint)elemente.Count,
                                elem["Nume"]!.InnerText,
                                elem["CodIntern"]!.InnerText,
                                int.Parse(elem["Pret"]!.InnerText),
                                elem["Categorie"]!.InnerText);

                            if (!(elem_pachet.Contains(serv)))
                                elem_pachet.Add(serv);
                        }
                    }
                    Pachet pac = new Pachet(
                        (uint)elemente.Count,
                        nod["Nume"]!.InnerText,
                        nod["CodIntern"]!.InnerText,
                        nod["Categorie"]!.InnerText,
                        elem_pachet);

                    if (!(elemente.Contains(pac)))
                        elemente.Add(pac);
                }

        }
    }
}