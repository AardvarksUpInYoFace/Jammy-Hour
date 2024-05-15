using UnityEngine;

public class RatUnit : BaseUnit
{
    public int Cost = 2;
    public float Speed = 2;
    public int Damage= 5;

    float _attackCooldown = 2.5f, _attackCapacitor;

    void Update()
    {
        if(_attackCapacitor >= 0)
        {
            _attackCapacitor = Mathf.Max(0, _attackCapacitor - Time.deltaTime);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, IsEnemy ? Vector2.left : Vector2.right, 1);

        // If it hits something...
        if (hit.collider != null)
        {
            var unit = hit.collider.GetComponent<BaseUnit>();

            if (IsEnemy != unit.IsEnemy)
                Attack(unit);

            return;
        }
        else
            transform.position += new Vector3(Speed * Time.deltaTime * (IsEnemy ? -1 : 1), 0 , 0);
    }

    void Attack(BaseUnit unit)
    {
        if(_attackCapacitor == 0)
        {
            //play attack animation first
            unit.ChangeHealth(-Damage);

            _attackCapacitor = _attackCooldown;
        }
    }
}
