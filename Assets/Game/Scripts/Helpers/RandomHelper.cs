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

        public static T RandomInArray<T>(T[] array) {
            if(array == null) {
                return default(T);
            }
            return array[Random.Range(0, array.Length)];
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

        public static int RandomWithPercent(int[] probabilities) { // random trả về index chứa xác suất trúng
            int randomNumber = UnityEngine.Random.Range(1, 101);
            int currentProbability = 0;
            for(int i = 0; i < probabilities.Length; ++i) {
                if(randomNumber <= currentProbability + probabilities[i]) {
                    return i;
                }
                currentProbability += probabilities[i];
            }
            return -1;
        }

        public static void Shuffle<T>(List<T> list) {
            int n = list.Count;
            while(n > 1) {
                int k = Random.Range(0, n);
                n--;
                T temp = list[k];
                list[k] = list[n];
                list[n] = temp;
            }
        }

    }


}
