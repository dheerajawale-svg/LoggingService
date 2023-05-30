using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Natus.Logging.Client;

namespace WpfTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INatusLogger _logger;

        public MainWindow(INatusLogger natusLogger)
        {
            InitializeComponent();

            _logger = natusLogger;
            _logger.Info("wpf initialized!");
        }

        private void btnInfoSubmit_Click(object sender, RoutedEventArgs e)
        {
            _logger.Info(txtInfoContent.Text.ToString());
            lblInfoConfirm.Text = "log info confirmed!";
        }

        private void btnDebugSubmit_Click(object sender, RoutedEventArgs e)
        {
            _logger.Debug(txtDebugContent.Text.ToString());
            lblDebugConfirm.Text = "log debug confirmed!";
        }

        private void btnErrorSubmit_Click(object sender, RoutedEventArgs e)
        {
            _logger.Info(txtErrorContent.Text.ToString());
            lblErrorConfirm.Text = "log Error confirmed!";
        }

        private void btnWarningSubmit_Click(object sender, RoutedEventArgs e)
        {
            _logger.Warning(txtWarningContent.Text.ToString());
            lblWarningConfirm.Text = "log Warning confirmed!";
        }

        private void btnFatalSubmit_Click(object sender, RoutedEventArgs e)
        {
            _logger.Fatal(txtFatalContent.Text.ToString());
            lblFatalConfirm.Text = "log Fatal confirmed!";
        }

        private void btnUserActionlSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
