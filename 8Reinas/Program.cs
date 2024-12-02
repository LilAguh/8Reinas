// See https://aka.ms/new-console-template for more information


using _8Reinas;
using System;

class Program
{
    static void Main(string[] args)
    {
        int tamañoTablero = 8;
        Tablero tablero = new Tablero(tamañoTablero);

        Reina reina = new Reina();
        int[] posiciones = new int[tamañoTablero];
        for (int i = 0; i < tamañoTablero; i++) posiciones[i] = -1; // Inicializa las posiciones

        int contadorSoluciones = 0;
        reina.Resolver(tablero, 0, tamañoTablero, posiciones, ref contadorSoluciones);

        Console.WriteLine($"Proceso terminado. Total de soluciones: {contadorSoluciones}");
        // Pausa para evitar que la consola se cierre inmediatamente
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}