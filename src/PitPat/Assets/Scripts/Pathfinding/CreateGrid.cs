using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField]
    Grid gridBase;
    [SerializeField]
    Tilemap floor;
    [SerializeField]
    List<Tilemap> obstacleLayers;
    //Object where tiles will be stored
    public GameObject gridNode; 
    public GameObject nodePrefab;

    //Searching bounds
    public int scanStartX = -300, scanStartY = -300, scanFinishX = 300, scanFinishY = 300, gridSizeX, gridSizeY;

    private List<GameObject> unsortedNodes=new List<GameObject>();   // all nodes
    public GameObject[,] nodes;           // sorted 2d array of nodes
    public int gridBoundX = 0, gridBoundY = 0;
    void Start()
    {
        gridSizeX = Mathf.Abs(scanStartX) + Mathf.Abs(scanFinishX);
        gridSizeY = Mathf.Abs(scanStartY) + Mathf.Abs(scanFinishY);
        createGrid();
    }

    public List<WorldTile> getNeighbours(int x, int y, int width, int height)
    {
        List<WorldTile> myNeighbours = new List<WorldTile>();

        if (x > 0 && x < width - 1)
        {
            if (y > 0 && y < height - 1)
            {
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (nodes[x, y + 1] != null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }

                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
            else if (y == 0)
            {
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (nodes[x, y + 1] == null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }
            }
        }
        else if (x == 0)
        {
            if (y > 0 && y < height - 1)
            {
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }

                if (nodes[x, y + 1] != null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == 0)
            {
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x, y + 1] != null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (nodes[x + 1, y] != null)
                {
                    WorldTile wt1 = nodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
        }
        else if (x == width - 1)
        {
            if (y > 0 && y < height - 1)
            {
                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (nodes[x, y + 1] != null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }

                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
            else if (y == 0)
            {
                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }
                if (nodes[x, y + 1] != null)
                {
                    WorldTile wt3 = nodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (nodes[x - 1, y] != null)
                {
                    WorldTile wt2 = nodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (nodes[x, y - 1] != null)
                {
                    WorldTile wt4 = nodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
        }

        return myNeighbours;
    }

    void createGrid()
    {
        int gridX = 0, gridY = 0;
        bool foundTileOnLastPass = false;
        for (int x = scanStartX; x < scanFinishX; x++)
        {
            for (int y = scanStartY; y < scanFinishY; y++)
            {
                TileBase tb = floor.GetTile(new Vector3Int(x, y, 0));
                if (tb != null)
                {
                    bool foundObstacle = false;
                    foreach (Tilemap t in obstacleLayers)
                    {
                        TileBase tb2 = t.GetTile(new Vector3Int(x, y, 0));
                        if (tb2 != null) foundObstacle = true;
                    }

                    Vector3 worldPosition = new Vector3(x + 0.5f + gridBase.transform.position.x, y + 0.5f + gridBase.transform.position.y, 0);
                    GameObject node = (GameObject)Instantiate(nodePrefab, worldPosition, Quaternion.Euler(0, 0, 0));
                    Vector3Int cellPosition = floor.WorldToCell(worldPosition);
                    WorldTile wt = node.GetComponent<WorldTile>();
                    wt.gridX = gridX; wt.gridY = gridY; wt.cellX = cellPosition.x; wt.cellY = cellPosition.y;
                    node.transform.parent = gridNode.transform;

                    if (!foundObstacle)
                    {
                        foundTileOnLastPass = true;
                        node.name = "Walkable_" + gridX.ToString() + "_" + gridY.ToString();
                        wt.walkable = true;
                    }
                    else
                    {
                        foundTileOnLastPass = true;
                        node.name = "Unwalkable_" + gridX.ToString() + "_" + gridY.ToString();
                        wt.walkable = false;
                        node.GetComponent<SpriteRenderer>().color = Color.red;
                    }

                    unsortedNodes.Add(node);

                    gridY++;
                    if (gridX > gridBoundX)
                        gridBoundX = gridX;

                    if (gridY > gridBoundY)
                        gridBoundY = gridY;
                }
            }

            if (foundTileOnLastPass)
            {
                gridX++;
                gridY = 0;
                foundTileOnLastPass = false;
            }
        }

        nodes = new GameObject[gridBoundX + 1, gridBoundY + 1];

        foreach (GameObject g in unsortedNodes)
        {
            WorldTile wt = g.GetComponent<WorldTile>();
            nodes[wt.gridX, wt.gridY] = g;
        }

        for (int x = 0; x < gridBoundX; x++)
        {
            for (int y = 0; y < gridBoundY; y++)
            {
                if (nodes[x, y] != null)
                {
                    WorldTile wt = nodes[x, y].GetComponent<WorldTile>();
                    wt.myNeighbours = getNeighbours(x, y, gridBoundX, gridBoundY);
                }
            }
        }
        Pathfinding.Initialize(floor, nodes, gridBoundX, gridBoundY);
    }
}