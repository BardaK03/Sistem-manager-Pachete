using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace App1 //MERGEEEEEEEEEE
{
    public abstract class ProdusAbstractMgr
    {// serializarea xml
        public void save2XML(string filePath)
        {
            Type[] prodAbstractTypes =
                {typeof(Pachet), typeof(Produs), typeof(Serviciu)};

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter(filePath);
            xs.Serialize(sw, elemente);
            sw.Close();
        }
        public void loadFromXML(string filePath)
        {
            Type[] prodAbstractTypes =
                {typeof(Pachet), typeof(Produs), typeof(Serviciu)};

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            List<ProdusAbstract> listProduse = (List<ProdusAbstract>)xs.Deserialize(reader)!;

            fs.Close();

            if (listProduse != null)
                foreach (ProdusAbstract elem in listProduse)
                    elemente.Add(elem);
        }
        protected List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        public virtual void WriteElemente()
        {
            foreach (ProdusAbstract element in elemente)
                Console.WriteLine(element.Descriere() + " ");
        }
        public abstract void ReadElement();

        public void ReadElemente(uint nr)
        {
            for (int cnt = 0; cnt < nr; cnt++)
                ReadElement();
        }
        public IEnumerable<ProdusAbstract> GetElemente()
        {
            return elemente;
        }
    }
}
    
