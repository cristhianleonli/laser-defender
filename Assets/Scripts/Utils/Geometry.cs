using UnityEngine;

namespace Utils
{
    public static class Geometry
    {
        public static float HypotenuseLength(float sideALength, float sideBLength)
        {
            return Mathf.Sqrt(sideALength * sideALength + sideBLength * sideBLength);
        }

        public static float RotationAngle(Vector3 origin, Vector3 destination)
        {
            Vector3 aimDirection = (origin - destination).normalized;
            var rotationAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            return rotationAngle;
        }
    }
}