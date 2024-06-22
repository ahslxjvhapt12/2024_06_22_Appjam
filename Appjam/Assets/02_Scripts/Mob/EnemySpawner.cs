using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject boss;

    // 스폰할 적의 수
    public int numberOfEnemies = 3;

    // 원의 중심
    public Transform centerPoint;

    // 원의 반지름
    public float radius = 10f;

    // 스폰 주기
    public float spawnInterval = 4f;

    private int spawnCount = 3;
    private int count = 0;
    public bool last = false;

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(SpawnEnemies());
    }
    void Update()
    {
        if (last)
        {
            Instantiate(boss, centerPoint.position + new Vector3(0, 28, 0), Quaternion.identity);
            Destroy(gameObject);
        }
        numberOfEnemies = Mathf.Clamp(spawnCount, 3, 30);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 스폰 주기만큼 대기
            yield return new WaitForSeconds(spawnInterval);

            // 적 스폰
            SpawnEnemiesInCircle();
        }
    }

    void SpawnEnemiesInCircle()
    {
        if (spawnCount >= 50 || last == true)
        {
            last = true;
            StopCoroutine(SpawnEnemies());
            return;
        }
        spawnCount++;
        Debug.Log(spawnCount);
        float angleStep = 360f / numberOfEnemies;
        float angle = 0f;
        char first = spawnCount.ToString()[0];
        int spawn = int.Parse(first.ToString());
        for (int i = 0; i < numberOfEnemies; i++)
        {
            
            float enemyX = centerPoint.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float enemyY = centerPoint.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

            Vector2 enemyPosition = new Vector2(enemyX, enemyY);

            Instantiate(enemyPrefab[spawn], enemyPosition, Quaternion.identity);

            angle += angleStep;
            if (spawnCount >= 10 && spawnCount / 2 == 0)
            {
                Instantiate(enemyPrefab2, enemyPosition, Quaternion.identity);
                Instantiate(enemyPrefab3, enemyPosition, Quaternion.identity);
            }
        }
    }
}
