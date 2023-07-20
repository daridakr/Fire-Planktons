using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _duration;

    private void Start()
    {
        Rotate(_duration);
    }

    private void Rotate(float duration)
    {
        transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
