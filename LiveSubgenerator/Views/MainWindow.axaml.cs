using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Runtime.InteropServices;

namespace LiveSubgenerator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();



        // This ensures the window is ignored by the mouse at the OS level
        //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //{
        //    this.Opened += (s, e) =>
        //    {
        //        var handle = this.TryGetPlatformHandle()?.Handle;
        //        if (handle.HasValue)
        //        {
        //            MakeWindowClickThrough(handle.Value);
        //        }
        //    };
        //}
    }

    // Logic to drag the window
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            this.BeginMoveDrag(e);
        }
    }

    // Logic to minimize
    private void OnMinimizeClick(object? sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    // Windows-specific P/Invoke to set the "Transparent" extended style
    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TRANSPARENT = 0x00000020;
    private const int WS_EX_LAYERED = 0x00080000;

    private void MakeWindowClickThrough(IntPtr hwnd)
    {
        int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);
    }
}