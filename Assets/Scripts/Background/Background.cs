using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("Parallax")]
    [SerializeField] private float movementFactor = 0.03f;
    [SerializeField] private bool parallaxEnabled = true;

    private void Update()
    {
        if (parallaxEnabled)
        {
            MoveBackground();
        }
    }

    private void MoveBackground()
    {
        var mousePosition = Utils.Coordinates.GetMouseWorldPosition(Camera.main);

        float positionX = Mathf.Clamp(mousePosition.x * movementFactor, -1, 1);
        float positionY = Mathf.Clamp(mousePosition.y * movementFactor, -1, 1);

        transform.position = new Vector3(positionX, positionY);
    }
}
