using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDados
{
    public class Pet : Cliente
    {
        public int id_pet { get; set; }
        public string peso { get; set; }
        public string altura { get; set; }
        public string comprimento { get; set; }
        public char sexo { get; set; }
        public string especie { get; set; }
        public string raca { get; set; }
        public string reg_animal { get; set; }
        public string observacao { get; set; }
    }
}
