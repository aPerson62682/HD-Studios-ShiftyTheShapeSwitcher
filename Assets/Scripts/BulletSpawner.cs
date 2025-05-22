using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    public GameObject enemyPrefab2D;
    public string targetTag = "Bullet";
    public static BulletSpawner instance;

    void Awake()
    {
        instance = this;
    }

    public static void RespawnEnemy(Vector2 position)
    {
        if (instance != null)
        {
            instance.StartCoroutine(instance.SpawnEnemy(position));
        }
    }

    IEnumerator SpawnEnemy(Vector2 position)
    {
        yield return new WaitForSeconds(20f);

        if (enemyPrefab2D != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab2D, position, Quaternion.identity);
            newEnemy.tag = targetTag;
        }
        else
        {
            Debug.LogWarning("BulletSpawner: enemyPrefab2D is not assigned!");
        }
    }
}
