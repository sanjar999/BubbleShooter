using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    basket,
    foot,
    rag,
    voley,
    pingpong,
    tennis,
    length
}

public class Ball : MonoBehaviour
{
    [SerializeField] private BallType _ballType;
    [SerializeField] private Sprite[] _sprites;

    private Tile _tile;
    private bool _isAnchored;
    private bool _isToDestroy;

    public Tile Tile { get => _tile; set => _tile = value; }

    private void Start()
    {
        SetSprite();
    }

    public void SetType(BallType ballType)
    {
        _ballType = ballType;
        SetSprite();
    }

    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = _sprites[(int)_ballType];
    }
}