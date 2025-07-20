using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    public GameObject brickPrefab;

    int rows = 5, columns = 9;
    private Vector2 startingPosition;
    [SerializeField] private Transform startingBrick;
    private List<GridPosition> gridPositions = new List<GridPosition>();
    void Start()
    {
        startingPosition = new Vector2(startingBrick.position.x, startingBrick.position.y);
        GenerateGrid();
        SpawnBricks();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gridPositions.Add(
                new GridPosition(startingPosition.x, startingPosition.y));
                startingPosition.x += 0.7f;
            }
            startingPosition.x = -2.8f;
            startingPosition.y -= 0.3f;
        }
    }
    private void SpawnBricks()
    {
        for (int i = 0; i < gridPositions.Count; i++)
        {
            Instantiate(brickPrefab,
                    new Vector2(gridPositions[i].x, gridPositions[i].y), Quaternion.identity);
        }
    }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     foreach (GridPosition pos in gridPositions)
    //     {
    //         Gizmos.DrawWireCube(new Vector2(pos.x, pos.y), new Vector2(0.6f, 0.2f));
    //     }
    // }
    private struct GridPosition
    {
        public float x;
        public float y;

        public GridPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
