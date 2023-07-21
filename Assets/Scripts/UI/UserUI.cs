using UnityEngine;
using UnityEngine.SceneManagement;

public class UserUI : MonoBehaviour
{
    [SerializeField] private LossPanel _lossPanel;
    [SerializeField] private WinPanel _winPanel;

    [SerializeField] private Burger _burger;
    [SerializeField] private Obstacle[] _obstacles;
    
    private void OnEnable()
    {
        foreach (Obstacle obstacle in _obstacles) 
        {
            obstacle.Hitted += OnPlayerLost;
        }

        _burger.Destroyed += OnPlayerWin;
    }

    private void OnPlayerLost(Obstacle obstacle)
    {
        _lossPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        obstacle.Hitted -= OnPlayerLost;
    }

    private void OnPlayerWin(Burger burger)
    {
        _winPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        _burger.Destroyed -= OnPlayerWin;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
