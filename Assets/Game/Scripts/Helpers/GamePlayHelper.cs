using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Helper {
    public static class GamePlayHelper {
        public static Vector2 RotateDirection(Vector2 orgin, float angle) {
            return (Quaternion.AngleAxis(angle, Vector3.back) * orgin).normalized;
        }

    }
}