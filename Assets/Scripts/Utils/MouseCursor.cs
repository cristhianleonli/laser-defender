using UnityEngine;
using Utils;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private bool isCursorVisible = false;

    void Start()
    {
        if (!isCursorVisible)
        {
            Cursor.visible = false;
        }
    }

    void Update()
    {
        var mousePosition = Coordinates.GetMouseWorldPosition(Camera.main);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
}
