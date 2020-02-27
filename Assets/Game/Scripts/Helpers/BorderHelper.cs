

using System.Collections.Generic;
using UnityEngine;

namespace Helper {
    public static class BorderHelper {
        private static List<EdgeBorder> GetListEdgeBorderSpawn(AreaType type, float offset) {
            int w = GamePlayConfig.borderW;
            int h = GamePlayConfig.borderH;
            Vector2 topLeft = new Vector2(-(w / 2.0f + offset), h / 2.0f + offset);
            Vector2 topRight = new Vector2((w / 2.0f + offset), h / 2.0f + offset);
            Vector2 botLeft = new Vector2(-(w / 2.0f + offset), -(h / 2.0f + offset));
            Vector2 botRight = new Vector2(w / 2.0f + offset, -(h / 2.0f + offset));

            List<EdgeBorder> edges = new List<EdgeBorder>();
            EdgeBorder top = new EdgeBorder(topLeft, topRight);
            edges.Add(top);
            float value = 0;
            switch (type) {
                case AreaType.All: {
                    value = 1;
                    EdgeBorder bot = new EdgeBorder(botLeft, botRight);
                    edges.Add(bot);
                    break;
                }
                case AreaType.OneHalf: {
                    value = 0.5f;
                    break;
                }
                case AreaType.OneThirds: {
                    value = 0.33f;
                    break;
                }
                case AreaType.TwoThirds: {
                    value = 0.66f;
                    break;
                }
                case AreaType.OneQuarter: {
                    value = 0.25f;
                    break;
                }
                case AreaType.ThreeQuarter: {
                    value = 0.75f;
                    break;
                }
                case AreaType.RandomTop: {
                    return edges;
                }
            }

            EdgeBorder left = new EdgeBorder();
            left.begin = topLeft;
            EdgeBorder right = new EdgeBorder();
            right.begin = topRight;

            left.end = Vector2.Lerp(topLeft, botLeft, value);
            right.end = Vector2.Lerp(topRight, botRight, value);

            edges.Add(left);
            edges.Add(right);

            return edges;
        }

        public static Vector2 GetRandomPositionBorder(AreaType type, float offset = 1) {
            if(type == AreaType.MidTop) {
                return new Vector2(0, GamePlayConfig.borderH / 2.0f + offset);
            }
            List<EdgeBorder> list = GetListEdgeBorderSpawn(type, offset);
            EdgeBorder edge = RandomHelper.RandomInList<EdgeBorder>(list);
            float lerpValue = Random.value;
            return Vector2.Lerp(edge.begin, edge.end, lerpValue);
        }

        private static Vector2 GetPointMinArea(AreaType type) {
            int w = GamePlayConfig.borderW;
            int h = GamePlayConfig.borderH;

            float value = 0;
            switch (type) {
                case AreaType.All: {
                    value = 1;
                    break;
                }
                case AreaType.OneHalf: {
                    value = 0.5f;
                    break;
                }
                case AreaType.OneThirds: {
                    value = 0.33f;
                    break;
                }
                case AreaType.TwoThirds: {
                    value = 0.66f;
                    break;
                }
                case AreaType.OneQuarter: {
                    value = 0.25f;
                    break;
                }
                case AreaType.ThreeQuarter: {
                    value = 0.75f;
                    break;
                }
            }

            return new Vector2(-w / 2, h / 2 - h * value);
        }

        private static Vector2 GetPointMaxArea() {
            int w = GamePlayConfig.borderW;
            int h = GamePlayConfig.borderH;
            return new Vector2(w / 2, h / 2);
        }

        public static Vector2 GetPoinRandomInArea(AreaType type) {
            Vector2 min = GetPointMinArea(type);
            Vector2 max = GetPointMaxArea();
            Vector2 result = new Vector2();
            result.x = Random.Range(min.x, max.x);
            result.y = Random.Range(min.y, max.y);
            return result;
        }

    }

    public struct EdgeBorder {
        public Vector2 begin;
        public Vector2 end;

        public EdgeBorder(Vector2 begin, Vector2 end) {
            this.begin = begin;
            this.end = end;
        }
    }

}
public enum AreaType {
    All = 0, OneHalf = 1, OneThirds = 2, TwoThirds = 3, OneQuarter = 4, ThreeQuarter = 5,
    MidTop = 6, RandomTop = 7
}
