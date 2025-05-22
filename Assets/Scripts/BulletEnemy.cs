using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BulletEnemy : MonoBehaviour
{
    public Transform player;
    private float moveSpeed = 2.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 originalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        StartCoroutine(DespawnAndRespawn());
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (Vector2)(player.position - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator DespawnAndRespawn()
    {
        yield return new WaitForSeconds(10f);
        Vector2 spawnPos = originalPosition;
        Destroy(gameObject);
        BulletSpawner.RespawnEnemy(spawnPos); // Use the 2D spawner
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            Destroy(other.gameObject);

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
        }
    }
}
