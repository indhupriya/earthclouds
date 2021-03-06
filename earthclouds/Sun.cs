﻿using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using ShadowEngine;


namespace Solar
{
    class Sun
    {
         
        int list;
        float rotacion;

        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);
            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
            Glu.gluSphere(quadratic, 1,32, 32);
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public  void Paint()
        {
            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("tierra.jpg"));
            rotacion += 0.2f; 
            Gl.glRotatef(rotacion, 0, 1, 0);  
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_BLEND);
        } 
     
    }
}
