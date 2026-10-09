using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefabs;
    int enemyCount;
    float radius = 8f;
    GameObject[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnEnemies()
    {
        //랜덤 생성을 하고 싶어서 ai의 도움을 받았습니다.
        enemyCount = Random.Range(10, 16);
        enemies = new GameObject[enemyCount];
        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i] = Instantiate(enemyPrefabs);
        }
        float angleOffset = (2 * Mathf.PI) / enemyCount;

        Vector3 center = Vector3.zero;

        for (int i = 0; i < enemyCount; i++)
        {
            float angle = i * angleOffset;

            Vector3 offset = new Vector3(
                Mathf.Sin(angle) * radius,
                Mathf.Cos(angle) * radius,
                0f
            );

            enemies[i].transform.position = center + offset;
        }
    }
}
