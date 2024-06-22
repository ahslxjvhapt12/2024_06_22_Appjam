using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // 스폰할 적의 수
    public int numberOfEnemies = 10;

    // 원의 중심
    public Transform centerPoint;

    // 원의 반지름
    public float radius = 10f;

    // 스폰 주기
    public float spawnInterval = 2f;

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(SpawnEnemies());
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
        float angleStep = 360f / numberOfEnemies;
        float angle = 0f;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            float enemyX = centerPoint.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float enemyY = centerPoint.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

            Vector2 enemyPosition = new Vector2(enemyX, enemyY);

            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

            angle += angleStep;
        }
    }
}
