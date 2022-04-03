using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AccountingOrders.WPF.Controls
{
    public partial class WindowManagement : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title), typeof(string), typeof(WindowManagement), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public WindowManagement()
        {
            InitializeComponent();
            DataContext = this;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        public struct POINT { public int X; public int Y; }

        private Window Window => Window.GetWindow(this);

        private void Close(object sender, RoutedEventArgs e) => Window.Close();

        private void Maximized(object? sender, RoutedEventArgs? e) => Window.WindowState = Window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void Minimized(object sender, RoutedEventArgs e) => Window.WindowState = WindowState.Minimized;

        #pragma warning disable CA1822 // Пометьте члены как статические
        private bool MouseTwitched() => true;
        #pragma warning restore CA1822 // Пометьте члены как статические

        private void LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) Window.WindowState = Window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            else
            {
                if ((Window.WindowState == WindowState.Maximized) && MouseTwitched())
                {
                    GetCursorPos(out POINT Cursor);
                    DpiScale dpi = VisualTreeHelper.GetDpi(new Control());
                    double WindowWidth = SystemParameters.PrimaryScreenWidth * dpi.DpiScaleX;
                    double WindowHeight = SystemParameters.PrimaryScreenHeight * dpi.DpiScaleY;
                    Window.WindowState = WindowState.Normal;
                    Window.Top = Cursor.Y - (Window.Height * (Cursor.Y / WindowHeight));
                    if (Cursor.X > (Window.Width / 2) && (Cursor.X + (Window.Width / 2)) < WindowWidth)
                        Window.Left = Cursor.X - (Window.Width / 2);
                    else Window.Left = (Cursor.X > (Window.Width / 2)) ? WindowWidth - Window.Width : 0;
                }
                Window.DragMove();
            }
        }
    }
}