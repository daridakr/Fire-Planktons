using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public event UnityAction<Obstacle> Hitted;

    public void Hit()
    {
        Hitted?.Invoke(this);
    }
}
