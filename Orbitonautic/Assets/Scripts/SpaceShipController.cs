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


    public int segments = 64;
    public float xradius;
    public float yradius;
    public bool recalculate;
    LineRenderer line;

    // Use this for initialization
    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = true;

        xradius = (Earth.transform.position - this.transform.position).magnitude;
        yradius = xradius;
        CreatePoints();
    }

    void Update()
    {
        CaclulateNextPosition();

        if (recalculate)
        {
            CreatePoints();
            recalculate = false;
        }

    }

    void CaclulateNextPosition()
    {
        speed =
            Mathf.Sqrt(GravitationalConstant * Earth.Mass / (Earth.transform.position - this.transform.position).magnitude);

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

    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionEffect, collision.transform.position, collision.transform.rotation);
        
    }
}
