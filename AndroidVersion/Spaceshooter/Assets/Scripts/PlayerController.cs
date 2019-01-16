using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Vector3 movement;

    public GameObject controller;

    public float speed;
    public float xtilt;
    public Boundary boundary;

    public Transform shotSpawn;
    public GameObject bullet;

    public float fireRate;
    private float nextFire;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        Mathf.Clamp(movement.x, -1, 1);
        Mathf.Clamp(movement.y, -1, 1);
        GetComponent<Rigidbody>().velocity = movement * speed;
        movement /= 1.05f;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -xtilt);
    }

}