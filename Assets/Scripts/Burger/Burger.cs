using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(BurgerCreator))]
public class Burger : MonoBehaviour
{
    private BurgerCreator _creator;
    private List<BurgerPiece> _pieces;

    public UnityAction<int> SizeChanged;
    public UnityAction<Burger> Destroyed;

    private void Awake()
    {
        _creator = GetComponent<BurgerCreator>();
    }

    private void Start()
    {
        _pieces = _creator.Create();

        foreach (BurgerPiece piece in _pieces)
        {
            piece.Hitted += OnPieceHitted;
        }

        SizeChanged?.Invoke(_pieces.Count);
    }

    private void OnPieceHitted(BurgerPiece hittedPiece)
    {
        hittedPiece.Hitted -= OnPieceHitted;

        Transform previousPiecePoint = hittedPiece.transform;
        _pieces.Remove(hittedPiece);

        if (_pieces.Count > 0) 
        {
            foreach (BurgerPiece piece in _pieces)
            {
                piece.transform.position = new Vector3(
                    piece.transform.position.x,
                    piece.transform.position.y - previousPiecePoint.localScale.y,
                    piece.transform.position.z);
            }
        }
        else
        {
            Destroyed?.Invoke(this);
        }

        SizeChanged?.Invoke(_pieces.Count);
    }
}
