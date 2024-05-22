using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati//VERSIUNEA BUNA'
{
    public class Produs : ProdusAbstract, IComparable<Produs>, IEquatable<Produs>
    {
        public Produs() { }
        public override string isA() => "Produs";

        public override bool CanAddToPackage(Pachet pachet)
        {
            return pachet.CurrentProduse < Pachet.MaxProduse;
        }
        public Produs(uint id, string? nume, string? codIntern, string? producator, decimal pret, string? categorie) : base(id, nume, codIntern,pret,categorie)
        {
            Producator = producator;
        }
        
        public string? Producator { get; set; }
        // Implementarea metodei Descriere pentru a oferi o reprezentare text a obiectului
        public override string Descriere()
        {
            return $"Produsul: {Nume} [{CodIntern}] - Pret: {Pret}, Producator: {Producator}, Categorie: {Categorie}";
        }

        // Suprascrierea metodei Equals pentru compararea de egalitate între două obiecte de tip Produs
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as Produs);
        }

        // Implementarea metodei Equals din interfața IEquatable<T> pentru compararea de egalitate între două obiecte de tip Produs
        public bool Equals(Produs other)
        {
            if (other == null)
                return false;
            return this.Nume == other.Nume && this.CodIntern == other.CodIntern && this.Producator == other.Producator &&
                   this.Pret == other.Pret && this.Categorie == other.Categorie;
        }

        // Suprascrierea metodei GetHashCode pentru a respecta contractul dintre Equals și GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Nume, CodIntern, Producator);
        }

        // Implementarea metodei CompareTo din interfața IComparable<T> pentru compararea a două obiecte de tip Produs
        public int CompareTo(Produs other)
        {
            // Compare by name
            int result = string.Compare(this.Nume, other.Nume, StringComparison.Ordinal);
            if (result == 0)
            {
                result = string.Compare(this.CodIntern, other.CodIntern, StringComparison.Ordinal);
                if (result == 0)
                {
                    result = string.Compare(this.Producator ?? "", other.Producator ?? "", StringComparison.Ordinal);
                    if (result == 0)
                    {
                        result = this.Pret.CompareTo(other.Pret);
                        if (result == 0)
                        {
                            result = string.Compare(this.Categorie ?? "", other.Categorie ?? "", StringComparison.Ordinal);
                        }
                    }
                }
            }
            return result;
        }

        // Suprascrierea metodei ToString pentru a oferi o reprezentare text a obiectului
        public override string ToString()
        {
            return $"Produs: {Nume} [{CodIntern}] {Producator}";
        }
    }
}