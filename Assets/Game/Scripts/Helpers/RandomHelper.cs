using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Helper {
    public static class RandomHelper {

        public static T RandomInCollection<T>(List<T> list) {
            if(list == null) {
                return default(T);
            }
            return list[Random.Range(0, list.Count)];
        }

        public static T RandomInCollection<T>(T[] array) {
            if(array == null) {
                return default(T);
            }
            return array[Random.Range(0, array.Length)];
        }

        public static T[] RandomInCollection<T>(T[] array, int number, bool duplicate = false)
        {
            if(!duplicate && array.Length < number)
            {
                Logs.LogError("Can't Random Collection because out of range");
                return null;
            }
            T[] result = new T[number];
            List<int> indexs = new List<int>();
            for(int i = 0; i < number; ++i)
            {
                int randomIndex = Random.Range(0, array.Length);
                if(!duplicate)
                {
                    while(indexs.Contains(randomIndex))
                    {
                        randomIndex = Random.Range(0, array.Length);
                    }
                    indexs.Add(randomIndex);
                }
                else
                {
                    indexs.Add(randomIndex);
                }
                result[i] = array[randomIndex];
            }

            return result;
        }

        public static List<T> RandomInCollection<T>(List<T> list, int number, bool duplicate = false)
        {
            if (!duplicate && list.Count < number)
            {
                Logs.LogError("Can't Random Collection because out of range");
                return null;
            }
            List<T> result = new List<T>();
            List<int> indexs = new List<int>();
            for (int i = 0; i < number; ++i)
            {
                int randomIndex = Random.Range(0, list.Count);
                if (!duplicate)
                {
                    while (indexs.Contains(randomIndex))
                    {
                        randomIndex = Random.Range(0, list.Count);
                    }
                    indexs.Add(randomIndex);
                }
                else
                {
                    indexs.Add(randomIndex);
                }
                result.Add(list[randomIndex]);
            }

            return result;
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

        public static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = Random.Range(0, n);
                n--;
                T temp = array[k];
                array[k] = array[n];
                array[n] = temp;
            }
        }

    }


}
