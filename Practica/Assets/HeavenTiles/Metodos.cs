using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Metodos : MonoBehaviour
{

    public static void GenerarCofres(int[,] mapa, int ancho, int alto, int cantidadCofres, Chest chest, Valkyrie valkyrie)
    {
        int spaceBetweenChests = 0;
        int limitChestSpawn = ancho/cantidadCofres;
        int backup = limitChestSpawn;
        int i = 0;

        valkyrie.gameObject.SetActive(true);

        while (i < cantidadCofres)
        {
            
            int randomX = Random.Range(spaceBetweenChests, limitChestSpawn);
            int randomY = Random.Range(0, alto);

            if (mapa[randomX, randomY] == 0)
            {
                spaceBetweenChests += 30;
                limitChestSpawn += backup;
                Instantiate(chest, new Vector3(randomX + 0.5f, randomY + 0.5f, 0), Quaternion.identity);
                i++;
            }
        }
    }

    public static void GenerarMapa(int[,] mapa, Tilemap mapaDeLosetas, TileBase loseta)
    {
        // Limpiamos el mapa de casillas para empezar con uno vacío
        mapaDeLosetas.ClearAllTiles();

        for (int x = 0; x <= mapa.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= mapa.GetUpperBound(1); y++)
            {
                // 1 = Hay suelo, 0 = No hay suelo
                if (mapa[x, y] == 1)
                {
                    mapaDeLosetas.SetTile(new Vector3Int(x, y, 0), loseta);
                }
            }
        }
    }

    public static int[,] GenerarMapaAleatorio(int ancho, int alto, float semilla, float porcentajeDeRelleno, bool losBordesSonMuros)
    {
        // La semilla de nuestro random
        Random.InitState(semilla.GetHashCode());

        // Creamos el array
        int[,] mapa = new int[ancho, alto];

        // Recorremos todas las posiciones del mapa
        for (int x = 0; x <= mapa.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= mapa.GetUpperBound(1); y++)
            {
                if (losBordesSonMuros && (x == 0 || y == 0))
                {
                    // Ponemos suelo si estamos en una posición del borde
                    mapa[x, y] = 1;
                }
                else
                {
                    // Ponemos suelo si el resultado del random es inferior que el porcentaje de relleno
                    mapa[x, y] = (Random.value < porcentajeDeRelleno) ? 1 : 0;
                }
            }
        }

        return mapa;
    }

    /// <summary>
    /// Calcula el total de losetas vecinas
    /// </summary>
    /// <param name="mapa">El mapa donde comprobar las losetas</param>
    /// <param name="x">La posición en X de la loseta que estamos comprobando</param>
    /// <param name="y">La posición en Y de la loseta que estamos comprobando</param>
    /// <param name="incluirDiagonales">Si hay que tener en cuenta las posiciones vecinas en diagonal</param>
    /// <returns>El total de losetas vecinas con suelo</returns>
    public static int CantidadLosetasVecinas(int[,] mapa, int x, int y, bool incluirDiagonales)
    {
        // Lleva la cuenta de losetas vecinas
        int totalLosetas = 0;

        // Recorrer todas las posiciones vecinas
        for (int vecinoX = x - 1; vecinoX <= x + 1; vecinoX++)
        {
            for (int vecinoY = y - 1; vecinoY <= y + 1; vecinoY++)
            {
                // Comprobamos que estamos dentro del mapa
                if (vecinoX >= 0 && vecinoX <= mapa.GetUpperBound(0) && vecinoY >= 0 && vecinoY <= mapa.GetUpperBound(1))
                {
                    // Comprobamos que no estemos en la misma posición x, y que estamos comprobando
                    // y si incluirDiagonales = false:
                    //
                    //   N
                    // N T N
                    //   N
                    // 
                    // Si incluirDiagonales = true:
                    //
                    // N N N
                    // N T N 
                    // N N N
                    //
                    if ((vecinoX != x || vecinoY != y) && (incluirDiagonales || (vecinoX == x || vecinoY == y)))
                    {
                        totalLosetas += mapa[vecinoX, vecinoY];
                    }
                }
            }
        }

        return totalLosetas;
    }


    public static int[,] AutomataCelularMoore(int[,] mapa, int totalDePasadas, bool losBordesSonMuros)
    {
        for (int i = 0; i < totalDePasadas; i++)
        {
            for (int x = 0; x <= mapa.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= mapa.GetUpperBound(1); y++)
                {
                    // Obtenemos el total de losetas vecinas (Incluyendo las diagonales) 
                    int losetasVecinas = CantidadLosetasVecinas(mapa, x, y, true);

                    // Si estamos en un borde y losBordesSonMuros está activado,
                    // ponemos un muro
                    if (losBordesSonMuros && (x == 0 || y == 0))
                    {
                        mapa[x, y] = 1;
                    }
                    // Si tenemos más de 4 vecinos, ponemos suelo.
                    else if (losetasVecinas > 4)
                    {
                        mapa[x, y] = 1;
                    }
                    // Si tenemos menos de 4 vecinos, dejamos un hueco.
                    else if (losetasVecinas < 4)
                    {
                        mapa[x, y] = 0;
                    }
                    // Si tenemos exactamente 4 vecinos, no cambiamos nada
                }
            }
        }
        return mapa;
    }
}
