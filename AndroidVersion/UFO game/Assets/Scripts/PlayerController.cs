using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float Power;
    private GameController gameController;
    private Rigidbody2D rb2d;
    private Vector2 startPos;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, 0);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            movement = touch.deltaPosition;
        }

        Mathf.Sign(movement.x);
        Mathf.Sign(movement.y);
        rb2d.AddForce(movement*Power);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            gameController.AddScore();
            Destroy(collision.gameObject);
        }
    }
}
