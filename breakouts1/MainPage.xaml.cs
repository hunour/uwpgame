using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace breakouts1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Pong pong;
        public MainPage()
        {
            this.InitializeComponent();
            pong = new Pong();

            Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
            Window.Current.CoreWindow.KeyUp += Canvas_KeyUp;
        }

        private void Canvas_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Left)
            {
                pong.setUPM_L(false);
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Right)
            {
                pong.setUPM_R(false);
            }
            if (pong.gameOver && args.VirtualKey == Windows.System.VirtualKey.Y)
            {
                pong = new Pong();
            }
        }

        private void Canvas_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Left)
            {
                pong.setUPM_L(true);
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Right)
            {
                pong.setUPM_R(true);
            }
        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {

            pong.DrawPong(args.DrawingSession);
            if (!pong.gameOver)
            {
                pong.DrawPong(args.DrawingSession);
            }
            else
            {
                args.DrawingSession.DrawText("GAME OVER! do you want to play again? (Y/N)", 400, 400, Colors.Azure);
            }
        }

        private void Canvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {

        }

        private void Canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            pong.Update();
        }
    }
}
