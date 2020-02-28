using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Helper {
    public static class RandomHelper {

        public static T RandomInList<T>(List<T> list) {
            if(list == null) {
                return default(T);
            }
            return list[Random.Range(0, list.Count)];
        }

        public static bool RandomWithPercent(int value) {
            return Random.Range(1, 101) >= value;
        }

        public static bool RandomWithPercent(float value) {
            return Random.Range(0, 100.0f) >= value;
        }

        public static int RandomInRange(RangeIntValue range) {
            return Random.Range(range.min, range.max + 1);
        }

        public static float RandomInRange(RangeFloatValue range) {
            return Random.Range(range.min, range.max);
        }
    }
}
