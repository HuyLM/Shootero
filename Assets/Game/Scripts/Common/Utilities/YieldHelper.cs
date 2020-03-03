using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Common.Utilities {
    public static class YieldHelper {
        private static readonly Dictionary<uint, WaitForSeconds> wfsCache = new Dictionary<uint, WaitForSeconds>(64);
        private static readonly WaitForEndOfFrame wfeofCache = new WaitForEndOfFrame();

        public static WaitForSeconds WaitForSeconds(float seconds) {
            if (seconds < 0f) {
                seconds = 0f;
            }

            uint miliseconds = (uint)(seconds * 1000);
            if (!wfsCache.ContainsKey(miliseconds)) {
                wfsCache.Add(miliseconds, new WaitForSeconds(seconds));
            }

            return wfsCache[miliseconds];
        }

        public static WaitForEndOfFrame WaitForEndOfFrame() {
            return wfeofCache;
        }
    }
}
