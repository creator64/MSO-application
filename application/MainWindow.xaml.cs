using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace application;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void lol()
    {
        
    }

    private void handleRun(object sender, RoutedEventArgs e)
    {
        square.Margin = new (square.Margin.Left, square.Margin.Top, square.Margin.Right - 31.3, square.Margin.Bottom);
    }
}