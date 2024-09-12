using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private Transform borderRight;
    [SerializeField] private Transform borderLeft;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
            Spawn();
    }

    void Spawn()
    {
        float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);

        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        Instantiate(prefab, newPosition, Quaternion.identity);
        spawnTimer = spawnInterval;
    }
}
