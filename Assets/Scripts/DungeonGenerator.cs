using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public GameObject floorPrefab;
    public GameObject wallPrefab;

    private int[,] map;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        map = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    map[x, y] = 0;
                else
                    map[x, y] = 1;
            }
        }

        DrawMap();
    }

    void DrawMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                    Instantiate(floorPrefab, new Vector3(x, 0, y), Quaternion.identity);
                else
                    Instantiate(wallPrefab, new Vector3(x, 1, y), Quaternion.identity);
            }
        }
    }
}
