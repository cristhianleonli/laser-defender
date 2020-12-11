using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SceneTransition transition;
    [SerializeField] private Transform gameContainer;

    void Start()
    {
        transition.TransitionIn(gameContainer);
    }

    void Update()
    {
        ShowPauseIfNeeded();
    }

    private void ShowPauseIfNeeded()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Constants.MenuSceneId, LoadSceneMode.Single);
            AudioManager.Instance.PlaySound(SoundType.CloseLevel);
        }
    }
}
