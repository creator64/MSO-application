using core.ApplicationProgram;
using core.Buttons;
using core.Grid;
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
    SuperButton metricsButton;
    MetricsCommand showMetricsCommand;

    public MainWindow()
    {
        //initialisation of loadexercise and metrics
        LoadExerciseCommand loadCommand = new LoadExerciseCommand();
        SuperButton loadButton = new SuperButton(loadCommand);

        TextDisplay textDisplay = new TextDisplay();

        showMetricsCommand = new MetricsCommand(textDisplay);
        metricsButton = new SuperButton(showMetricsCommand);


        //Mocks for testing
        loadButton.Press();

        showMetricsCommand.UpdateMetrics(1, 2, 3);


        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        metricsButton.Press();
        MetricsOutput.Text = "" + showMetricsCommand.tmetrics;
    }
}