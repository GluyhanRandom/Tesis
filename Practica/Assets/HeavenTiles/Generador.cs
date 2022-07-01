using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Algoritmo
{
    AutomataCelularMoore, TunelDireccional
}

public class Generador : MonoBehaviour
{

    public KarmaData karma;

    [Header("Referencias")]
    public Tilemap MapaDeLosetas;
    public TileBase Loseta;
    public Chest Cofre;
    Valkyrie Valquiria;

    [Header("Dimensiones")]
    public int Ancho = 60;
    public int Alto = 34;

    [Header("Semilla")]
    public bool SemillaAleatoria = true;
    public float Semilla = 0;

    [Header("Algoritmo")]
    public Algoritmo algoritmo = Algoritmo.AutomataCelularMoore;

    [Header("Cuevas")]
    public bool LosBordesSonMuros = true;

    [Header("Autómata celular")]
    [Range(0, 1)]
    public float PorcentajeDeRelleno = 0.45f;
    public int TotalDePasadas = 3;

    private int ChestQuantity;

    public void Start()
    {
        Valquiria = FindObjectOfType<Valkyrie>();
        if (karma.PlayerGoodKarma >= karma.PlayerBadKarma)
        {
            PorcentajeDeRelleno = 0.45f;
            LosBordesSonMuros = true;
            ChestQuantity = Random.Range(3, 7);
        }
        else
        {
            PorcentajeDeRelleno = 0.507f;
            LosBordesSonMuros = false;
            ChestQuantity = Random.Range(1, 5);
            Destroy(Valquiria.gameObject);
        }

        GenerarMapa();
        StartCoroutine(SpawnPathFinder());
    }
    
    IEnumerator SpawnPathFinder()
    {
        yield return new WaitForSeconds(2);

        HeavenLevelManager.SpawnPathFinder();
    }

    public void GenerarMapa()
    {
        // Limpiamos el mapa de losetas
        MapaDeLosetas.ClearAllTiles();

        // Creamos el array bidimensional del mapa
        int[,] mapa = null;

        // Generamos una semilla nueva de forma aleatoria
        if (SemillaAleatoria)
        {
            Semilla = Random.Range(0f, 1000f);
        }

        switch (algoritmo)
        {
            case Algoritmo.AutomataCelularMoore:
                mapa = Metodos.GenerarMapaAleatorio(Ancho, Alto, Semilla, PorcentajeDeRelleno, LosBordesSonMuros);
                mapa = Metodos.AutomataCelularMoore(mapa, TotalDePasadas, LosBordesSonMuros);
                break;
        }
        Metodos.GenerarMapa(mapa, MapaDeLosetas, Loseta);
        Metodos.GenerarCofres(mapa, Ancho, Alto, ChestQuantity, Cofre, Valquiria);
    }

    public void LimpiarMapa()
    {
        MapaDeLosetas.ClearAllTiles();
    }

}
