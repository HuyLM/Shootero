using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBase {

    #region References
    private PlayerAttack attackerPlayer;
    public PlayerAttack AttackerPlayer {
        get {
            if(attackerPlayer == null) {
                attackerPlayer = GetComponent<PlayerAttack>();
            }
            return attackerPlayer;
        }
    }

    private PlayerMove moverPlayer;
    public PlayerMove MoverPlayer {
        get {
            if(moverPlayer == null) {
                moverPlayer = GetComponent<PlayerMove>();
            }
            return moverPlayer;
        }
    }

    private PlayerHealth healtherPlayer;
    public PlayerHealth HealtherPlayer {
        get {
            if(healtherPlayer == null) {
                healtherPlayer = GetComponent<PlayerHealth>();
            }
            return healtherPlayer;
        }
    }

    private PlayerStat staterPlayer;
    public PlayerStat StaterPlayer {
        get {
            if(staterPlayer == null) {
                staterPlayer = GetComponent<PlayerStat>();
            }
            return staterPlayer;
        }
    }

    private PlayerTakeHit takeHitterPlayer;
    public PlayerTakeHit TakeHitterPlayer {
        get {
            if(takeHitterPlayer == null) {
                takeHitterPlayer = GetComponent<PlayerTakeHit>();
            }
            return takeHitterPlayer;
        }
    }


    private PlayerSkill skillerPlayer;
    public PlayerSkill SkillerPlayer {
        get {
            if(skillerPlayer == null) {
                skillerPlayer = GetComponent<PlayerSkill>();
            }
            return skillerPlayer;
        }
    }

    private PlayerLevel levelerPlayer;
    public PlayerLevel LevelerPlayer {
        get {
            if(levelerPlayer == null) {
                levelerPlayer = GetComponent<PlayerLevel>();
            }
            return levelerPlayer;
        }
    }
    #endregion

    private Action<int> onChipChanged;
    private int chipCollection;

    public int ChipCollection { get => chipCollection; }

    public void AddOnChipChanged(Action<int> onChipChanged) {
        this.onChipChanged += onChipChanged;
    }

    public void RemoveOnChipChanged(Action<int> onChipChanged) {
        this.onChipChanged -= onChipChanged;
    }

    public void AddChip(int chip) {
        chipCollection += chip;
        onChipChanged?.Invoke(chipCollection);
    }

    public override void Destroy() {
    }

    public override void Die() {
        gameObject.SetActive(false);
        GameManager.Instance.Lose();
    }
}
