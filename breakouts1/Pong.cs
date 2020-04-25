
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.UI;

namespace breakouts1
{
    public class Pong
    {
        Picture pict;
        private blocksets blocks;
        private Ball ball;
        private Rectangle leftWall;
        private Rectangle rightWall;
        private Rectangle topWall;
        private Rectangle userPaddle;
        private int i = 0;
        private const int NBR = 71;
        private blocksets[] blockset = new blocksets[NBR];

        public bool gameOver { get; private set; }
        //clean this put it in a class where it belongs
        private bool IsUPM_L;
        private bool IsUPM_R;
        public Pong()
        {
            pict = new Picture
            {
                X = 900,
                Y = 300
            };

            gameOver = false;
            ball = new Ball
            {
                X = 400,
                Y = 730,
                Radius = 5,
                color = Colors.Gold,
                M_L = Convert.ToBoolean(new Random().Next(1000)),
                M_D = Convert.ToBoolean(false),
                ballSpeed = 2
            };
            IsUPM_L = false;
            IsUPM_R = false;
            leftWall = new Rectangle
            {
                X = 10,
                Y = 50,
                width = 10,
                Height = 700,
                color = Colors.Green
            };
            rightWall = new Rectangle
            {
                X = 790,
                Y = 50,
                width = 10,
                Height = 700,
                color = Colors.Green
            };
            topWall = new Rectangle
            {
                X = 10,
                Y = 50,
                width = 780,
                Height = 10,
                color = Colors.Green
            };
            blocks = new blocksets
            {
                X = 20,
                Y = 350,
                width = 50,
                height = 20,
                color = Colors.Red
            };
            userPaddle = new Rectangle
            {
                X = 400,
                Y = 750,
                width = 70,
                Height = 10,
                color = Colors.Blue
            };
            //userPaddle2 = new Rectangle
            //{
            //    X = 20,
            //    Y = 500,
            //    width = 50,
            //    Height = 10,
            //    color = Colors.Blue
            //};

        }

        public void SetPicture(CanvasBitmap pic)
        {
            pict.picture = pic;
        }

        public void DrawPong(CanvasDrawingSession drawingSession)
        {
            pict.Draw(drawingSession);
            leftWall.Draw(drawingSession);
            rightWall.Draw(drawingSession);
            topWall.Draw(drawingSession);
            userPaddle.Draw(drawingSession); ball.Draw(drawingSession);
            //userPaddle2.Draw(drawingSession);
            int c = 1;
            while (i < 70)
            {
                for (int j = 350; j < 460 + blocks.height;)
                {
                    for (int x = leftWall.X + leftWall.width + 3; x < rightWall.X - blocks.width; x = blocks.width + x + 5)
                    {

                        blocks = new blocksets();
                        blocks.X = x;
                        blocks.Y = j;
                        blocks.width = 50;
                        blocks.height = 20;
                        if (c == 1) blocks.color = Colors.Red;
                        if (c == 2) blocks.color = Colors.Orange;
                        if (c == 3) blocks.color = Colors.Yellow;
                        if (c == 4) blocks.color = Colors.YellowGreen;
                        if (c == 5) blocks.color = Colors.Green;
                        
                        blockset.SetValue(blocks, i); i++;

                    }
                    j = (c * blocks.height) + 350 + (c * 6);
                    c++;
                    if (c == 6)
                    {

                    }
                }
            }
            for (i = 0; i < 70; i++)
            {
                if (blockset[i] != null)
                {
                    blockset[i].Draw(drawingSession);
                }
            }
            ball.Draw(drawingSession);
        }
        public void setUPM_L(bool M_L)
        {
            IsUPM_L = M_L;
        }
        public void setUPM_R(bool M_R)
        {
            IsUPM_R = M_R;
        }

