using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Reinas
{
    // Clase que representa una Reina en el ajedrez
    public class Reina
    {
        // Determina si un movimiento es válido para una reina
        public bool EsMovimientoValido(int filaInicial, int colInicial, int filaDestino, int colDestino)
        {
            // La reina puede moverse en la misma fila, columna o diagonal
            return filaInicial == filaDestino ||
                   colInicial == colDestino ||
                   Math.Abs(filaInicial - filaDestino) == Math.Abs(colInicial - colDestino);
        }

        // Método recursivo para resolver el problema de colocar N reinas
        public void Resolver(Tablero tablero, int columna, int tamaño, int[] posiciones, ref int contadorSoluciones)
        {
            if (columna == tamaño) // Si todas las reinas han sido colocadas
            {
                contadorSoluciones++; // Incrementa el contador de soluciones
                tablero.DibujarTablero(posiciones, this); // Dibuja la solución
                return;
            }

            for (int fila = 0; fila < tamaño; fila++) // Intenta colocar una reina en cada fila de la columna actual
            {
                if (EsPosicionValida(fila, columna, posiciones)) // Verifica si la posición es válida
                {
                    posiciones[columna] = fila; // Coloca la reina
                    Resolver(tablero, columna + 1, tamaño, posiciones, ref contadorSoluciones); // Llama recursivamente para la siguiente columna
                    posiciones[columna] = -1; // Retira la reina (backtracking)
                }
            }
        }

        // Verifica si una posición es válida para esta reina
        public bool EsPosicionValida(int fila, int columna, int[] posiciones)
        {
            for (int c = 0; c < columna; c++) // Recorre todas las columnas anteriores
            {
                int f = posiciones[c]; // Fila donde ya hay una reina colocada en la columna `c`

                // Conflicto en la misma fila
                if (f == fila)
                    return false;

                // Conflicto en la misma diagonal
                if (Math.Abs(f - fila) == Math.Abs(c - columna))
                    return false;
            }
            return true; // Si no hay conflictos, la posición es válida
        }

        // Devuelve el símbolo de la reina
        public char ObtenerSimbolo()
        {
            return 'Q'; // Representación visual de la reina
        }
    }
}
