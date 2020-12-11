using UnityEngine;
using Data;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private MenuCanvas menuCanvas;

    private void Start()
    {
        UpdateCanvas();
    }

    public void OpenLevel(LevelConfig config)
    {
        // TODO: make transition
        SceneManager.LoadScene(Constants.LevelSceneId, LoadSceneMode.Single);
    }

    private void UpdateCanvas()
    {
        var coins = DataManager.GetCoins();
        menuCanvas.SetCoins(coins);
    }
}
