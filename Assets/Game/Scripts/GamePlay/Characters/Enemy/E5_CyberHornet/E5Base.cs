
public class E5Base : EnemyBase {
    private E5Attack attackerE5;
    public E5Attack AttackerE5 {
        get {
            if (attackerE5 == null) {
                attackerE5 = GetComponent<E5Attack>();
            }
            return attackerE5;
        }
    }

    private E5Move moverE5;
    public E5Move MoverE5 {
        get {
            if (moverE5 == null) {
                moverE5 = GetComponent<E5Move>();
            }
            return moverE5;
        }
    }

    private E5Health healtherE5;
    public E5Health HealtherE5 {
        get {
            if (healtherE5 == null) {
                healtherE5 = GetComponent<E5Health>();
            }
            return healtherE5;
        }
    }

    private E5Stat staterE5;
    public E5Stat StaterE5 {
        get {
            if (staterE5 == null) {
                staterE5 = GetComponent<E5Stat>();
            }
            return staterE5;
        }
    }

    private E5TakeHit takehitterE5;
    public E5TakeHit TakehitterE5 {
        get {
            if (takehitterE5 == null) {
                takehitterE5 = GetComponent<E5TakeHit>();
            }
            return takehitterE5;
        }
    }
}