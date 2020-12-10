using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        ShowPauseIfNeeded();
    }

    private void ShowPauseIfNeeded()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DataManager.Instance.Some();
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
            AudioManager.Instance.PlayCloseLevel();
        }
    }
}
