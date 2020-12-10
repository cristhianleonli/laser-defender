using UnityEngine;
using Utils;

public class MouseCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        var mousePosition = Coordinates.GetMouseWorldPosition(Camera.main);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
