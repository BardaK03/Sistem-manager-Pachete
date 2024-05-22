using System;
using System.Xml;
using System.Xml.Serialization;


namespace entitati// GOOD VERSION
{
    public class Serviciu : ProdusAbstract, IComparable<Serviciu>, IEquatable<Serviciu>
    {
        public Serviciu() { }

        public void save2XML(string fileName)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
                StreamWriter sw = new StreamWriter(fileName + ".xml");
                xs.Serialize(sw, this);
                sw.Close();
            }
            public Serviciu? loadFromXML(string fileName)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
                FileStream fs = new FileStream(fileName + ".xml",
                FileMode.Open);
                XmlReader reader = new XmlTextReader(fs);
                //deserializare cu crearea de obiect => constructor fara param
                Serviciu? serviciu = (Serviciu?)xs.Deserialize(reader);
                fs.Close();
                return serviciu;
            }
            public override string isA() => "Serviciu";
            public override bool CanAddToPackage(Pachet pachet)
            {
                return pachet.CurrentServicii < Pachet.MaxServicii;
            }
            public Serviciu(uint id, string? nume, string? codIntern, decimal pret, string? categorie) : base(id, nume, codIntern, pret, categorie)
            {
            }

            // Implement the Descriere method from ProdusAbstract
            public override string Descriere()
            {
                return $"Serviciul: {Nume} [{CodIntern}] - Pret: {Pret}, Categorie: {Categorie}";
        }

            // Implement IComparable interface
            public int CompareTo(Serviciu other)
            {
                int result = string.Compare(this.Nume, other.Nume, StringComparison.Ordinal);
                if (result == 0)
                {
                    result = string.Compare(this.CodIntern, other.CodIntern, StringComparison.Ordinal);
                    if (result == 0)
                    {
                        result = this.Pret.CompareTo(other.Pret);
                        if (result == 0)
                        {
                            result = string.Compare(this.Categorie ?? "", other.Categorie ?? "", StringComparison.Ordinal);
                        }
                    }
                }
                return result;
            }

            // Implement IEquatable interface
            public bool Equals(Serviciu other)
            {
                if (other == null)
                    return false;
                return this.Nume == other.Nume && this.CodIntern == other.CodIntern &&
                       this.Pret == other.Pret && this.Categorie == other.Categorie;
            }
        }
    }

