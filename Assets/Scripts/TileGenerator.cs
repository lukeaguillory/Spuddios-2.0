
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TileGenerator : MonoBehaviour
{ 
    public Tilemap tileMap;
    private Vector3Int here;
    public List<TileBase> tiles;

    [SerializeField]
    public float _minimumSpawnTime;
    [SerializeField]
    public float _maximumSpawnTime;
    public float _timeUntilSpawn;
    public List<GameObject> foliage;
    public List<GameObject> spawner;
    public int percentChanceForFoliage;
    public int percentChanceForSpawner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        Vector2 cameraPosition = Camera.main.transform.position;
        int x = Convert.ToInt32(Math.Round(cameraPosition.x, 0));
        int y = Convert.ToInt32(Math.Round(cameraPosition.y, 0));

        for (int i = x - 15; i < x + 15; i++)
        {
            here = new Vector3Int(i, y + 8, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                PlaceFoliage();
                PlaceEnemySpawner();
            }

            here = new Vector3Int(i, y - 9, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                PlaceFoliage();
                PlaceEnemySpawner();
            }
        }

        for (int i = y - 9; i < y + 8; i++)
        {
            here = new Vector3Int(x + 14, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                PlaceFoliage();
                PlaceEnemySpawner();
            }

            here = new Vector3Int(x - 15, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                PlaceFoliage();
                PlaceEnemySpawner();
            }
        }
    }

    TileBase GetRandomTile()
    {
        return tiles[UnityEngine.Random.Range(0, tiles.Count)];
    }

    GameObject GetRandomFoliage()
    {
        return foliage[UnityEngine.Random.Range(0, foliage.Count)];
    }

    GameObject GetRandomEnemySpawner()
    {
        return spawner[UnityEngine.Random.Range(0, spawner.Count)];
    }

    public void PlaceFoliage()
    {
        if (UnityEngine.Random.Range(0, 100) <= percentChanceForFoliage)
        {
            Instantiate(GetRandomFoliage(), here, Quaternion.identity);
        }
    }

    public void PlaceEnemySpawner()
    {
        if (UnityEngine.Random.Range(0, 100) <= percentChanceForSpawner && _timeUntilSpawn <= 0)
        {
            Instantiate(GetRandomEnemySpawner(), here, Quaternion.identity);
            _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        }
    }
}
