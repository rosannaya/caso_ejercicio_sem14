using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_ejercicio_sem14
{
    internal class Program
    {
        static string[] codigos = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
        static string[] modelos = { "SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga" };
        static double[,] datos = {
            { 28000.0, 2 },
            { 18500.0, 4 },
            { 35000.0, 1 },
            { 14000.0, 5 },
            { 42000.0,1 },
            { 22500.0,3 } };

        static double[] montos = new double[6];
        static double total = 0;
        static int cont = 0;
        //metodo con retorno
        static public bool validar(double precio, double cant)
        {
            if (precio > 0 && cant > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error, elprecio y la cantidad deben ser > 0");
                return false;
            }
        }

        static public void Req2()
        {
            for (int i = 0; i < codigos.Length; i++)
            {
                validar(datos[i, 0], datos[i, 1]);
                montos[i] = datos[i, 0] * datos[i, 1];
                total = total + montos[i];
                if (montos[1] > 50000)
                {
                    cont++;
                }
            }
        }

        static public void imprimir_matriz()
        {
            Console.WriteLine("++++++++++MATRIZ BIDIMENSIONAL++++++++++++++++++++++");
            Console.WriteLine("Fila | Codigo |Precio(columna0) |Cantidad(columna1)");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine(i +" | "+codigos[i] + " | " + datos[i, 0] + "| " + datos[i, 1]);
            }
        }
        static public void ordenar_desc()
        {
            int n = codigos.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double temp_mont = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = temp_mont;


                        string tmp_mod = modelos[j];
                        modelos[j] = modelos[j + 1];
                        modelos[j + 1] = tmp_mod;

                        string tmp_cod = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tmp_cod;

                        double tmp_precio = datos[j, 0];
                        datos[j, 0] = datos[j + 1, 0];
                        datos[j + 1, 0] = tmp_precio;

                        double tmp_cant = datos[j, 1];
                        datos[j, 1] = datos[j + 1, 1];
                        datos[j + 1, 1] = tmp_cant;
                    }
                }
            }
        }
        static public void buscar(string cod_buscar)
        {
            bool encontrado = false;
            if (string.IsNullOrWhiteSpace(cod_buscar))
            {
                Console.WriteLine("Valor vacio..");
                return;
            }
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i] == cod_buscar)
                {
                    Console.WriteLine("Codigo encontrado...");
                    Console.WriteLine("Codigo: " + codigos[i] + "| Modelo: " + modelos[i] + "| Montos:" + montos[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Codigo no existe");

        }

        static public void imprimir2()
        {
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine("Codigo: " + codigos[i] + "| Modelo: " + modelos[i] + "| Montos:" + montos[i]);
            }
        }
        static void Main(string[] args)
        {
            Req2();
            imprimir_matriz();
            ordenar_desc();
            Console.WriteLine("++++++++++++++REPORTE+++++++++++");
            imprimir2();
            Console.WriteLine();
            Console.WriteLine("GRAN TOTAL ACUMULADO: $ " + total);
            Console.WriteLine("VENT APREMIUM > $50000: " + cont);
            buscar("AUTO-203");
        }

    }
}
