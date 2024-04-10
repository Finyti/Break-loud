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
        public float linePositionX = 0;

        public float linePositionY = 0;

        public int brickCount = 0;

        public float margin = 0;

        public GameObject wallPrefab;
    }
    public GameManager gameManager;
    private int totalBricks = 0;
    void Start()
    {
        GridSpawn();
    }


    void Update()
    {
        
    }

    public async void GridSpawn()
    {
        foreach(var obj in grid)
        {
            for (int i = 0; i < obj.brickCount; i++) 
            {
                var brick = Instantiate(obj.wallPrefab, new Vector2((obj.linePositionX + obj.wallPrefab.transform.localScale.x * 0.5f) + (obj.margin * i), obj.linePositionY), Quaternion.identity);
                brick.transform.parent = transform;
                totalBricks++;
                await new WaitForSeconds(0.1f);
            }
            await new WaitForSeconds(0.1f);
        }

    }

    public void MinusBrick(int points)
    {
        totalBricks--;
        gameManager.AddPoints(points);
        if (totalBricks <= 0)
        {
            gameManager.GameWin();
        }
    }
}
