using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati //MERE
{
    public abstract class ProdusAbstract :IPackageable
    {
        public ProdusAbstract()
        {

        }
        public virtual bool CanAddToPackage(Pachet pachet)
        {
            return false;
        }
        public ProdusAbstract(uint id, string? nume, string? codIntern, decimal pret, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;
        }


        public uint Id { get; set; }
        public string? Nume { get; set; }
        public string? CodIntern { get; set; }
        public decimal Pret { get; set; }
        public string? Categorie { get; set; }

        public abstract string Descriere();

        public int CompareTo(ProdusAbstract other)
        {
            // Ordinea de sortare: Nume, apoi CodIntern
            if (other == null)
            {
                return 1;
            }

            int result = this.Nume.CompareTo(other.Nume);
            if (result == 0)
            {
                result = this.CodIntern.CompareTo(other.CodIntern);
            }

            return result;
        }
        public virtual string isA() => "ProdusAbstract";
    }
}