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

            


            //foreach( orbit object)
            //for (int i = 0; i < Positions.Length-1; i++)
            //{
            //    GL.Vertex3(Positions[i].x, Positions[i].y, Positions[i].z);
            //}
            foreach(TrajectoryController trajectory in GameManager.Trajectories)
            {
                
                material = trajectory.LineMaterial  ;
                GL.PushMatrix();
                material.SetPass(0);

                GL.MultMatrix(GameManager.GravityController.transform.localToWorldMatrix);
                GL.Begin(GL.LINES);

                GL.Color(256*trajectory.LineColor);
                for (int i = 0; i < trajectory.Positions.Length - 2; i++)
                {
                    GL.Vertex3(trajectory.Positions[i].x, trajectory.Positions[i].y, trajectory.Positions[i].z);
                    GL.Vertex3(trajectory.Positions[i+1].x, trajectory.Positions[i+1].y, trajectory.Positions[i+1].z);
                }

                GL.End();
                GL.PopMatrix();
            }



        }



    }
}