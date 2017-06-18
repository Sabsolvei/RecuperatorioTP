using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo, true))
                {
                    sw.WriteLine(datos);
                }

                return true;
            }
            catch
            {
                throw new ArchivosException();
            } 
        }

        public bool Leer(string archivo, out string datos)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo))
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + archivo))
                    {
                        sb.AppendFormat(sr.ReadToEnd());
                    }
                }
                datos = sb.ToString();
                return true;
            }
            catch
            {
                throw new ArchivosException();
            }
        }
    }

}
