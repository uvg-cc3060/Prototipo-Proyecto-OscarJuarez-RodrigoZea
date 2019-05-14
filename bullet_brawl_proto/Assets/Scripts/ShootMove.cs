using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int speed;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = transform.parent.parent.parent.GetComponent<Rigidbody>();
        if (playerRB != null) {
            Debug.Log("asd");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (fireCountdown <= 0)
            {
                Shoot();
                playerRB.velocity = -transform.parent.parent.up * 5;
                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot() {
        GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody cloneRb = clone.GetComponent<Rigidbody>();
        //cloneRb.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        cloneRb.velocity = clone.transform.up * speed;
        Destroy(clone.gameObject, 2);
    }
}
