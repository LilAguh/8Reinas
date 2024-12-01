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
        // Método para verificar si el movimiento de la reina es válido
        public bool EsMovimientoValido(int filaInicial, int colInicial, int filaDestino, int colDestino)
        {
            // La reina puede moverse en la misma fila, columna o diagonal
            return filaInicial == filaDestino ||                  // Mismo fila
                   colInicial == colDestino ||                    // Mismo columna
                   Math.Abs(filaInicial - filaDestino) == Math.Abs(colInicial - colDestino); // Misma diagonal
        }
    }
}
