using UnityEngine;
using System.Collections;

public class GLLineRendrerer : MonoBehaviour
{

    public Shader shader;
    public Vector3 Positions;
    private static Material material;
    private GameObject gameObject;
    private float speed = 100.0f;
    private Vector3[] lp;
    private Vector3[] sp;
    private Vector3 s;

    public int positionCount 
    { 
        get; 
        set; 
    }

    public void SetPosition(int index, Vector3 position)
    {

    }



    void Start()
    {




        material = new Material(shader);
        gameObject = new GameObject("g");
        lp = new Vector3[0];
        sp = new Vector3[0];
    }



    /** Replace the Update function with this one for a click&drag drawing option */
    void Update1()
    {
        Vector3 e;

        if (Input.GetMouseButtonDown(0))
        {
            s = GetNewPoint();
        }

        if (Input.GetMouseButton(0))
        {
            e = GetNewPoint();
            lp = AddLine(lp, s, e, true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            e = GetNewPoint();
            lp = AddLine(lp, s, e, false);
        }
    }

    Vector3[] AddLine(Vector3[] l, Vector3 s, Vector3 e, bool tmp)
    {
        int vl = l.Length;
        if (!tmp || vl == 0) l = resizeVertices(l, 2);
        else vl -= 2;

        l[vl] = s;
        l[vl + 1] = e;
        return l;
    }

    Vector3[] resizeVertices(Vector3[] ovs, int ns)
    {
        Vector3[] nvs = new Vector3[ovs.Length + ns];
        for (int i = 0; i < ovs.Length; i++) nvs[i] = ovs[i];
        return nvs;
    }

    Vector3 GetNewPoint()
    {
        return gameObject.transform.InverseTransformPoint(
            Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1.0f)
            )
        );
    }

    void OnPostRender()
    {
        material.SetPass(0);
        GL.PushMatrix();
        GL.MultMatrix(gameObject.transform.transform.localToWorldMatrix);
        GL.Begin(GL.LINES);
        GL.Color(new Color(0, 0, 0, 0.4f));

        for (int i = 0; i < lp.Length; i++)
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
