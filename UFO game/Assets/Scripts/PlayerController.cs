using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float Speed;
    private GameController gameController;
    private Rigidbody2D rb2d;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * Speed;
        rb2d.AddForce(movement);
        Debug.Log(moveHorizontal);
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
