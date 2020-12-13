using Constants;
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
        SetUpObjects();
    }

    void Update()
    {
        ShowPauseIfNeeded();
    }

    private void SetUpObjects()
    {
        OnHealthUpdate(Player.MaxHealth);
        Player.OnHealthUpdate += OnHealthUpdate;
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
        SceneManager.LoadScene(Strings.MenuSceneId, LoadSceneMode.Single);
    }

    private void OnHealthUpdate(int health)
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }

        if (health >= 1) { hearts[0].SetActive(true); }
        if (health >= 2) { hearts[1].SetActive(true); }
        if (health >= 3) { hearts[2].SetActive(true); }
        if (health == 4) { hearts[3].SetActive(true); }
    }
}
