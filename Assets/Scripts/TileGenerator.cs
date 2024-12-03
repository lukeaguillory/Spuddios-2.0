using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using UnityEditor;
using UnityEditor.Tilemaps;
using Unity.VisualScripting;

public class TileGenerator : MonoBehaviour
{ 
    public Tilemap tileMap;
    private Vector3Int here;
    public List<TileBase> tiles;
    

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
            }

            here = new Vector3Int(i, y - 6, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
            }
        }

        for (int i = y - 6; i < y + 6; i++)
        {
            here = new Vector3Int(x + 12, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
            }

            here = new Vector3Int(x - 12, i, 0);
            if (tileMap.GetTile(here) == null)
            {
                tileMap.SetTile(here, GetRandomTile());
            }
        }
    }

    TileBase GetRandomTile()
    {
        return tiles[UnityEngine.Random.Range(0, tiles.Count)];
    }
}
