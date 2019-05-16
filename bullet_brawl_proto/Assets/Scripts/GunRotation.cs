using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float speed = 5f;
    private float angleCorrection = 90;

    private Camera mainCamera;
    private Vector3 moveInput;

    void Start()
    {
    	mainCamera = FindObjectOfType<Camera>();
    }

    // La pistola activamente deberia estar buscando la posicion del mouse o la stick del jugador
    void Update()
    {

    	Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    	Plane wallPlane = new Plane(Vector3.up, Vector3.zero);

    	float rayLength;

    	if (wallPlane.Raycast(cameraRay, out rayLength))
    	{
    		Vector3 pointToLook = cameraRay.GetPoint(rayLength);
    		Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
    		Debug.Log(pointToLook);

	        float angle = (Mathf.Atan2(pointToLook.z, pointToLook.x) * Mathf.Rad2Deg) - angleCorrection;
	        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    		// transform.LookAt(pointToLook);
    	}




    	// ESTA PORCION DE CODIGO FUNCIONA CUANDO LA CAMARA NO TIENE ROTACIÓN Y ESTÁ EN X=0, Y=0

     	// Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	    // float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - angleCorrection;
     	// Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     	// transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
