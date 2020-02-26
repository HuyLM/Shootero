using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Helper {
    public static class UnityHelper {
        public static T ChangeAlpha<T>(this T g, float newAlpha)
         where T : Graphic {
            var color = g.color;
            color.a = newAlpha;
            g.color = color;
            return g;
        }

        public static T ChangeColor<T>(this T g, Color color)
             where T : Graphic {
            g.color = color;
            return g;
        }

        public static List<T> Clone<T>(this List<T> listToClone) where T : System.ICloneable {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
