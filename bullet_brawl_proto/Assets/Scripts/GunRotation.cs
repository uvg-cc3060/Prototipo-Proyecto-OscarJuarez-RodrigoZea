using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float speed = 5f;
    private float angleCorrection = 90;

    // La pistola activamente deberia estar buscando la posicion del mouse o la stick del jugador
    void Update()
    {

    	// Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    	// float midpoint = (transform.position - Camera.main.transform.position).magnitude * 1f;
     // 	transform.LookAt(mouseRay.origin + mouseRay.direction * midpoint);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - angleCorrection;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


        // Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Quaternion rotation = Quaternion.LookRotation(direction);
        // transform.rotation = rotation;
    }
}
