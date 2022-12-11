using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _parent;
    [SerializeField] private TileSpawner _tileSpawner;

    void Start()
    {
        SpawnBalls();
    }

    public void SpawnBalls()
    {
        foreach (var list in _tileSpawner.GetDeck())
        {
            foreach (var tile in list)
            {
                Ball ball = new();
                BallType ballType;
                if (tile.Ball == null)
                {
                    ball = Instantiate(_ball, _parent);
                    ballType = (BallType)Random.Range(0, (int)BallType.length);
                    ball.SetType(ballType);
                }
                else
                {
                    ball = tile.Ball;
                }
                
                ball.transform.position = tile.transform.position;
                tile.Ball = ball;
                ball.Tile = tile;
            }
        }
    }

}
