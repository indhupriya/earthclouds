using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using ShadowEngine;

namespace Solar
{
    enum Planets
    { Sun, Clouds, Black }


    public struct Position
    {
        public float x;
        public float y;
        public float z;

        public Position(int x,int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class SolarSystem
    {
        Camara camara = new Camara();
        Star estrella = new Star();
        Sun sol = new Sun();
        List<Planet> planetas = new List<Planet>();
       

        public void CreateScene()
        {
           
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
           
            planetas.Add(new Planet(1f, Planets.Sun, new Position(9, 0, 0), "lifeline2.jpg", false));
            planetas.Add(new Planet(1.2f, Planets.Clouds, new Position(0, 0, 0), "Sky_horiz_18.jpg", true));
           // planetas.Add(new Planet(1.5f, Planets.Black, new Position(0, 0, 0), "EarthAtNight-Best.gif", true));          
            estrella.CreateStars(500);
            sol.Create();
            foreach (var item in planetas)
            {
                item.Create();  
            }
        }

        public Camara Camara
        {
            get { return camara; }
        }

        public void DrawScene()
        {  
            
            estrella.Draw();
            sol.Paint();
            foreach (var item in planetas)
            {
                item.Paint(); 
            }
        }
    }
}
