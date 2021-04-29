using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Evaluacion1.Classes;

namespace Evaluacion1.Interfaces
{
    interface IBuildFromJson
    {
        static List<Clientes> getClientes()
        {
            string jsonString = File.ReadAllText("./json/clientes.json"); // Personas tambien se construyen desde aca.
            return JsonSerializer.Deserialize<List<Clientes>>(jsonString);
        }

        static List<Zapatillas> getZapatillas()
        {
            string jsonString = File.ReadAllText("./json/zapatillas.json");
            return JsonSerializer.Deserialize<List<Zapatillas>>(jsonString);
        }
    }
}
