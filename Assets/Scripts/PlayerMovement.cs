using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput Player;
    private InputAction movement;

    public GameObject tank;
    private bool isTankMoving;
    public float speed = 10;
    private float moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        Player.currentActionMap.Enable();
        movement = Player.currentActionMap.FindAction("Movement");

        movement.started += Move_started;
        movement.canceled += Move_canceled;

        isTankMoving = false;
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        isTankMoving = false;
    }

    private void Move_started(InputAction.CallbackContext context)
    {
        isTankMoving = true;
    }

    // Update is called once per frame
     private void FixedUpdate()
    {
        if ( isTankMoving)
        {
            tank.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed * moveDirection);
        }
        else
        {
            tank.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void Update()
    {
       if (isTankMoving)
        {
            moveDirection = movement.ReadValue<float>();
        }
    }
}
