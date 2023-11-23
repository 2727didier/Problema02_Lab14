using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema02_Lab14
{
    internal class Program
    {
        
            static int[] edades = new int[1000];
            static bool[] seHaVacunado = new bool[1000];
            static int totalEncuestados = 0;

            static void Main()
            {
                int opcion;

                do
                {
                    MostrarMenu();
                    Console.Write("Ingrese una opción: ");
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        ProcesarOpcion(opcion);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opción válida.");
                    }

                } while (opcion != 5);
            }

            static void MostrarMenu()
            {
                Console.WriteLine("================================");
                Console.WriteLine("Encuesta de vacunación");
                Console.WriteLine("================================");
                Console.WriteLine("1: Realizar Encuesta");
                Console.WriteLine("2: Mostrar Datos de la encuesta");
                Console.WriteLine("3: Mostrar Resultados");
                Console.WriteLine("4: Buscar Personas por edad");
                Console.WriteLine("5: Salir");
                Console.WriteLine("================================");
            }

            static void ProcesarOpcion(int opcion)
            {
                switch (opcion)
                {
                    case 1:
                        RealizarEncuesta();
                        break;
                    case 2:
                        MostrarDatosEncuesta();
                        break;
                    case 3:
                        MostrarResultados();
                        break;
                    case 4:
                        BuscarPorEdad();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }

            static void RealizarEncuesta()
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Encuesta de vacunación");
                Console.WriteLine("===================================");

                Console.Write("¿Qué edad tienes?: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    Console.WriteLine("Te has vacunado");
                    Console.WriteLine("1: Sí");
                    Console.WriteLine("2: No");

                    Console.Write("Ingrese una opción: ");
                    if (int.TryParse(Console.ReadLine(), out int opcionVacuna) && (opcionVacuna == 1 || opcionVacuna == 2))
                    {
                        edades[totalEncuestados] = edad;
                        seHaVacunado[totalEncuestados] = opcionVacuna == 1;

                        totalEncuestados++;

                        Console.WriteLine("¡Gracias por participar!");
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una edad válida.");
                }

                Console.WriteLine("===================================");
                Console.WriteLine("Presione una tecla ...");
                Console.ReadKey();
            }

            static void MostrarDatosEncuesta()
            {
                Console.WriteLine("Datos de la encuesta:");
                for (int i = 0; i < totalEncuestados; i++)
                {
                    Console.WriteLine($"Edad: {edades[i]}, Se ha vacunado: {seHaVacunado[i]}");
                }
            }

            static void MostrarResultados()
            {
                int totalVacunados = 0;
                for (int i = 0; i < totalEncuestados; i++)
                {
                    if (seHaVacunado[i])
                    {
                        totalVacunados++;
                    }
                }

                Console.WriteLine($"Total encuestados: {totalEncuestados}");
                Console.WriteLine($"Total vacunados: {totalVacunados}");
                Console.WriteLine($"Porcentaje de vacunados: {(double)totalVacunados / totalEncuestados * 100}%");
            }

            static void BuscarPorEdad()
            {
                Console.Write("Ingrese la edad a buscar: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    bool encontrado = false;

                    for (int i = 0; i < totalEncuestados; i++)
                    {
                        if (edades[i] == edad)
                        {
                            Console.WriteLine($"Edad: {edades[i]}, Se ha vacunado: {seHaVacunado[i]}");
                            encontrado = true;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine($"No se encontraron personas con edad {edad}.");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una edad válida.");
                }
            }
    }

}


