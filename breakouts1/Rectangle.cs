using Microsoft.Graphics.Canvas;
using Windows.UI;

namespace breakouts1
{
    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int width { get; set; }
        public int Height { get; set; }
        public Color color { get; set; }
        public void Draw(CanvasDrawingSession drawingSession)
        {
            drawingSession.DrawRectangle(X, Y, width, Height, color);
        }
    }
}