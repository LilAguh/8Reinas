// See https://aka.ms/new-console-template for more information


using _8Reinas;
class Program
{
    int contadorSoluciones = 0; // Contador global para el número de soluciones

    static void Main(string[] args)
    {
        int tamañoTablero = 8;                      // Define el tamaño del tablero (8x8)
        Tablero tablero = new Tablero(tamañoTablero); // Crea una instancia del tablero
        Reina pieza = new Reina();                  // Crea una instancia de la reina

        Tablero.Resolver(tablero, 0, tamañoTablero, pieza, 0); // Llama al método para resolver el problema
    }

    // Método recursivo para resolver el problema de las 8 reinas
    
}