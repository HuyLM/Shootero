using UnityEngine;

namespace GameSystem.Common.Utilities {

    public static class Vector3Helper {
        public static float sqrMagnitudeXY(this Vector3 a) {
            return a.x * a.x + a.y * a.y;
        }
        public static float sqrMagnitudeXZ(this Vector3 a) {
            return a.x * a.x + a.z * a.z;
        }
        public static float sqrMagnitudeYZ(this Vector3 a) {
            return a.y * a.y + a.z * a.z;
        }
    }
}
