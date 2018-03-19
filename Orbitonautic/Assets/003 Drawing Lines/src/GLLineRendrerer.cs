using UnityEngine;
using System;
using System.Collections;

public class GLLineRendrerer : MonoBehaviour
{
    [Header("External References")]


    public Shader shader;
    public Vector3[] Positions;
    public static Material material;

    public int PositionCount 
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
        GL.PushMatrix();
        GL.MultMatrix(transform.transform.localToWorldMatrix);
        GL.Begin(GL.LINES);
        GL.Color(new Color(1, 1, 1, 1.4f));

        
        //foreach( orbit object)
        //for (int i = 0; i < Positions.Length-1; i++)
        //{
        //    GL.Vertex3(Positions[i].x, Positions[i].y, Positions[i].z);
        //}

        

        GL.End();
        //GL.PopMatrix();
    }



}
