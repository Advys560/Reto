using System;

namespace EV05_Estructuras_Iterativas
{
    class Program
    {
        static void Main(string[] args)
        {
            // =========================================================================
            // SECCIÓN 1 — For y Foreach: Registro y análisis de calificaciones
            // =========================================================================
            int[] calificaciones = { 72, 85, 91, 60, 43, 78, 95, 55, 88, 67 };

            Console.WriteLine("=== REGISTRO DE CALIFICACIONES ===");
            for (int i = 0; i < calificaciones.Length; i++)
            {
                Console.WriteLine($"Estudiante {i + 1}: {calificaciones[i]}");
            }

            Console.WriteLine("\n=== ORDEN DESCENDENTE ===");
            for (int i = calificaciones.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"Estudiante {i + 1}: {calificaciones[i]}");
            }

            Console.WriteLine("\n=== PROMEDIO DEL GRUPO ===");
            int sumaTotal = 0;
            foreach (int calificacion in calificaciones)
            {
                sumaTotal += calificacion;
            }
            double promedio = (double)sumaTotal / calificaciones.Length;
            Console.WriteLine($"Suma total: {sumaTotal}");
            Console.WriteLine($"Promedio: {promedio:F1}");

            Console.WriteLine("\n=== POSICIONES PARES ===");
            for (int i = 0; i < calificaciones.Length; i += 2)
            {
                Console.WriteLine($"Posición par: {calificaciones[i]}");
            }

            // =========================================================================
            // SECCIÓN 2 — While y Do-While: Validación y juego interactivo
            // =========================================================================
            Console.WriteLine("\n=== CONTROL DE ACCESO ===");
            int intentos = 0;
            const string claveCorrecta = "sena2025";
            bool accesoConcedido = false;

            while (intentos < 3 && !accesoConcedido)
            {
                Console.Write("Ingresa la clave: ");
                string claveIngresada = Console.ReadLine();

                if (claveIngresada == claveCorrecta)
                {
                    accesoConcedido = true;
                    Console.WriteLine("Acceso concedido.");
                }
                else
                {
                    intentos++;
                    if (intentos < 3)
                    {
                        Console.WriteLine($"Clave incorrecta. Intentos restantes: {3 - intentos}");
                    }
                    else
                    {
                        Console.WriteLine("Acceso bloqueado.");
                    }
                }
            }

            // Menú interactivo solo si el acceso fue concedido
            if (accesoConcedido)
            {
                int opcion;
                do
                {
                    Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                    Console.WriteLine("1. Ver promedio del grupo");
                    Console.WriteLine("2. Ver calificación más alta");
                    Console.WriteLine("3. Salir");
                    Console.Write("Elige una opción: ");

                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine($"Promedio del grupo: {promedio:F1}");
                                break;
                            case 2:
                                int maxCalificacion = calificaciones[0];
                                foreach (int c in calificaciones)
                                {
                                    if (c > maxCalificacion) maxCalificacion = c;
                                }
                                Console.WriteLine($"Calificación más alta: {maxCalificacion}");
                                break;
                            case 3:
                                Console.WriteLine("Hasta luego.");
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        opcion = 0;
                    }

                } while (opcion != 3);
            }

            // =========================================================================
            // SECCIÓN 3 — Break y Continue: Filtrado y búsqueda eficiente
            // =========================================================================
            Console.WriteLine("\n=== PRIMERA CALIFICACIÓN REPROBATORIA ===");
            for (int i = 0; i < calificaciones.Length; i++)
            {
                if (calificaciones[i] < 60)
                {
                    Console.WriteLine($"Encontrada en posición {i + 1}: {calificaciones[i]}");
                    break;
                }
            }

            Console.WriteLine("\n=== ESTUDIANTES APROBADOS ===");
            int contadorAprobados = 0;
            foreach (int calificacion in calificaciones)
            {
                if (calificacion < 60)
                {
                    continue;
                }
                Console.WriteLine($"Aprobado: {calificacion}");
                contadorAprobados++;
            }
            Console.WriteLine($"Total aprobados: {contadorAprobados}");

            Console.WriteLine("\n=== FILTRO COMBINADO ===");
            for (int i = 0; i < calificaciones.Length; i++)
            {
                if (calificaciones[i] < 70)
                {
                    continue;
                }

                if (calificaciones[i] >= 95)
                {
                    Console.WriteLine($"Búsqueda detenida al encontrar: {calificaciones[i]}");
                    break;
                }

                Console.WriteLine($"Calificación procesada: {calificaciones[i]}");
            }
        }
    }
}