using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : CharacterAttack
{
    [SerializeField] private PlayerBasicComponent basicAttack;

    private PlayerAttackComponent currentAttackComponent;
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
        currentAttackComponent.Initalize();
    }

    public void Attack() {
        if(currentAttackComponent != null) {
            currentAttackComponent.Attack();
        }
    }

    public override void Countdown() {
        base.Countdown();
        if (currentAttackComponent != null) {
            currentAttackComponent.Countdown();
        }
    }
}
