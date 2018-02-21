using UnityEngine;
using System;
using System.Collections;

public class GLLineRendrerer : MonoBehaviour
{

    public Shader shader;
    public Vector3[] Positions;
    public static Material material;

    public int positionCount 
    { 
        get
        {
            return Positions.Length;
        }
        set
        {
            Array.Resize(ref Positions, value);
        }
    }

    public void SetPosition(int index, Vector3 position)
    {
        Positions[index] = position;
    }
    
    void Start()
    {

        material = new Material(shader);

    }
    
    void OnPostRender()
    {
        material.SetPass(0);
        //GL.PushMatrix();
        //GL.MultMatrix(transform.transform.localToWorldMatrix);
        GL.Begin(GL.LINES);
        GL.Color(new Color(1, 1, 1, 1.4f));

        GL.Vertex3(transform.position.x, transform.position.y, transform.position.z);

        GL.Vertex3(transform.position.x + 1000f, transform.position.y, transform.position.z);

        //for (int i = 0; i < Positions.Length-1; i++)
        //{
        //    GL.Vertex3(Positions[i].x, Positions[i].y, Positions[i].z);
        //}


        //for (int i = 1; i < Positions.Length; i++)
        //{
        //    GL.Vertex3(Positions[i].x, Positions[i].y, Positions[i].z);
        //}

        GL.End();
        //GL.PopMatrix();
    }



}
