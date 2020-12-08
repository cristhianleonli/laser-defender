using UnityEngine;

namespace Utils
{
    public static class Coordinates
    {
        public static Vector3 GetMouseWorldPosition(Camera camera)
        {
            return GetMouseWorldPosition(camera, Input.mousePosition);
        }

        public static Vector3 GetMouseWorldPosition(Camera camera, Vector3 mousePosition)
        {
            return camera.ScreenToWorldPoint(mousePosition);
        }
    }
}