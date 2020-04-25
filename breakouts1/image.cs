using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakouts1
{
    class image
    {

        public CanvasBitmap picture;
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(CanvasDrawingSession drawingSession)
        {
            drawingSession.DrawImage(picture, X, Y);
        }

    }
}
