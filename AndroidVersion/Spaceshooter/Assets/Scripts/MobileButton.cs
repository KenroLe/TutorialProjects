using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileButton : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    Vector2 movement2d;
    Vector2 startPos;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

    }

    private void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                startPos = myTouch.position;
            }

            movement2d = myTouch.position - startPos;
            playerController.movement.x = movement2d.x / 100;
            playerController.movement.z = movement2d.y / 100;
            Debug.Log(playerController.movement);
        }
    }
}
