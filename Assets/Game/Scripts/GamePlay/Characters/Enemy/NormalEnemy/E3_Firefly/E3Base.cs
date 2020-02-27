
public class E3Base : EnemyBase {
    private E3Attack attackerE3;
    public E3Attack AttackerE3 {
        get {
            if (attackerE3 == null) {
                attackerE3 = GetComponent<E3Attack>();
            }
            return attackerE3;
        }
    }

    private E3Move moverE3;
    public E3Move MoverE3 {
        get {
            if (moverE3 == null) {
                moverE3 = GetComponent<E3Move>();
            }
            return moverE3;
        }
    }

    private E3Health healtherE3;
    public E3Health HealtherE3 {
        get {
            if (healtherE3 == null) {
                healtherE3 = GetComponent<E3Health>();
            }
            return healtherE3;
        }
    }

    private E3Stat staterE3;
    public E3Stat StaterE3 {
        get {
            if (staterE3 == null) {
                staterE3 = GetComponent<E3Stat>();
            }
            return staterE3;
        }
    }

    private E3TakeHit takehitterE3;
    public E3TakeHit TakehitterE3 {
        get {
            if (takehitterE3 == null) {
                takehitterE3 = GetComponent<E3TakeHit>();
            }
            return takehitterE3;
        }
    }
}