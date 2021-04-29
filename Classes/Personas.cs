using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1.Classes
{
    class Personas
    {
        string[] categorias = new string[]
        {
            "Priviligeado",
            "Rechazado"
        };

        public int idPersona { get; }

        public int categoria { get; set; }

        public string getCategoria()
        {
            return categorias[categoria];
        }

        public string genero { get; set; }

        public Personas(int idPersona, int categoria, string genero)
        {
            this.idPersona = idPersona;
            this.categoria = categoria;
            this.genero = genero;
        }
    }
}