        internal void Update()
        {
            if (!gameOver)
            {
                if (IsUPM_L)
                {
                    if (userPaddle.X > leftWall.X + leftWall.width)
                    {
                        moveUSerPaddle(-1);
                    }
                }
                if (IsUPM_R)
                {
                    if (userPaddle.X + userPaddle.width < rightWall.X)
                    {
                        moveUSerPaddle(1);
                    }
                }

                if (ball.X - ball.Radius <= leftWall.X + leftWall.width && ball.Y + ball.Radius >= leftWall.Y && ball.Y + ball.Radius <= leftWall.Y + leftWall.Height)
                {

                    ball.M_L = false;
                    ball.ChangeColor();
                }
                else if (ball.X + ball.Radius >= rightWall.X && ball.Y + ball.Radius >= rightWall.Y && ball.Y + ball.Radius <= rightWall.Y + rightWall.Height)
                {
                    ball.M_L = true;
                    ball.ChangeColor();
                }
                else if (ball.X - ball.Radius >= topWall.X && ball.Y + ball.Radius >= topWall.Y && ball.Y + ball.Radius <= topWall.Y + topWall.Height)
                {
                    ball.M_D = true;
                    ball.ChangeColor();
                }
                else if (ball.Y + ball.Radius >= userPaddle.Y && ball.X - ball.Radius >= userPaddle.X && ball.X + ball.Radius <= userPaddle.X + userPaddle.width)
                {
                    if (ball.M_D && ball.M_L)
                    {
                        ball.M_L = true;
                        ball.M_D = false;
                        ball.ChangeColor();
                    }
                    else
                    {
                        ball.M_L = false;
                        ball.M_D = false;
                        ball.ChangeColor();
                    }

                }
                else
                {

                    for (int j = 0; j < i; j++)
                    {
                        if (blockset[j] != null)
                        {
                            if (ball.Y - ball.Radius <= blockset[j].Y + blockset[j].height
                                && ball.Y + ball.Radius >= blockset[j].Y - blockset[j].height
                                && ball.X - ball.Radius >= blockset[j].X
                                && ball.X + ball.Radius <= blockset[j].X + blockset[j].width)
                            {
                                if (ball.Y - ball.Radius <= blockset[j].Y + blockset[j].height)
                                {
                                    if(ball.M_D==false&& ball.M_L == true)
                                    {
                                        ball.M_L = true;
                                        ball.M_D = true;
                                    }
                                    else if (ball.M_D == false && ball.M_L == false)
                                    {
                                        ball.M_L = false;
                                        ball.M_D = true;
                                    }
                                    
                                    ball.ChangeColor();
                                    if (blockset[j].color == Colors.Red)
                                    {
                                        ball.ballSpeed = 5;
                                    }
                                    if (blockset[j].color == Colors.Orange && ball.ballSpeed < 4)
                                    {
                                        ball.ballSpeed = 4;
                                    }
                                    if (blockset[j].color == Colors.Yellow && ball.ballSpeed < 3)
                                    {
                                        ball.ballSpeed = 3;
                                    }
                                    if (blockset[j].color == Colors.YellowGreen && ball.ballSpeed < 2)
                                    {
                                        ball.ballSpeed = 2;
                                    }
                                    if (blockset[j].color == Colors.Green && ball.ballSpeed < 2)
                                    {
                                        ball.ballSpeed = 2;
                                    }
                                    blockset[j].color = Colors.Black;
                                    blockset[j] = null;
                                }
                                else if (ball.Y + ball.Radius >= blockset[j].Y - blockset[j].height)
                                {
                                     if (ball.M_D == true && ball.M_L == false)
                                    {
                                        ball.M_L = true;
                                        ball.M_D = false;
                                    }
                                    else if (ball.M_D == true && ball.M_L == true)
                                    {
                                        ball.M_L = false;
                                        ball.M_D = false;
                                    }
                                    ball.ChangeColor();
                                    if (blockset[j].color == Colors.Red)
                                    {
                                        ball.ballSpeed = 5;
                                    }
                                    if (blockset[j].color == Colors.Orange&& ball.ballSpeed < 4)
                                    {
                                        ball.ballSpeed = 4;
                                    }
                                    if (blockset[j].color == Colors.Yellow && ball.ballSpeed <3 )
                                    {
                                        ball.ballSpeed = 3;
                                    }
                                    if (blockset[j].color == Colors.YellowGreen && ball.ballSpeed < 2)
                                    {
                                        ball.ballSpeed = 2;
                                    }
                                    if (blockset[j].color == Colors.Green && ball.ballSpeed < 2)
                                    {
                                        ball.ballSpeed = 2;
                                    }
                                    blockset[j].color = Colors.Black;
                                    blockset[j] = null;
                                }
                            }
                        }
                    }
                }
                ball.updatePosition();
                if (ball.Y > userPaddle.Y)
                {
                    gameOver = true;
                    App.soundPlayer.Source = MediaSource.CreateFromUri(
                        new Uri($"ms-appx:///Assets/sound.mp3"));
                    App.soundPlayer.Play();
                }
            }
        }



        public void moveUSerPaddle(int changeInX)
        {
            
            userPaddle.X += changeInX * 10;
            
        }
    }
}
