using Microsoft.Graphics.Canvas;
using System;
using Windows.UI;

namespace breakouts1
{
    internal class Ball
    {
        public bool M_L { get; set; }
        public bool M_D { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Radius { get; set; }
        public Color color { get; set; }
        public int ballSpeed { get; set; }
        public void Draw(CanvasDrawingSession drawingSession)
        {
            drawingSession.DrawEllipse(X, Y, Radius, Radius, color);
        }

        public void updatePosition()
        {
            if (M_L)
            {
                X -= ballSpeed;
            }
            else
            {
                X += ballSpeed;
            }
            if (M_D)
            {
                Y += ballSpeed;
            }
            else
            {
                Y -= ballSpeed;
            }
        }
        public void ChangeColor()
        {
            Random random = new Random();
            color = Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            
        }
    }
}