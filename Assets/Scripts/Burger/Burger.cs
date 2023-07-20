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

        foreach (var piece in _pieces)
        {
            piece.Hitted += OnPieceHitted;
        }
    }

    private void OnPieceHitted(BurgerPiece hittedPiece)
    {
        hittedPiece.Hitted -= OnPieceHitted;

        _pieces.Remove(hittedPiece);

        foreach (var piece in _pieces)
        {
            piece.transform.position = new Vector3(
                piece.transform.position.x,
                piece.transform.position.y - piece.transform.localScale.y,
                piece.transform.position.z);
        }
    }
}
