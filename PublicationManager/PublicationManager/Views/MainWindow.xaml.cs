using System.Windows;

namespace PublicationManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(PublicationView publicationView) : this()
        {
            ContentArea.Content = publicationView;
        }
    }
}
