using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public static int Count;

    float _timeCooldown = 0.5f, _timeCapacitor;

    public TextMeshProUGUI label;

    void Update()
    {
        label.text = Count.ToString();

        _timeCapacitor = Mathf.Max(0, _timeCapacitor - Time.deltaTime);

        if (_timeCapacitor == 0)
            GiveTrash();
    }

    void GiveTrash()
    {
        _timeCapacitor = _timeCooldown;

        Count += 1;
    }
}
