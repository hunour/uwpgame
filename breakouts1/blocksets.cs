using Microsoft.Graphics.Canvas;
using System;
using Windows.UI;

namespace breakouts1
{
    internal class blocksets
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int width { get; set; }

        public int height { get; set; }
        public Color color { get; set; }

        public void Draw(CanvasDrawingSession drawingSession)
        {
            drawingSession.DrawRectangle(X, Y, width, height, color);
        }
    }
}