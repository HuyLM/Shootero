using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBase {
    #region References
    private PlayerAttack attackerPlayer;
    public PlayerAttack AttackerPlayer {
        get {
            if (attackerPlayer == null) {
                attackerPlayer = GetComponent<PlayerAttack>();
            }
            return attackerPlayer;
        }
    }

    private PlayerMove moverPlayer;
    public PlayerMove MoverPlayer {
        get {
            if (moverPlayer == null) {
                moverPlayer = GetComponent<PlayerMove>();
            }
            return moverPlayer;
        }
    }

    private PlayerHealth healtherPlayer;
    public PlayerHealth HealtherPlayer {
        get {
            if (healtherPlayer == null) {
                healtherPlayer = GetComponent<PlayerHealth>();
            }
            return healtherPlayer;
        }
    }

    private PlayerStat staterPlayer;
    public PlayerStat StaterPlayer {
        get {
            if (staterPlayer == null) {
                staterPlayer = GetComponent<PlayerStat>();
            }
            return staterPlayer;
        }
    }

    private PlayerTakeHit takeHitterPlayer;
    public PlayerTakeHit TakeHitterPlayer {
        get {
            if (takeHitterPlayer == null) {
                takeHitterPlayer = GetComponent<PlayerTakeHit>();
            }
            return takeHitterPlayer;
        }
    }


    private PlayerSkill skiller;
    public PlayerSkill SkillerPlayer {
        get {
            if (skiller == null) {
                skiller = GetComponent<PlayerSkill>();
            }
            return skiller;
        }
    }
    #endregion

    public override void Initalize() {
        base.Initalize();
        SkillerPlayer.Initalize();
    }

    public override void Countdown() {
        base.Countdown();
        SkillerPlayer.Countdown();
    }

    public override void Destroy() {
    }

    public override void Die() {
    }
}
