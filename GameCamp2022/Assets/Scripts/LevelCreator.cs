using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelCreator : MonoBehaviour
{
    public GameObject ground;
    public GameObject hill;
    public GameObject rough1;
    public GameObject rough2;
    public GameObject rough3;

    public GameObject spawner;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {

        Grid grid = tilemap.layoutGrid;
        for (int x = tilemap.origin.x; x < tilemap.origin.x + tilemap.size.x; x ++)
        {
            for (int z = tilemap.origin.y; z < tilemap.origin.y + tilemap.size.y; z ++)
            {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, z, 0));

                Vector3Int localPlace = new Vector3Int(x, z, 0);
                Vector3 place = tilemap.CellToWorld(localPlace);
                if (tile != null)
                {
                    
                    GameObject groundTile = Instantiate(ground, place, Quaternion.identity);
                    if (tile.name == "black")
                    {
                        GameObject tmp = Instantiate(hill, place + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        tmp.transform.Rotate(new Vector3(0, (int)Random.Range(0, 5) * 60 , 0));
                    }
                    else if (tile.name == "red")
                    {
                        GameObject placeable = rough1;
                        switch(Random.Range(0, 2))
                    
                        {
                            case 0:
                                placeable = rough1;
                                break;
                            case 1:
                                placeable = rough2;
                                break;
                            case 2:
                                placeable = rough3;
                                break;
                        }

                        GameObject tmp = Instantiate(placeable, place + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        tmp.transform.Rotate(new Vector3(0, (int)Random.Range(0, 5) * 60, 0));
                    }
                    else if (tile.name == "pink")
                    {
                        GameObject tmp = Instantiate(spawner, place + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        
                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}