using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1.Classes
{
    class Clientes
    {
        string[] nombres = new string[]
        {
            "Constanza",
            "Alex"
        };
        float[] saldos = new float[]
        {
            22500f,
            22500f
        };

        public int idClientes { get; }
        public Personas persona { get; set; }

        public string nombre { get; set; }
        public float salario { get; set; }

        public float saldo { get; set; }
        public float saldoDisponible()
        {
            return salario + bono;
        }
        public float bono { get; set; }

        public Clientes(int idClientes, Personas persona, float salario, float bono)
        {
            this.idClientes = idClientes;
            this.persona = persona;
            nombre = nombres[idClientes - 1];
            saldo = saldos[idClientes - 1];
            this.salario = salario;
            this.bono = bono;
        }
    }
}
