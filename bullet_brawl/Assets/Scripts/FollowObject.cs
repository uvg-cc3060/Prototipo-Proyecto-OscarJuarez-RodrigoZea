using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public Transform target;
    public float speed = 30;

	void Start () {
	
	}
	
	void Update () 
    {
        transform.position = InterpolationLibrary.AccelerationInterpolation(transform.position, target.position, Time.deltaTime, speed);
	}
}
