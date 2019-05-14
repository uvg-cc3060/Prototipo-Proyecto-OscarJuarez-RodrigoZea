using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float speed = 5f;

    // La pistola activamente deberia estar buscando la posicion del mouse o la stick del jugador
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        //Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        Debug.Log(transform.rotation);
    }
}
