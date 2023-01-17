using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2 coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int _coordinates, bool _walkable)
    {
        this.coordinates = _coordinates;
        this.isWalkable = _walkable;
    }
}
