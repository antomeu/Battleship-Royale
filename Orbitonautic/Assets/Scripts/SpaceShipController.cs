using UnityEngine;
using System.Collections;

public class SpaceShipController : MonoBehaviour
{
    public GameObject Planet;
    public float speed = 90f;

    public GameObject ExplosionEffect;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(Planet.transform.position, Vector3.back, Time.deltaTime* speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionEffect, collision.transform.position, collision.transform.rotation);
        
    }
}
