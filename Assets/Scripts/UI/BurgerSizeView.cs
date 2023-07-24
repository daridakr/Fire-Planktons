using TMPro;
using UnityEngine;

public class BurgerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeDisplay;
    [SerializeField] private Burger _burger;

    private void OnEnable()
    {
        _burger.SizeChanged += OnBurgerSizeChanged;
    }

    private void OnBurgerSizeChanged(int size)
    {
        _sizeDisplay.text = size.ToString();
    }

    private void OnDisable()
    {
        _burger.SizeChanged -= OnBurgerSizeChanged;
    }
}
