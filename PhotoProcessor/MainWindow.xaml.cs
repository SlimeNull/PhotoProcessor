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
using CommunityToolkit.Mvvm.Messaging;
using PhotoProcessor.Messages;
using PhotoProcessor.Services;
using PhotoProcessor.ViewModels;

namespace PhotoProcessor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, 
        IRecipient<UpdateProjectViewMessage>
    {
        public MainWindow(
            MainWindowModel viewModel, 
            ToolsManager toolsManager,
            IMessenger messenger)
        {
            messenger.Register(this);

            ViewModel = viewModel;
            ToolsManager = toolsManager;

            DataContext = this;
            InitializeComponent();
        }

        public MainWindowModel ViewModel { get; }
        public ToolsManager ToolsManager { get; }

        public void Receive(UpdateProjectViewMessage message)
        {
            AppProjectEditor.InvalidateVisual();
        }
    }
}