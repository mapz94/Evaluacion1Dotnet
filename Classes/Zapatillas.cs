using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1.Classes
{
    class Zapatillas
    {
        string[] modelos = new string[]
        {
            "converse",
            "nike",
            "puma"
        };
        float[] precios = new float[]
        {
            12500f,
            25000f,
            43000f
        };

        public int idZapatillas { get; }
        public int modelo { get; set;}
        public string getModelo()
        {
            return modelos[modelo];
        }
        public float precio { get; set; }
        public int talla { get; set; }
        public float valorEnvio { get; set; }
        public Zapatillas(int idZapatillas, int modelo, float precio, int talla, float valorEnvio)
        {
            this.idZapatillas = idZapatillas;
            this.modelo = modelo;
            this.precio = precio;
            this.talla = talla;
            this.valorEnvio = valorEnvio;
        }

    }
}
