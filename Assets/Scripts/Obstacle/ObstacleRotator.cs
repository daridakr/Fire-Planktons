using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Obstacle[] _obstacles;

    private void OnEnable()
    {
        _obstacles = GetComponentsInChildren<Obstacle>();

        for (int i = 0; i < _obstacles.Length; i++)
        {
            _obstacles[i].Hitted += OnObstacleHit;
        }
    }

    private void Start()
    {
        BeginRotate(_duration);
    }

    private void OnObstacleHit(Obstacle obstacle)
    {
        StopRotate();
        obstacle.Hitted -= OnObstacleHit;
    }

    private void BeginRotate(float duration)
    {
        transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }

    private void StopRotate()
    {
        transform.DOKill();
    }
}
