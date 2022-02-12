using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MapEditor
{
#if UNITY_EDITOR
    // [MenuItem("Tools/GenerateMap %#g")]
    // private static void HelloWorld()
    // {
    //     if(EditorUtility.DisplayDialog("Hello", "Create?", "Create", "Cancel"))
    //     {
    //         new GameObject("Hello");
    //     }
    // }

    [MenuItem("Tools/GenerateMap %#g")]
    private static void GenerateMap()
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>("Prefabs/Map");


        foreach (GameObject go in gameObjects)
        {
            Tilemap tmBase = Util.FindChild<Tilemap>(go, "Tilemap_Base", true);
            Tilemap tm = Util.FindChild<Tilemap>(go, "Tilemap_Collision", true);

            using (var writer = File.CreateText($"Assets/Resources/Map/{go.name}.txt"))
            {
                writer.WriteLine(tmBase.cellBounds.xMin);
                writer.WriteLine(tmBase.cellBounds.xMax);
                writer.WriteLine(tmBase.cellBounds.yMin);
                writer.WriteLine(tmBase.cellBounds.yMax);

                for(int y = tmBase.cellBounds.yMax; y >= tmBase.cellBounds.yMin; y--)
                {
                    for(int x = tmBase.cellBounds.xMin; x <= tmBase.cellBounds.xMax; x++)
                    {
                        TileBase tile = tm.GetTile(new Vector3Int(x,y,0));
                        if(tile != null) writer.Write("1");
                        else writer.Write("0");
                    }
                    writer.WriteLine();
                }
            }
        }
     /*   GameObject go = GameObject.Find("Map");
        if(go == null) 
            return;

        Tilemap tm = Util.FindChild<Tilemap>(go, "Tilemap_Collision", true);
        if(tm == null)
            return;

        List<Vector3Int> blocked = new List<Vector3Int>();
        foreach (Vector3Int pos in _tileMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = _tileMap.GetTile(pos);
            if(tile != null)
                blocked.Add(pos);
        }

        using (var writer = File.CreateText("Assets/Resources/Map/output.txt"))
        {
            writer.WriteLine(tm.cellBounds.xMin);
            writer.WriteLine(tm.cellBounds.xMax);
            writer.WriteLine(tm.cellBounds.yMin);
            writer.WriteLine(tm.cellBounds.yMax);

            for(int y = tm.cellBounds.yMax; y >= tm.cellBounds.yMin; y--)
            {
                for(int x = tm.cellBounds.xMin; x <= tm.cellBounds.xMax; x++)
                {
                    TileBase tile = tm.GetTile(new Vector3Int(x,y,0));
                    if(tile != null) writer.Write("1");
                    else writer.Write("0");
                }
                 writer.WriteLine();
            }
        }
        */
    }

#endif
}
