using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using ShadowEngine;

namespace Solar
{
    class Planet
    {
        Planets tipo;
        Position p;
        float anguloRotacion;
        float anguloOrbita;
        float radio;
        int list;
        static Random r = new Random();
        float velocidadOrbita;
        string texture;
       


        public Planet(float radio, Planets tipo, Position posision, string texture,bool hasMoon)
        {
            this.radio = radio;
            this.tipo = tipo;
            p = posision;
            anguloOrbita = r.Next(360);
            velocidadOrbita = (float)r.NextDouble() * 0.3f;
            this.texture = texture;
             
        }

        public void Create()
        {
          
            float[]  whiteLight = new float[]{ 0.2f, 0.2f, 0.2f, 1.0f };
	float[]  sourceLight = new float[]{ 0.8f, 0.8f, 0.8f, 1.0f };
	float[]	 lightPos = new float[]{ 12.0f, 0.0f, 0.0f, 1.0f };
            Glu.GLUquadric quadratic = Glu.gluNewQuadric(); 
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1); 
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(270, 1, 0, 0);
            Gl.glEnable(Gl.GL_LIGHTING);
            //Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);	// Hidden surface removal
	Gl.glFrontFace(Gl.GL_CCW);		// Counter clock-wise polygons face out
    Gl.glEnable(Gl.GL_CULL_FACE);
    Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, whiteLight);
    Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, sourceLight);
    Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos);
    Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
	
	// Set Material properties to follow glColor values
	Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

	// Black blue background
	//Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f );}

            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, qaLightPosition);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
            Glu.gluSphere(quadratic, radio, 32, 32); 
            Gl.glPopMatrix();
            Gl.glEndList();
            if (tipo == Planets.Sun)
            {
            
            }
        }

        public void DrawOrbit()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);

            for (int i = 0; i < 361; i++)
            {
                Gl.glVertex3f(p.x * (float)Math.Sin(i * Math.PI / 180), 0, p.x * (float)Math.Cos(i * Math.PI / 180));
            }
            Gl.glEnd(); 
        }

        public void Paint()
        {
            if (MainForm.ShowOrbit)
            {
                DrawOrbit();
            }
            if (tipo == Planets.Sun)
            {
               
            }
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ONE);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(texture));
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glPushMatrix();
            anguloOrbita += velocidadOrbita;
            anguloRotacion += 0.6f;
            Gl.glRotatef(anguloOrbita, 0, 1, 0);
            Gl.glTranslatef(-p.x, -p.y, -p.z);

            Gl.glRotatef(anguloRotacion, 0, 1, 0);
           
            Gl.glCallList(list);
          
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        } 
    }
}
