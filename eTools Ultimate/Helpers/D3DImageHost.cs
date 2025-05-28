using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace eTools_Ultimate.Helpers
{
    class D3DImageHost : D3DImage, IDisposable
    {
        public IntPtr _surfacePointer;
        public IntPtr _native;
        private bool _canRender = false;

        public D3DImageHost(IntPtr hwnd)
        {
            _native = NativeMethods.CreateModelViewer();
            if (_native == IntPtr.Zero)
                System.Diagnostics.Debug.WriteLine("Failed to create ModelViewer instance");

            if (!NativeMethods.InitializeEnvironment(hwnd, _native))
                System.Diagnostics.Debug.WriteLine("Failed to initialize environment");

        }
        public void Initialize(IntPtr hwnd)
        {

        }


        public void BindBackBuffer()
        {
            if (_native == IntPtr.Zero)
                return;

            IntPtr newSurface = NativeMethods.GetSharedSurface(_native);

            if (newSurface == IntPtr.Zero)
                return;

            Lock();
            SetBackBuffer(D3DResourceType.IDirect3DSurface9, IntPtr.Zero);
            SetBackBuffer(D3DResourceType.IDirect3DSurface9, newSurface);

            int w = NativeMethods.GetSurfaceWidth(_native);
            int h = NativeMethods.GetSurfaceHeight(_native);
            AddDirtyRect(new Int32Rect(0, 0, w, h));
            Unlock();

            _surfacePointer = newSurface;
        }

        public void Render()
        {
            if (_surfacePointer != IntPtr.Zero)
            {
                Lock();
                NativeMethods.Render(_native);
                int w = NativeMethods.GetSurfaceWidth(_native);
                int h = NativeMethods.GetSurfaceHeight(_native);
                AddDirtyRect(new Int32Rect(0, 0, w, h));
                Unlock();
            }
        }

        public void Dispose()
        {
            // Cleanup if needed
        }

    }
}
