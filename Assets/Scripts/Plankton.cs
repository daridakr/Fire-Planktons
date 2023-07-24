using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Plankton : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BurgerPiece piece))
        {
            piece.Destroy();
            Destroy(gameObject);
        }
        else if (other.TryGetComponent(out Obstacle obstacle))
        {
            //obstacle.Hit();
            Bounce();
        }
    }

    // isn't destroyed
    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;

        Rigidbody body = GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddExplosionForce(_bounceForce, transform.position + Vector3.forward + Vector3.down, _bounceRadius);
    }
}
