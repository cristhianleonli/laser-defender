using System.Collections;
using Constants;
using Data;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
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

    [SerializeField] private StartOverlay startOverlay;
    [SerializeField] private PauseOverlay pauseOverlay;
    [SerializeField] private EndOverlay endOverlay;

    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private Player player;

    private GameStatus gameStatus;

    void Start()
    {
        sceneTransition.TransitionIn(gameContainer);
        SetUpObjects();
        StartCountdown();
    }

    void Update()
    {
        ShowPauseIfNeeded();
    }

    private void StartCountdown() {
        DOTween.Sequence()
            .SetDelay(1)
            .OnStart(() => startOverlay.SetTitle("3"))
            .Append(startOverlay.FadeOutText())
            .AppendCallback(() => startOverlay.SetTitle("2"))
            .Append(startOverlay.FadeOutText())
            .AppendCallback(() => startOverlay.SetTitle("1"))
            .Append(startOverlay.FadeOutText())
            .AppendCallback(() => startOverlay.SetTitle("START"))
            .Append(startOverlay.FadeOutText())
            .OnComplete(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameStatus = GameStatus.Started;

        startOverlay.FadeOut();
        pauseOverlay.FadeOut();

        player.ResumeMoving();
        asteroidSpawner.ResumeSpawning();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        gameStatus = GameStatus.Paused;

        pauseOverlay.FadeIn();

        player.StopMoving();
        asteroidSpawner.StopSpawning();
    }

    private void SetUpObjects()
    {
        gameStatus = GameStatus.Starting;
        OnHealthUpdate(Player.MaxHealth);
        asteroidSpawner.SetConfiguration(LevelCreator.Instance.GetCurrentSpawnConfig());

        // player events
        Player.OnHealthUpdate += OnHealthUpdate;
        Player.OnWin += OnPlayerWin;
        Player.OnLose+= OnPlayerLose;
    }

    private void ShowPauseIfNeeded()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.PlaySound(SoundType.CloseLevel);

            if (gameStatus == GameStatus.Paused)
            {
                ResumeGame();
            } else if (gameStatus == GameStatus.Started)
            {
                PauseGame();
            }
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

    private void OnPlayerWin(int health)
    {
        EndGame();
    }

    private void OnPlayerLose(int health)
    {
        EndGame();
    }

    private void EndGame()
    {
        gameStatus = GameStatus.Finished;

        // TODO: get the right amount of earned stars
        endOverlay.FadeIn(3);
        player.StopMoving();
        asteroidSpawner.StopSpawning();

        //sceneTransition.TransitionOut(gameContainer, () => GoToMenu());
    }
}
