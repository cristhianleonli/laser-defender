using System.Security.Cryptography;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameStatus
{
    Starting,
    Started,
    Paused,
    Finished
}

public class LevelController : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private Transform gameContainer;
    [SerializeField] private GameObject[] hearts;

    private GameStatus gameStatus = GameStatus.Starting;

    void Start()
    {
        sceneTransition.TransitionIn(gameContainer);
    }

    void Update()
    {
        ShowPauseIfNeeded();
    }

    private void ShowPauseIfNeeded()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.PlaySound(SoundType.CloseLevel);
            sceneTransition.TransitionOut(gameContainer, () => GoToMenu());
        }
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(Constants.MenuSceneId, LoadSceneMode.Single);
    }
}
