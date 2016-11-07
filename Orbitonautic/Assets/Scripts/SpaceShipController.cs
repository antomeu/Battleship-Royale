using UnityEngine;
using System.Collections;

public class SpaceShipController : MonoBehaviour
{
    public PlanetController Earth;
    public float speed;
    public Rigidbody SpaceShipRigidbody;

    public float GravitationalConstant = 6.6f * Mathf.Pow(10,-11);

    public GameObject ExplosionEffect;

    public Vector3 GravityRadius;

	// Use this for initialization
	void Start ()
    {
	
	}

    void Update()
    {
        speed =
            Mathf.Sqrt(GravitationalConstant*Earth.Mass/(Earth.transform.position - this.transform.position).magnitude);
        
        transform.RotateAround(Earth.transform.position, Vector3.back, Time.deltaTime * speed);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), speed.ToString());
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Calculate eliptic equation, apopsis, peripsis, from spaceship location, planet location and speed vector

        //Apply gravity force

        //SpaceShipRigidbody.AddForce((Earth.transform.position - this.transform.position).normalized,ForceMode.Force);

        //If thruster input is detected, apply force, and update trajectory visualization

    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionEffect, collision.transform.position, collision.transform.rotation);
        
    }
}
