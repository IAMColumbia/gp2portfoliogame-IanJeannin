using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    static Tilemap floor;
    static private GameObject[,] nodes;
    private static int gridBoundX, gridBoundY;

    public static void Initialize(Tilemap floorMap,GameObject[,] nodesArray, int xBound, int yBound)
    {
        floor = floorMap;
        nodes = nodesArray;
        gridBoundX = xBound;
        gridBoundY = yBound;
    }

    WorldTile GetWorldTileByCellPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = floor.WorldToCell(worldPosition);
        WorldTile wt = null;
        int totalIterations = 0;
        for (int x = 0; x < gridBoundX; x++)
        {
            for (int y = 0; y < gridBoundY; y++)
            {
                if (nodes[x, y] != null)
                {
                    WorldTile _wt = nodes[x, y].GetComponent<WorldTile>();

                    // we are interested in walkable cells only
                    if (_wt.walkable && _wt.cellX == cellPosition.x && _wt.cellY == cellPosition.y)
                    {
                        wt = _wt;
                        break;
                    }
                    else
                    {
                        totalIterations++;
                        continue;
                    }
                }
            }
        }
        if(totalIterations>0)
        {
            Debug.Log(totalIterations);
        }
        return wt;
    }

    int GetDistance(WorldTile nodeA, WorldTile nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    List<WorldTile> RetracePath(WorldTile startNode, WorldTile targetNode)
    {
        List<WorldTile> path = new List<WorldTile>();
        WorldTile currentNode = targetNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    public Vector2 FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        WorldTile startNode = GetWorldTileByCellPosition(startPosition);
        WorldTile targetNode = GetWorldTileByCellPosition(endPosition);

        List<WorldTile> openSet = new List<WorldTile>();
        HashSet<WorldTile> closedSet = new HashSet<WorldTile>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            WorldTile currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                List<WorldTile> path = RetracePath(startNode, targetNode);
                Vector2 nextNode = path[0].transform.position;
                if(nextNode.x>this.transform.position.x)
                {
                    return new Vector2(1, 0);
                }
                else if(nextNode.x<this.transform.position.x)
                {
                    return new Vector2(-1, 0);
                }
                else if (nextNode.y > this.transform.position.y)
                {
                    return new Vector2(0, 1);
                }
                else if (nextNode.y < this.transform.position.y)
                {
                    return new Vector2(0, -1);
                }
            }

            foreach (WorldTile neighbour in currentNode.myNeighbours)
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour)) continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
        return new Vector2(0, 0);
    }
}
