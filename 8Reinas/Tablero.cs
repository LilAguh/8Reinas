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
        int tamaño;          // Tamaño del tablero (por ejemplo, 8x8)
        int[] posiciones;    // Array donde posiciones[columna] = fila de la reina en esa columna

        // Constructor para inicializar el tablero
        public Tablero(int tamaño)
        {
            this.tamaño = tamaño;                  // Almacena el tamaño del tablero
            posiciones = new int[tamaño];          // Inicializa el array para las posiciones de las reinas
            for (int i = 0; i < tamaño; i++)
                posiciones[i] = -1;                // -1 significa que no hay reina en esa columna
        }

        // Método para verificar si una posición es válida para colocar una pieza
        public bool EsPosicionValida(int fila, int columna, Reina pieza)
        {
            for (int c = 0; c < columna; c++) // Verifica todas las columnas anteriores
            {
                int f = posiciones[c];

                // Misma fila o misma diagonal
                if (f == fila || Math.Abs(f - fila) == Math.Abs(c - columna))
                {
                    return false; // Posición inválida
                }
            }
            return true; // Posición válida
        }

        // Método para colocar una pieza en el tablero
        public void ColocarPieza(int columna, int fila)
        {
            posiciones[columna] = fila;            // Registra la fila donde está la reina en esa columna
        }

        // Método para retirar una pieza (usado en el backtracking)
        public void RetirarPieza(int columna)
        {
            posiciones[columna] = -1;              // Marca la columna como sin reina
        }

        // Representa el tablero en forma de texto
        public string ObtenerTablero()
        {
            string resultado = "";

            // Encabezado con las columnas
            resultado += "       A   B   C   D   E   F   G   H\n";

            // Línea divisoria superior
            resultado += "     ┌───┬───┬───┬───┬───┬───┬───┬───┐\n";

            // Recorre el tablero fila por fila
            for (int i = 0; i < tamaño; i++)  // Recorre las filas desde la 8 hasta la 1 (para coincidir con la notación ajedrecística)
            {
                // Agrega el número de fila al inicio
                resultado += (i + 1).ToString().PadLeft(2) + "   │"; // Imprime el número de la fila

                // Recorre cada columna de la fila
                for (int j = 0; j < tamaño; j++)
                {
                    // Si hay una reina en la posición, coloca el símbolo 'Q'
                    if (posiciones[j] == i)
                        resultado += " Q │";  // Reina representada por 'Q'
                    else
                        resultado += "   │";  // Casilla vacía
                }

                // Línea divisoria después de cada fila
                resultado += "\n";

                // Si no es la última fila, agrega la línea de separación
                if (i < tamaño - 1)
                    resultado += "     ├───┼───┼───┼───┼───┼───┼───┼───┤\n";
                else
                    resultado += "     └───┴───┴───┴───┴───┴───┴───┴───┘\n";  // Última fila con la línea inferior
            }

            return resultado;  // Devuelve la representación completa del tablero
        }

        static void Resolver(Tablero tablero, int columna, int tamaño, Reina pieza, int contadorSoluciones)
        {
            if (columna == tamaño) // Si llegamos a una solución completa
            {
                contadorSoluciones++; // Incrementa el contador de soluciones
                Console.WriteLine($"Solución encontrada N° {contadorSoluciones}:"); // Muestra el número de la solución
                Console.WriteLine(tablero.ObtenerTablero()); // Imprime el tablero con la solución
                return; // Retorna para explorar otras soluciones
            }

            for (int fila = 0; fila < tamaño; fila++) // Intenta colocar una reina en cada fila de la columna actual
            {
                if (tablero.EsPosicionValida(fila, columna, pieza)) // Verifica si la posición es válida
                {
                    tablero.ColocarPieza(columna, fila); // Coloca la reina en la posición válida
                    Resolver(tablero, columna + 1, tamaño, pieza, contadorSoluciones); // Llama recursivamente para la siguiente columna
                    tablero.RetirarPieza(columna); // Retira la reina (backtracking) y prueba otra posición
                }
            }
            // Imprime el total de soluciones al final
            Console.WriteLine($"Proceso terminado. Se encontraron {contadorSoluciones} soluciones.");
        }

        internal static void Resolver(Tablero tablero, int v1, int tamañoTablero, Reina pieza, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
