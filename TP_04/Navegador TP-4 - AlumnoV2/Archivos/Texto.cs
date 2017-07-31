using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string arch;
        public Texto(string archivo)
        {
            this.arch = archivo;
        }

        public bool guardar(string datos)
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this.arch, true);
            sw.WriteLine(datos);
            sw.Close();
            return true;
        }



        public bool leer(out List<string> datos)
        {
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this.arch);
            datos = new List<string>();
            while(!sr.EndOfStream)
			{
                datos.Add(sr.ReadLine());
			} 
        
            sr.Close();
        
            return true;    
        }
    }
}
