using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Plankton _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
    }
}
