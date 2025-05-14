using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Helpers
{
    internal static class NativeMethods
    {
        [DllImport("3DModelRenderer.dll")]
        public static extern IntPtr CreateModelViewer();

        [DllImport("3DModelRenderer.dll")]
        public static extern bool InitializeEnvironment(IntPtr hwnd, IntPtr engine);

        [DllImport("3DModelRenderer.dll")]
        public static extern int GetSurfaceWidth(IntPtr engine);

        [DllImport("3DModelRenderer.dll")]
        public static extern int GetSurfaceHeight(IntPtr engine);

        [DllImport("3DModelRenderer.dll")]
        public static extern void Render(IntPtr engine);

        [DllImport("3DModelRenderer.dll")]
        public static extern IntPtr GetSharedSurface(IntPtr engine);

        [DllImport("3DModelRenderer.dll")]
        public static extern bool LoadModel(IntPtr engine, string path);

        [DllImport("3DModelRenderer.dll")]
        public static extern int GetNumMotions(IntPtr engine);

        [DllImport("3DModelRenderer.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetMotionName(IntPtr engine, int index);

        [DllImport("3DModelRenderer.dll")]
        public static extern void PlayMotion(IntPtr engine, int index);

        [DllImport("3DModelRenderer.dll")]
        public static extern void RotateCamera(IntPtr engine, int x, int y);

        [DllImport("3DModelRenderer.dll")]
        public static extern void ZoomCamera(IntPtr engine, float delta);

        [DllImport("3DModelRenderer.dll")]
        public static extern void SetTextureEx(IntPtr engine, int textureEx);

        [DllImport("3DModelRenderer.dll")]
        public static extern void ResizeViewport(IntPtr engine, int width, int height);
    }
}
