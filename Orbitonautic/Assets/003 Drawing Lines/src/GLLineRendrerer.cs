using UnityEngine;
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
            value = Positions.Length;
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
        GL.MultMatrix(gameObject.transform.transform.localToWorldMatrix);
        GL.Begin(GL.LINES);
        GL.Color(new Color(0, 0, 0, 0.4f));

        for (int i = 0; i < Positions.Length; i++)
        {
            GL.Vertex3(lp[i].x, lp[i].y, lp[i].z);
        }

        GL.Color(new Color(0, 0, 0, 0.1f));

        for (int i = 0; i < sp.Length; i++)
        {
            GL.Vertex3(sp[i].x, sp[i].y, sp[i].z);
        }

        GL.End();
        GL.PopMatrix();
    }



}
