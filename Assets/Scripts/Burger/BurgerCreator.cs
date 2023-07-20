using System.Collections.Generic;
using UnityEngine;

public class BurgerCreator : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private BurgerPiece _piecePrefab;
    [SerializeField] private BurgerPiece _bunPrefab;
    [SerializeField] private Transform _burgerPosition;

    private List<BurgerPiece> _pieces;

    private void Awake()
    {
        _pieces = new List<BurgerPiece>();
    }

    public List<BurgerPiece> Create()
    {
        Transform previousPiecePoint = _burgerPosition;

        previousPiecePoint = PutBun(previousPiecePoint);
        previousPiecePoint = FillBurger(previousPiecePoint);
        PutBun(previousPiecePoint);

        return _pieces;
    }

    private Transform FillBurger(Transform piecePoint)
    {
        for (int i = 0; i < _size; i++)
        {
            BurgerPiece newPiece = CreatePiece(_piecePrefab, piecePoint);
            _pieces.Add(newPiece);
            piecePoint = newPiece.transform;
        }

        return piecePoint;
    }

    private BurgerPiece CreatePiece(BurgerPiece prefab, Transform previousPiecePoint)
    {
        return Instantiate(prefab, GetPositionForNewPiece(prefab, previousPiecePoint), Quaternion.identity, transform);
    }

    private Vector3 GetPositionForNewPiece(BurgerPiece prefab, Transform previousPiecePoint)
    {
        return new Vector3(_burgerPosition.position.x,
                           previousPiecePoint.position.y + previousPiecePoint.localScale.y / 2 + prefab.transform.localScale.y / 2,
                           _burgerPosition.position.z);
    }

    private Transform PutBun(Transform previousPiecePoint)
    {
        BurgerPiece topBun = CreatePiece(_bunPrefab, previousPiecePoint);
        previousPiecePoint = topBun.transform;
        _pieces.Add(topBun);

        return previousPiecePoint;
    }
}
