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
    }
}
