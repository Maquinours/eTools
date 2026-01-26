using eTools_Ultimate.Models.Movers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace eTools_Ultimate.Helpers
{
    public class D3DImageHost : D3DImage, IDisposable
    {
        private IntPtr _surfacePointer;
        private readonly IntPtr _native;

        public bool IsInitialized { get; set; } = false;

        public D3DImageHost()
        {
            _native = NativeMethods.CreateModelViewer();
            if (_native == IntPtr.Zero)
                System.Diagnostics.Debug.WriteLine("Failed to create ModelViewer instance");
        }
        public void Initialize(IntPtr hwnd)
        {
            if (!NativeMethods.InitializeEnvironment(hwnd, _native))
                System.Diagnostics.Debug.WriteLine("Failed to initialize environment");
            else
                IsInitialized = true;
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
            Application.Current.Dispatcher.Invoke(() =>
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
            });
        }

        public void LoadModel(string filePath)
        {
            NativeMethods.LoadModel(_native, filePath);
        }

        public void Zoom(float delta)
        {
            NativeMethods.ZoomCamera(_native, delta);
        }


        public void SetModelTexture(int textureEx)
        {
            NativeMethods.SetTextureEx(_native, textureEx);
        }

        public void SetScale(float scale)
        {
            NativeMethods.SetScale(_native, scale);
        }

        public string[] GetMaterialTextures()
        {
            int texturesLength = NativeMethods.GetMaterialTexturesSize(_native);

            List<string> textureFiles = [];
            for (int i = 0; i < texturesLength; i++)
            {
                IntPtr textureName = NativeMethods.GetMaterialTexture(_native, i);
                string? texture = Marshal.PtrToStringAnsi(textureName);
                if(texture is not null)
                    textureFiles.Add(texture);
            }

            return [..textureFiles];
        }

        public void DeleteModel()
        {
            NativeMethods.DeleteModel(_native);
        }

        public void SetReferenceModel(string filePath)
        {
            NativeMethods.SetReferenceModel(_native, filePath);
        }

        public void SetReferenceParts(string filePath)
        {
            NativeMethods.SetReferenceParts(_native, filePath);
        }

        public void SetReferenceModelTexture(int textureEx)
        {
            NativeMethods.SetReferenceTextureEx(_native, textureEx);
        }

        public void SetReferenceScale(float scale)
        {
            NativeMethods.SetReferenceScale(_native, scale);
        }

        public void DeleteReferenceModel()
        {
            NativeMethods.DeleteReferenceModel(_native);
        }

        public void SetParts(string partPath)
        {
            NativeMethods.SetParts(_native, partPath);
        }

        public void RotateCamera(int x, int y)
        {
            NativeMethods.RotateCamera(_native, x, y);
        }

        public void PlayMotion(string filePath)
        {
            NativeMethods.PlayMotion(_native, filePath);
        }

        public void StopMotion()
        {
            NativeMethods.StopMotion(_native);
        }

        public void Clear()
        {
            DeleteModel();
            DeleteReferenceModel();
            Render();
        }

        public void Dispose()
        {
            // Cleanup if needed
        }

    }
}
