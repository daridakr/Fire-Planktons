using UnityEngine;
using UnityEngine.Events;

public class BurgerPiece : MonoBehaviour
{
    public event UnityAction<BurgerPiece> Hitted;

    public void Destroy()
    {
        Hitted?.Invoke(this);
        Destroy(gameObject);
    }
}
