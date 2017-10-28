using UnityEngine;
using System.Collections;

public class CellestialBody : MonoBehaviour
{
    public float MassTimesGravityConstant = 36 * Mathf.Pow(10,3);
    public Transform PlanetMesh;
    public float Radius;
    
	void  Start()
    {
        float scale = Radius / 605f;
        PlanetMesh.transform.localScale = scale * Vector3.one;
    }
	
}
