using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);
                xml.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch
            {
                throw new ArchivosException();
            }
        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);
                datos = (T)xml.Deserialize(reader);
                reader.Close();

                return true;
            }
            catch
            {
                datos = default(T);
                throw new ArchivosException();
            }
        }
    }
}
