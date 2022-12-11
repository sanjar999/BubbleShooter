using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Ball _ball;
    private Vector2Int _index = new();

    public Ball Ball { get => _ball; set => _ball = value; }
    public Vector2Int Index { get => _index; set => _index = value; }

    public void SetPos(float offsetX, float offsetBX, float offsetBY)
    {
        transform.position = new Vector2(_index.x + offsetX + offsetBX * _index.x - 4.5f, -(_index.y + offsetBY * _index.y) + 6.9f);
    }
}
