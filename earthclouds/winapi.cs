using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Solar
{
    public struct Pointer
    {
        public int x;
        public int y;
    }

    public static class Winapi
    {
        [DllImport("GDI32.dll")]
        public static extern void SwapBuffers(uint hdc);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int y, int x);
        [DllImport("user32.dll")]
        public static extern void GetCursorPos(ref Pointer point);
    }
}
