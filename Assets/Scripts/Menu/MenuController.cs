using UnityEngine;
using Data;
using UnityEngine.SceneManagement;
using Constants;

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

    // Called by each level panel
    public void OpenLevel(LevelConfig config)
    {
        LevelCreator.Instance.CurrentLevelConfig = config;
        sceneTransition.TransitionOut(gameContainer, () => GoToLevelScreen());
    }

    private void GoToLevelScreen()
    {
        SceneManager.LoadScene(Strings.LevelSceneId, LoadSceneMode.Single);
    }

    private void UpdateCanvas()
    {
        var coins = DataManager.GetCoins();
        menuCanvas.SetCoins(coins);
    }
}
