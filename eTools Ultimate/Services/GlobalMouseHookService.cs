using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace eTools_Ultimate.Services
{
    public class GlobalMouseHookService
    {
        private IntPtr _hookId = IntPtr.Zero;
        private readonly LowLevelMouseProc _proc;

        public GlobalMouseHookService()
        {
            _proc = HookCallback;
        }

        public event Action<int, int>? MouseMoved;
        public event Action<int, int>? RightButtonReleased;

        public void Start()
        {
            if (_hookId != IntPtr.Zero)
                return;

            using var process = System.Diagnostics.Process.GetCurrentProcess();
            using var module = process.MainModule!;
            _hookId = SetWindowsHookEx(
                WH_MOUSE_LL,
                _proc,
                GetModuleHandle(module.ModuleName),
                0);
        }

        public void Stop()
        {
            if (_hookId == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(_hookId);
            _hookId = IntPtr.Zero;
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var data = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

                switch ((int)wParam)
                {
                    case WM_MOUSEMOVE:
                        MouseMoved?.Invoke(data.pt.x, data.pt.y);
                        break;

                    case WM_RBUTTONUP:
                        RightButtonReleased?.Invoke(data.pt.x, data.pt.y);
                        break;
                }
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_RBUTTONUP = 0x0205;

        private struct POINT { public int x, y; }
        private struct MSLLHOOKSTRUCT { public POINT pt; }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
