using System.Collections.Generic;
using Evaluacion1.Classes;
using Evaluacion1.Interfaces;
using System;
using System.Linq;

// Realizado por Miguel Pérez

namespace Evaluacion1
{
    class Program
    {
        static string separacionFea = "====================";
        static string[] opciones = { "Consultar Clientes", "Consultar zapatillas" };
        static string[] opcionesCliente = { "Consultar saldo", "Postular a bono" };
        static string[] opcionesZapatillas = { "Comprar Zapatilla", "Volver al menu" };
        static int opcion = 0;

        static void printOpciones(string[] opciones)
        {
            for (int i = 0; i < opciones.Length; i++)
                Console.WriteLine($"{i + 1}.{opciones[i]}");
        }
        static void printIntro()
        {
            Console.WriteLine("Bienvenido a zapatillas S.A");
            Console.WriteLine(separacionFea);
            Console.WriteLine("¿Qué desea hacer?");
            printOpciones(opciones);
        }

        static bool shouldReturn()
        {
            Console.WriteLine("Para volver presione Q, o para continuar presiona cualquier tecla.");
            string q = Console.ReadLine();
            return q.Equals("q") || q.Equals("Q") ;
        }

        static void MenuZapatillas()
        {
            List<Zapatillas> zapatillas = IBuildFromJson.getZapatillas();
            while (true)
            {
                Console.WriteLine($"Tenemos {zapatillas.Count} tipos de zapatillas: ");
                // Usamos lambda para remapear los atributos de la lista de objeto a una lista de strings.
                printOpciones(zapatillas.Select(zapatilla => $"{zapatilla.getModelo()} precio: {zapatilla.precio}").ToArray());
                if (Int32.TryParse(Console.ReadLine(), out opcion))
                {
                    var zapatilla = zapatillas[opcion - 1];
                    Console.WriteLine($"Usted ha seleccionado: {opcion}");
                    Console.WriteLine($"Usted ha seleccionado {zapatilla.getModelo()}");
                    Console.WriteLine("¿Qué desea hacer?");
                    printOpciones(opcionesZapatillas);
                    if (Int32.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine($"El valor es {zapatilla.precio}");
                                break;
                            case 2:
                                continue;
                        }
                    }
                }
                if (shouldReturn()) break;
            }
        }
        static void MenuClientes()
        {
            List<Clientes> clientes = IBuildFromJson.getClientes();
            while (true)
            {
                Console.WriteLine("Estimado Cliente ! porfavor ingrese su nombre: ");
                string nombre = Console.ReadLine();
                var cliente = clientes.Find(cliente => cliente.nombre == nombre);
                if (cliente != null)
                {
                    Console.WriteLine($"Estimado cliente, usted es: {cliente.persona.getCategoria()}");
                    while (true)
                    {
                        Console.WriteLine("¿Qué desea hacer?");
                        printOpciones(opcionesCliente);
                        if (Int32.TryParse(Console.ReadLine(), out opcion))
                        {
                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine($"Su saldo disponible es de {cliente.saldoDisponible()}");
                                    break;
                                case 2:
                                    if (cliente.persona.categoria == 0) // 0 es priviligeado
                                    {
                                        cliente.bono = 500000;
                                        Console.WriteLine($"Felicidades usted tiene su bono: {cliente.saldoDisponible()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted no posee bono alguno.");
                                    }
                                    break;
                            }
                        }
                        if (shouldReturn()) break;
                    }
                    continue;
                }
                else Console.WriteLine("Ese cliente no fue encontrado.");
                if (shouldReturn()) break;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                printIntro();
                if (Int32.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuZapatillas();
                            break;
                    }
                    continue;
                }
                if (shouldReturn()) break;
            }
            Console.WriteLine("Gusto en atenderlo!!");
            
        }
    }
}
