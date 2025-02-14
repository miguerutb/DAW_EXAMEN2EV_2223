﻿using System;

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
        
        private int[] combinacion = new int[MAX_NUMEROS];   // numeros de la combinación
        private bool valida = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Combinacion { 
            get => combinacion; 
            set => combinacion = value; 
        }
        public bool Ok { get => valida; set => valida = value; }

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
                    if (Combinacion[j]==num)
                        break;
                if (i==j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Combinacion[i]=num;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            Ok=true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        /// <summary>
        /// Constructor de clase con parámetro <paramref name="entrada"/>
        /// </summary>
        /// <param name="entrada">Array de enteros con la combinacion a crear</param>
        public MTB2223(int[] entrada)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i=0; i<MAX_NUMEROS; i++)
            { 
                if (entrada[i]>=NUMERO_MENOR && entrada[i]<=NUMERO_MAYOR) 
                {
                    int j;

                    for (j=0; j<i; j++)
                    {
                        if (entrada[i]==Combinacion[j])
                            break;
                    }

                    if (i == j)
                    {
                        Combinacion[i]=entrada[i]; // validamos la combinación
                    } else {
                        Ok=false;
                        return;
                    }
                }
                else
                {
                    Ok=false;     // La combinación no es válida, terminamos
                    return;
                }
            }
	        Ok=true;
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
                    if (combinacionGanadora[i]==Combinacion[j]) aciertos++;
            return aciertos;
        }
    }

}
