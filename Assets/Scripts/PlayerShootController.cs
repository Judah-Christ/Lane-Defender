using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public PlayerInput Player;
    private InputAction shooter;
    private Coroutine shoot;
    private bool isShooting;
    private float shootTimer;
    private float shootDelay;

    // public GameObject playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        Player.currentActionMap.Enable();
        shooter = Player.currentActionMap.FindAction("Shoot");

        shooter.started += Shooter_started;
        shooter.canceled += Shooter_canceled;

        isShooting = false;
        shootDelay = 2f;
    }

    private void Shooter_canceled(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private void Shooter_started(InputAction.CallbackContext context)
    {
        isShooting = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shoot == null)
            {
                shoot = StartCoroutine(CreateTheBullet());
            }
            else if (shootTimer > shootDelay)
            {
                {
                    shootTimer = 0;
                    shoot = StartCoroutine(CreateTheBullet());
                }
            }

        }
        else
        {

            shoot = StopAllCoroutines(CreateTheBullet);

        }
    }
    

    

    private Coroutine StopAllCoroutines(Func<IEnumerator> createTheBullet) => shoot = null;

    IEnumerator CreateTheBullet()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector2 bulletPos = new Vector2(transform.position.x + -.5f, transform.position.y + .4f);  //random pos
            bullet.transform.GetComponent<SpriteRenderer>().color = Color.black; //random color
            Instantiate(bullet, bulletPos, Quaternion.identity);

            yield return new WaitForSeconds(4f);
        }
     //   shoot = null;
    }

   

}

