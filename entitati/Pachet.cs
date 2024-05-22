using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace entitati
{
    public class Pachet:ProdusAbstract
    {
        [XmlArray("Elemente"), XmlArrayItem(typeof(ProdusAbstract), ElementName = "Element")]
        //noteaza variabila ca si o lista pt xml cu elem de tip ProdusAbastract,cu numele element
        public List<ProdusAbstract> elem_pachet = new List<ProdusAbstract>();
        public static uint MaxProduse = 1;
        public static uint MaxServicii = 6;

        private uint currentProduse;
        private uint currentServicii;

        public uint CurrentProduse { get => currentProduse; set => currentProduse = value; }
        public uint CurrentServicii { get => currentServicii; set => currentServicii = value; }
        public Pachet()
        {
            CurrentProduse = 0;
            CurrentServicii = 0;
        }

        public Pachet(uint id, string? nume, string? codIntern, string? categorie,
            List<IPackageable>? elem_pachet) : base(id, nume, codIntern, 0, categorie)
        {
            currentProduse = 0;
            currentServicii = 0;
            if (elem_pachet != null)
                foreach (ProdusAbstract elem in elem_pachet)
                    if (elem.CanAddToPackage(this))
                        Adauga(elem);
        }

        public void Adauga(IPackageable element)
        {
            if (element.CanAddToPackage(this))
            {
                ProdusAbstract elem = (ProdusAbstract)element;
                if (elem.isA() == "Serviciu") CurrentServicii++;
                else if (elem.isA() == "Produs") CurrentProduse++;

                elem_pachet!.Add(elem);
                Pret += elem.Pret;
            }
        }
        public override bool CanAddToPackage(Pachet pachet)
        {
            return false;
        }

        public void AddElement(Serviciu serviciu)
        {
            throw new NotImplementedException();
        }
        //descrierea pachetului
        public override string Descriere()
        {
            StringBuilder sb = new StringBuilder();
            if (elem_pachet == null)
                return $"Pachetul: {Nume} [{CodIntern}] - Pret: {Pret}, Categorie: {Categorie}";
            else
                foreach (ProdusAbstract el in this.elem_pachet)
                    sb.Append('\t' + el.Descriere() + '\n');
            return $"Pachetul: {Nume} [{CodIntern}] - Pret: {Pret}, Categorie: {Categorie}" + '\n'
                + sb.ToString();
        }
    }
}