using UnityEngine;

public class Plankton : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BurgerPiece piece))
        {
            Destroy(piece.gameObject);
            Destroy(gameObject);
        }
    }
}
