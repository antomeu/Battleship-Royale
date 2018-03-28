using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;


namespace Assets.Scripts
{
    public class GLLineOnCameraRendrerer : MonoBehaviour
    {
        [Header("External References")]
        public Shader shader;
        public static Material material;
        public GameManager GameManager;


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
            foreach(Trajectory trajectory in GameManager.Trajectories)
            {
                for (int i = 0; i < trajectory.Positions.Length - 1; i++)
                {
                    GL.Vertex3(trajectory.Positions[i].x, trajectory.Positions[i].y, trajectory.Positions[i].z);
                }
            }


            GL.End();
            //GL.PopMatrix();
        }



    }
}