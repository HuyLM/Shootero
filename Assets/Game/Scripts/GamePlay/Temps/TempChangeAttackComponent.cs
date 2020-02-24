using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempChangeAttackComponent : MonoBehaviour
{
    [SerializeField] private PlayerBase player;
    [SerializeField] private PlayerPiercingGunComponent piercingComponent;
    [SerializeField] private PlayerSplitterComponent playerSplitterComponent;
    [SerializeField] private PlayerGatlingGunComponent playerGatlingGunComponent;


    [ContextMenu("Attack 1")]
    public void Attack1() {
        player.AttackerPlayer.ChangeAttackComponent(piercingComponent);
    }

    [ContextMenu("Attack 2")]
    public void Attack2() {
        player.AttackerPlayer.ChangeAttackComponent(playerSplitterComponent);
    }

    [ContextMenu("Attack 3")]
    public void Attack3() {
        player.AttackerPlayer.ChangeAttackComponent(playerGatlingGunComponent);
    }
}
