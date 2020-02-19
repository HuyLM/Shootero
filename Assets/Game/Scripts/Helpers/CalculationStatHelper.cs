using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Helper {
    public static class CalculationStatHelper {
        public static int DamageFromBullet(int BDPercent, int attack) {
            return (int)(BDPercent * attack / 100f);
        }

        public static int DamageFromCollision(int attack, float collidedmg) {
            return (int)(attack * (1 + collidedmg));
        }
    }
}
