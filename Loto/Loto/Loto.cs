using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class MTB2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] _nums = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool ok = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Nums { 
            get => _nums; 
            set => _nums = value; 
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta
        /// <summary>
        /// Constructor de clase sin parámetros
        /// <remarks>Se genera combinacion aleatoria</remarks>
        /// </summary>
        public MTB2223()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i=0, j, num;

            do             // generamos la combinación
            {                       
                num = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (j=0; j<i; j++)    // comprobamos que el número no está
                    if (Nums[j]==num)
                        break;
                if (i==j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Nums[i]=num;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            ok=true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        /// <summary>
        /// Constructor de clase con parámetro <paramref name="misnums"/>
        /// </summary>
        /// <param name="misnums">Array de enteros con la combinacion a crear</param>
        public MTB2223(int[] misnums)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i=0; i<MAX_NUMEROS; i++)
                if (misnums[i]>=NUMERO_MENOR && misnums[i]<=NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misnums[i]==Nums[j])
                            break;
                    if (i==j)
                        Nums[i]=misnums[i]; // validamos la combinación
                    else {
                        ok=false;
                        return;
                    }
                }
                else
                {
                    ok=false;     // La combinación no es válida, terminamos
                    return;
                }
	    ok=true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        /// <summary>
        /// Comprueba el numero de aciertos
        /// </summary>
        /// <param name="combinacionGanadora">array con la combinacion ganadora</param>
        /// <returns>Devuelve numero de aciertos</returns>
        public int Comprobar(int[] combinacionGanadora)
        {
            int aciertos=0;                    // número de aciertos
            for (int i=0; i<MAX_NUMEROS; i++)
                for (int j=0; j<MAX_NUMEROS; j++)
                    if (combinacionGanadora[i]==Nums[j]) aciertos++;
            return aciertos;
        }
    }

}
