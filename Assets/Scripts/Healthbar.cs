using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public BaseUnit unit;
    public Image image;

    void Start()
    {
        if (unit == null)
            unit = transform.parent.parent.GetComponent<BaseUnit>();

        unit.OnChangeHealth += ChangingHealth;
    }

    void ChangingHealth()
    {
        image.fillAmount = (float)unit.Health / unit.maxHealth;
    }
}
