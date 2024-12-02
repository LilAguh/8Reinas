using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Reinas
{
    // Clase que representa el tablero de ajedrez
    public class Tablero
    {
        public int tamaño;

        public Tablero(int tamaño)
        {
            this.tamaño = tamaño;
        }

        // Dibuja el tablero con las posiciones dadas y la pieza proporcionada
        public void DibujarTablero(int[] posiciones, dynamic pieza)
        {
            Console.WriteLine("      A   B   C   D   E   F   G   H");
            Console.WriteLine("    ┌───┬───┬───┬───┬───┬───┬───┬───┐");

            for (int fila = 0; fila < tamaño; fila++)
            {
                Console.Write($"{fila + 1}   │");
                for (int col = 0; col < tamaño; col++)
                {
                    if (posiciones[col] == fila)
                        Console.Write($" {pieza.ObtenerSimbolo()} │"); // Dibuja la pieza en la posición
                    else
                        Console.Write("   │");
                }
                Console.WriteLine();

                if (fila < tamaño - 1)
                    Console.WriteLine("    ├───┼───┼───┼───┼───┼───┼───┼───┤");
                else
                    Console.WriteLine("    └───┴───┴───┴───┴───┴───┴───┴───┘");
            }
        }
    }
}
