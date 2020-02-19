using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
namespace PluggableAI {
    public static class PluggableAIHelper {
        public const string EnableLogsString = "ENABLE_LOGS";

        public static void DoAllAction<T>(this IEnumerable<Action<T>> actions, StateController<T> stateController) where T : CharacterBase{
            foreach(var action in actions) {
                action.Act(stateController);
            }
        }

        [Conditional(EnableLogsString)]
        public static void Log(string message, string nameCaller = null) {
            if (nameCaller != null) {
                UnityEngine.Debug.Log(string.Format("caller: {0}\n{1}", nameCaller, message));
            }
            else {
                UnityEngine.Debug.Log(message);
            }
        }

        [Conditional(EnableLogsString)]
        public static void LogWarning(string warning, string nameCaller = null) {
            if (nameCaller != null) {
                UnityEngine.Debug.LogWarning(string.Format("caller: {0}\n{1}", nameCaller, warning));
            } else {
                UnityEngine.Debug.LogWarning(warning);
            }
        }

        [Conditional(EnableLogsString)]
        public static void LogError(string error, string nameCaller = null) {
            if (nameCaller != null) {
                UnityEngine.Debug.LogError(string.Format("caller: {0}\n{1}", nameCaller, error));
            } else {
                UnityEngine.Debug.LogError(error);
            }
        }

        public static string AddColorToString(this string str, Color color) {
            return string.Format("<color=#{1}>{0}</color>", str, ColorUtility.ToHtmlStringRGBA(color));
        }


        public static int Random(int[] probabilities) {
            int randomNumber = UnityEngine.Random.Range(1, 101);

            int currentProbability = 0;
            for (int i = 0; i < probabilities.Length; ++i) {
                if(randomNumber < currentProbability + probabilities[i]) {
                    return i;
                }
                currentProbability += probabilities[i];
            }
            return -1;
        }

    }
}
