using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject meteorPrefab, bigMeteorPrefab;
    private int meteorCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

    void SpawnMeteor()
    {
        meteorCount++;
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
}
