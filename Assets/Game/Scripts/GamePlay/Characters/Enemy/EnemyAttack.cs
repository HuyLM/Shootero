
public abstract class EnemyAttack : CharacterAttack
{
    private EnemyBase enemyBase;
    public EnemyBase EnemyBase
    {
        get
        {
            if(enemyBase == null)
            {
                enemyBase = GetComponent<EnemyBase>();
            }
            return enemyBase;
        }
    }
    public virtual void Attack()
    {

    }

    public virtual bool CanAttack()
    {
        return true;
    }
}
