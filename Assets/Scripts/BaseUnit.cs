using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public bool IsEnemy;
    public int Health;

    public System.Action<BaseUnit> OnDie;

    public void ChangeHealth(int change)
    {
        Health += change;

        if (Health <= 0)
            Die();
    }

    void Die()
    {
        //play particle effect
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
