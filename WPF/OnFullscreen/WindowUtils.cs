using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace OnFullscreen
{
    public class WindowUtils
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public static void AddExStyle(Window window, int style)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            SetWindowLong(
                helper.Handle, GWL_EXSTYLE,
                GetWindowLong(helper.Handle, GWL_EXSTYLE) | style);
        }

        public static void RemoveExStyle(Window window, int style)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            SetWindowLong(
                helper.Handle, GWL_EXSTYLE,
                GetWindowLong(helper.Handle, GWL_EXSTYLE) & ~style);
        }
    }
}
