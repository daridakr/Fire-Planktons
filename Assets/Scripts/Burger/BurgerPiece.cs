using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class BurgerPiece : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

    public event UnityAction<BurgerPiece> Hitted;

    public void Destroy()
    {
        Hitted?.Invoke(this);

        ParticleSystemRenderer effectRenderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        effectRenderer.material.color = GetComponent<MeshRenderer>().material.color;

        Destroy(gameObject);
    }
}
