using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        Randomizer rando;
        Color DEFAULT_BKG_COLOR = Color.LightBlue;


        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            displayHelp();
            rando = new Randomizer();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(DEFAULT_BKG_COLOR);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //setare perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //setare camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // COD LOGICA
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }

            if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                displayHelp();
            }

            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
            }

            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.GetRandomColor());
            }


            previousKeyboard = thisKeyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);


            // COD RENDER

            SwapBuffers();

        }

        private void displayHelp()
        {
            Console.WriteLine("\n         MENIU");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" H - meniu de ajutor");
            Console.WriteLine(" R - resetare parametri aplicatie");
            Console.WriteLine(" B - schimbare culoare de fundal (randomizat)");
        }
    }
}
