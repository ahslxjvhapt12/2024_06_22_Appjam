using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject boss;

    // ������ ���� ��
    public int numberOfEnemies = 3;

    // ���� �߽�
    public Transform centerPoint;

    // ���� ������
    public float radius = 10f;

    // ���� �ֱ�
    public float spawnInterval = 4f;

    private int spawnCount = 3;
    private int count = 0;
    public bool last = false;

    void Start()
    {
        // �ڷ�ƾ ����
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
            // ���� �ֱ⸸ŭ ���
            yield return new WaitForSeconds(spawnInterval);

            // �� ����
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
