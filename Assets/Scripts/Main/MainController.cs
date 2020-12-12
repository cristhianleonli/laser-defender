using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] private Image transitionRenderer;
    [SerializeField] private Transform background;

    private void Start()
    {
        transitionRenderer.gameObject.SetActive(false);
        transitionRenderer.DOFade(0, 0);
    }

    public void OnStartButton()
    {
        AudioManager.Instance.PlaySound(SoundType.Hover);
        transitionRenderer.gameObject.SetActive(true);
        transitionRenderer
            .DOFade(1, 0.6f)
            .OnComplete(() => GoToMenuScreen());
    }

    private void GoToMenuScreen()
    {
        SceneManager.LoadScene(Constants.MenuSceneId, LoadSceneMode.Single);
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        var mousePosition = Utils.Coordinates.GetMouseWorldPosition(Camera.main);
        background.position = new Vector3(mousePosition.x * 0.01f, mousePosition.y * 0.01f, 0);
        //var currentPosition = background.position;
        //float movementFactor = 0.2f;

        //var offsetX = Screen.width - mousePosition.x;
        //var offsetY = Screen.height - mousePosition.y;

        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        //Debug.Log(mousePosition);
        //Debug.Log(new Vector3(offsetX, offsetY, 0));
        //Debug.Log("======");

        //background.DOMove(new Vector3(offsetX, offsetY, 0), 0);

        //if (mousePosition.x > 0)
        //{
        //    currentPosition.x = movementFactor;
        //}

        //if (mousePosition.x < 0)
        //{
        //    currentPosition.x = -movementFactor;
        //}

        //if (mousePosition.x == 0)
        //{
        //    currentPosition.x = 0;
        //}

        //// Y axis
        //if (mousePosition.y > 0)
        //{
        //    currentPosition.y = movementFactor;
        //}

        //if (mousePosition.y < 0)
        //{
        //    currentPosition.y = -movementFactor;
        //}

        //if (mousePosition.y == 0)
        //{
        //    currentPosition.y = 0;
        //}

        //background.DOMove(currentPosition, 0.3f);
    }
}
