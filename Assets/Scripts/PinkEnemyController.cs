using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Coroutine walk;
    private Rigidbody2D rb;
    public Vector2 moves;
    private float spawnTimer;
    private float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        spawnDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        rb.GetComponent<Rigidbody2D>().velocity = moves;
        if (spawnTimer > spawnDelay && walk == null)
        {

            spawnTimer = 0;
            StartCoroutine(CreatetheEnemy());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator CreatetheEnemy()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector2 enemyPos = new Vector2(transform.position.x + 10f, transform.position.y);  //random pos
            Instantiate(enemy, enemyPos, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
        walk = null;
    }
}
