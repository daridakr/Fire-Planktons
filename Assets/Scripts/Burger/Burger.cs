using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BurgerCreator))]
public class Burger : MonoBehaviour
{
    private BurgerCreator _creator;
    private List<BurgerPiece> _pieces;

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
    }

    private void OnPieceHitted(BurgerPiece hittedPiece)
    {
        hittedPiece.Hitted -= OnPieceHitted;

        Transform previousPiecePoint = hittedPiece.transform;
        _pieces.Remove(hittedPiece);

        foreach (BurgerPiece piece in _pieces)
        {
            piece.transform.position = new Vector3(
                piece.transform.position.x,
                piece.transform.position.y - previousPiecePoint.localScale.y,
                piece.transform.position.z);
        }
    }
}
