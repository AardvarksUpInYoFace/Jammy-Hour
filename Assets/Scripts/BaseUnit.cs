using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public bool IsEnemy;
    public int Health;

    [HideInInspector]
    public int maxHealth;

    public System.Action OnChangeHealth;
    public System.Action<BaseUnit> OnDie;

    void Start()
    {
        maxHealth = Health;
    }

    public void ChangeHealth(int change)
    {
        Health += change;

        OnChangeHealth?.Invoke();

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
