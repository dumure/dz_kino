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
using System.Windows.Shapes;

namespace dz_kino
{
    /// <summary>
    /// Interaction logic for ApiKeyWindow.xaml
    /// </summary>
    public partial class ApiKeyWindow : Window
    {
        public string TmdbApiKey { get; private set; }
        public string OmdbApiKey { get; private set; }

        public ApiKeyWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TmdbApiKey = TmdbApiKeyTextBox.Text;
            OmdbApiKey = OmdbApiKeyTextBox.Text;
            DialogResult = true;
        }
    }
}
