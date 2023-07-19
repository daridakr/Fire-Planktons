using System.Collections.Generic;
using UnityEngine;

public class BurgerCreator : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private BurgerPiece _piecePrefab;
    [SerializeField] private Transform _burgerPosition;

    private List<BurgerPiece> _pieces;
    private float _verticalOffset = 0.3f;

    private void Start()
    {
        _pieces = new List<BurgerPiece>();
        Create();
    }

    public List<BurgerPiece> Create()
    {
        Transform previousPiecePoint = _burgerPosition;

        for (int i = 0; i < _size; i++)
        {
            BurgerPiece newPiece = CreatePiece(previousPiecePoint);
            _pieces.Add(newPiece);
            previousPiecePoint = newPiece.transform;
        }

        return _pieces;
    }

    private BurgerPiece CreatePiece(Transform previousPiecePoint)
    {
        return Instantiate(_piecePrefab, GetPositionForNewPiece(previousPiecePoint), Quaternion.identity, transform);
    }

    private Vector3 GetPositionForNewPiece(Transform previousPiecePoint)
    {
        return new Vector3(_burgerPosition.position.x,
                           previousPiecePoint.position.y + previousPiecePoint.localScale.y / 2 + _piecePrefab.transform.localScale.y / 2 - _verticalOffset,
                           _burgerPosition.position.z);
    }
}
