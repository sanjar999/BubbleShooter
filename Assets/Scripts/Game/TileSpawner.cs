using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _startHeight;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetBX;
    [SerializeField] private float _offsetBY;

    private BallSpawner _ballSpawner;
    private List<List<Tile>> _tiles = new();
    private bool _isLongRowTurn = true;

    public List<List<Tile>> GetDeck() => _tiles;

    private void Start()
    {
        GenerateTiles();
        _ballSpawner = GetComponent<BallSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddTiles();
            ShiftTiles();
            _ballSpawner.SpawnBalls();
        }
    }

    private void GenerateTiles()
    {
        for (int i = 0; i < _startHeight; i++)
        {
            if (_isLongRowTurn)
            {
                _isLongRowTurn = false;

                List<Tile> tl = new();
                for (int k = 0; k < 8; k++)
                {
                    var tile = Instantiate(_tile, _parent);
                    tile.Index = new Vector2Int(k,i);
                    tile.SetPos(0, _offsetBX, _offsetBY);
                    tl.Add(tile);
                }

                _tiles.Add(tl);

            }
            else
            {
                _isLongRowTurn = true;

                List<Tile> tl = new();
                for (int k = 0; k < 7; k++)
                {
                    var tile = Instantiate(_tile, _parent);
                    tile.Index = new Vector2Int(k, i);
                    tile.SetPos(_offsetX, _offsetBX, _offsetBY);
                    tl.Add(tile);
                }

                _tiles.Add(tl);
            }
        }
    }

    private void AddTiles()
    {
        for (int i = 0; i < 1; i++)
        {
            if (_tiles[0].Count==7)
            {

                List<Tile> tl = new();
                for (int k = 0; k < 8; k++)
                {
                    var tile = Instantiate(_tile, _parent);
                    tile.Index = new Vector2Int(k, i);
                    tile.SetPos(0, _offsetBX, _offsetBY);
                    tl.Add(tile);
                }

                _tiles.Insert(0,tl);

            }
            else
            {
                List<Tile> tl = new();
                for (int k = 0; k < 7; k++)
                {
                    var tile = Instantiate(_tile, _parent);
                    tile.Index = new Vector2Int(k, i);
                    tile.SetPos(_offsetX, _offsetBX, _offsetBY);
                    tl.Add(tile);
                }

                _tiles.Insert(0, tl);
            }
        }
    }

    private void ShiftTiles()
    {
        for (int i = 0; i < _tiles.Count; i++)
        {
            if (_tiles[i].Count == 8)
            {
                for (int k = 0; k < _tiles[i].Count; k++)
                {
                    _tiles[i][k].Index = new Vector2Int(k, i);
                    _tiles[i][k].SetPos(0, _offsetBX, _offsetBY);
                }
            }
            else
            {
                for (int k = 0; k < _tiles[i].Count; k++)
                {
                    _tiles[i][k].Index = new Vector2Int(k, i);
                    _tiles[i][k].SetPos(_offsetX, _offsetBX, _offsetBY);
                }
            }
          
        }
    }
}