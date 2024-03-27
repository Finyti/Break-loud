using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public List<WallLine> grid = new List<WallLine>();

    [System.Serializable]
    public class WallLine
    {
        public float linePositionY = 0;

        public int brickCount = 0;

        public float margin = 0;

        public GameObject wallPrefab;
    }

    void Start()
    {
        GridSpawn();
    }


    void Update()
    {
        
    }

    public void GridSpawn()
    {
        foreach(var obj in grid)
        {
            for (int i = 0; i < obj.brickCount; i++) 
            {
                var brick = Instantiate(obj.wallPrefab, new Vector2(-8 + obj.margin * i + obj.wallPrefab.transform.localScale.x, obj.linePositionY), Quaternion.identity);
            }
        }
    }
}
