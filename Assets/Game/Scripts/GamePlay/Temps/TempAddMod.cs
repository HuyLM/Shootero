using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAddMod : MonoBehaviour
{
    [SerializeField] private PlayerBase player;
    [SerializeField] private ModData Mod1;
    [SerializeField] private ModData Mod2;
    [SerializeField] private ModData Mod3;


    [ContextMenu("bulletup")]
    private void ADd1() {
        Mod1.ApplyTo(player);
    }

    [ContextMenu("Focus")]
    private void ADd2() {
        Mod2.ApplyTo(player);
    }

    [ContextMenu("BurnShot")]
    private void ADd3() {
        Mod3.ApplyTo(player);
    }
}
