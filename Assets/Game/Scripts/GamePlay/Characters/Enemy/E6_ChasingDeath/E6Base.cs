
public class E6Base : EnemyBase {
    private E6Attack attackerE6;
    public E6Attack AttackerE6 {
        get {
            if (attackerE6 == null) {
                attackerE6 = GetComponent<E6Attack>();
            }
            return attackerE6;
        }
    }

    private E6Move moverE6;
    public E6Move MoverE6 {
        get {
            if (moverE6 == null) {
                moverE6 = GetComponent<E6Move>();
            }
            return moverE6;
        }
    }

    private E6Health healtherE6;
    public E6Health HealtherE6 {
        get {
            if (healtherE6 == null) {
                healtherE6 = GetComponent<E6Health>();
            }
            return healtherE6;
        }
    }

    private E6Stat staterE6;
    public E6Stat StaterE6 {
        get {
            if (staterE6 == null) {
                staterE6 = GetComponent<E6Stat>();
            }
            return staterE6;
        }
    }

    private E6TakeHit takehitterE6;
    public E6TakeHit TakehitterE6 {
        get {
            if (takehitterE6 == null) {
                takehitterE6 = GetComponent<E6TakeHit>();
            }
            return takehitterE6;
        }
    }
}