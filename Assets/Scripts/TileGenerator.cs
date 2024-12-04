using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using UnityEditor;
using UnityEditor.Tilemaps;
using Unity.VisualScripting;
using Assets.Scripts.Pawns;
using Assets.Scripts;

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
    public int percentChanceForFoliage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 cameraPosition = Camera.main.transform.position;
        int x = Convert.ToInt32(Math.Round(cameraPosition.x, 0));
        int y = Convert.ToInt32(Math.Round(cameraPosition.y, 0));

        for (int i = x - 12; i < x + 12; i++)
        {
            here = new Vector3Int(i, y + 6, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());

                if (UnityEngine.Random.Range(0, 100) <= percentChanceForFoliage)
                {
                    Instantiate(GetRandomFoliage(), here, Quaternion.identity);
                }
            }

            here = new Vector3Int(i, y - 6, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                if (UnityEngine.Random.Range(0, 100) <= percentChanceForFoliage)
                {
                    Instantiate(GetRandomFoliage(), here, Quaternion.identity);
                }
            }
        }

        for (int i = y - 6; i < y + 6; i++)
        {
            here = new Vector3Int(x + 12, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                if (UnityEngine.Random.Range(0, 100) <= percentChanceForFoliage)
                {
                    Instantiate(GetRandomFoliage(), here, Quaternion.identity);
                }
            }

            here = new Vector3Int(x - 12, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
                if (UnityEngine.Random.Range(0, 100) <= percentChanceForFoliage)
                {
                    Instantiate(GetRandomFoliage(), here, Quaternion.identity);
                }
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

    public void SetTimeUntilPlaceFoliage()
    {
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
