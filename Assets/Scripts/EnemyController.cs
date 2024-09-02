using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
     public GameObject enemy;
    private Rigidbody2D rb;
    private float enemyPosX;
    private int health;
    private GameController gameController;
    public Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(1, 3); ;
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindAnyObjectByType<GameController>();
        StartCoroutine(CreatetheEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        rb.GetComponent<Rigidbody2D>().velocity = move;
        if (rb.position.x <- 8)
        {
            gameController.LoseALife();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if(health == 0)
            {
                Destroy(gameObject);
                gameController.updateScore();
            }
           
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameController.LoseALife();
        }
    }

    IEnumerator CreatetheEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
               for (int i = 0; i < 1; i++)
               {
                     Vector2 enemyPos = new Vector2(transform.position.x + Random.Range(5, 10f), transform.position.y + Random.Range(-5f,5f));  //random pos
                     Instantiate(enemy, enemyPos, Quaternion.identity);
                
                
               }
               
         }
    }
}
