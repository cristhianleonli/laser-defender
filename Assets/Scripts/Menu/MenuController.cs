using UnityEngine;
using Data;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private MenuCanvas menuCanvas;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private Transform gameContainer;

    private void Start()
    {
        UpdateCanvas();
        sceneTransition.TransitionIn(gameContainer);
    }

    public void OpenLevel(LevelConfig config)
    {
        // TODO: send config to Level screen
        sceneTransition.TransitionOut(gameContainer, () => GoToLevelScreen());
    }

    private void GoToLevelScreen()
    {
        SceneManager.LoadScene(Constants.LevelSceneId, LoadSceneMode.Single);
    }

    private void UpdateCanvas()
    {
        var coins = DataManager.GetCoins();
        menuCanvas.SetCoins(coins);
    }
}
