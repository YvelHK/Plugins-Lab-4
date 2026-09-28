using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
    }
}
