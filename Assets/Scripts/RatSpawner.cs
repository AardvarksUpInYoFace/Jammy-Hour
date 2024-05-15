using UnityEngine;
using System.Collections.Generic;

public class RatSpawner : MonoBehaviour
{
    public List<GameObject> rats = new List<GameObject>();

    public float SpawnCooldownMin = 1, SpawnCooldownMax = 5;

    float _spawnCapacitor;

    public Transform spawnPosition;

    void Start()
    {
        SetSpawnTimer();
    }

    void SetSpawnTimer()
    {
        _spawnCapacitor = Random.Range(SpawnCooldownMin, SpawnCooldownMax);
    }

    void Update()
    {
        _spawnCapacitor = Mathf.Max(0, _spawnCapacitor - Time.deltaTime);

        if (_spawnCapacitor == 0)
            SpawnRat();
    }

    void SpawnRat()
    {
        var obj = Instantiate(rats[Random.Range(0, rats.Count)]);
        var comp = obj.GetComponent<BaseUnit>();
        obj.transform.position = spawnPosition.position;
        comp.IsEnemy = true;
        comp.GetComponent<SpriteRenderer>().flipX = true;

        SetSpawnTimer();
    }
}
