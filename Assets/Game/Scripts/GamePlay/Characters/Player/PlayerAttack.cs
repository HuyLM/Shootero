using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : CharacterAttack
{
    [SerializeField] private PlayerBasicComponent basicAttack;

    private PlayerAttackComponent currentAttackComponent;

    private PlayerBase playerBase;
    public PlayerBase PlayerBase {
        get {
            if(playerBase == null) {
                playerBase = GetComponent<PlayerBase>();
            }
            return playerBase;
        }
    }

    public override void Initalize() {
        base.Initalize();
        ChangeAttackComponent(basicAttack);
    }

    public void ChangeAttackComponent(PlayerAttackComponent newAttackComponent) {
        if(currentAttackComponent != null) {
#if UNITY_EDITOR
            DestroyImmediate(currentAttackComponent.gameObject);
#else
            Destroy(currentAttackComponent.gameObject);
#endif
        }
        currentAttackComponent = Instantiate(newAttackComponent, transform);
        currentAttackComponent.SetPlayerAttack(this);
        currentAttackComponent.Initalize();
    }

    public void Attack() {
        if(currentAttackComponent != null) {
            currentAttackComponent.Attack();
        }
    }

    public void UpgradeAttackComponent() {
        if(currentAttackComponent != null) {
            currentAttackComponent.Upgrade();
        }
    }

    public void FocusUpgradeAttackComponent() {
        if (currentAttackComponent != null) {
            currentAttackComponent.FocusUpgrade();
        }
    }

    public override void Countdown() {
        base.Countdown();
        if (currentAttackComponent != null) {
            currentAttackComponent.Countdown();
        }
    }
}
