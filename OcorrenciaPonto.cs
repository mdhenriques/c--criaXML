using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class OcorrenciaPonto
    {
        public String matricula;
        public String data;
        public String hora;
        public String filler;

        public void setMatricula(String _matricula) { matricula = _matricula; }
        public void setData(String _data) { data = _data; }
        public void setHora(String _hora) { hora = _hora; }
        public void setFiller(String _filler) { filler = _filler; }
        

        public String getMatricula() { return matricula; }
        public String getData() { return data; }
        public String getHora() { return hora; }
        public String getFiller() { return filler; }
        
    }
}

