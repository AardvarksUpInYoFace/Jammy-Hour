using UnityEngine;

public class RatButton : MonoBehaviour
{
    public GameObject ratPrefab;
    public Transform spawnPosition;

    int _cost;

    void Start()
    {
        _cost = ratPrefab.GetComponent<RatUnit>().Cost;
    }

    public void SpawnRat()
    {
        if(TrashCounter.Count >= _cost)
        {
            TrashCounter.Count -= _cost;
            var obj = Instantiate(ratPrefab);
            var comp = obj.GetComponent<BaseUnit>();
            obj.transform.position = spawnPosition.position;
            comp.IsEnemy = false;
            comp.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
