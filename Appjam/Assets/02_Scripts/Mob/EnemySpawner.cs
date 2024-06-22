using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // ������ ���� ��
    public int numberOfEnemies = 10;

    // ���� �߽�
    public Transform centerPoint;

    // ���� ������
    public float radius = 10f;

    // ���� �ֱ�
    public float spawnInterval = 2f;

    void Start()
    {
        // �ڷ�ƾ ����
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ���� �ֱ⸸ŭ ���
            yield return new WaitForSeconds(spawnInterval);

            // �� ����
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
