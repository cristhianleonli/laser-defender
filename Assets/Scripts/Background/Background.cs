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
        transform.position = new Vector3(mousePosition.x * movementFactor, mousePosition.y * movementFactor, 0);
    }
}
