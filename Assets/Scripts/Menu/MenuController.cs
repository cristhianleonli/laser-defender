using UnityEngine;
using Data;
using UnityEngine.SceneManagement;
using Constants;

public class MenuController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private Transform gameContainer;

    private void Start()
    {
        sceneTransition.TransitionIn(gameContainer);
    }

    // Called by each LevelPanel
    public void OpenLevel(Level level)
    {
        LevelCreator.Instance.CurrentLevel = level;
        sceneTransition.TransitionOut(gameContainer, () => GoToLevelScreen());
    }

    private void GoToLevelScreen()
    {
        SceneManager.LoadScene(Strings.LevelSceneId, LoadSceneMode.Single);
    }
}
