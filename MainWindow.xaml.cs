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
using System.Text.Json;


namespace dz_kino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieInfoProxy _movieInfoProxy;

        // Так как я мало работал с API у меня никак не получилось сделать так чтобы он искал фильмы по названию, как бы я не делал выдавало ошибки
        // Поэтому там где должна быть реализация с помощью API десериализации я оставил комментарии-пустышки
        // Не судите строго, пожалуйста!

        public MainWindow()
        {
            InitializeComponent();

            var apiKeyWindow = new ApiKeyWindow();
            if (apiKeyWindow.ShowDialog() == true)
            {
                var tmdbService = new TmdbService(apiKeyWindow.TmdbApiKey);
                var omdbService = new OmdbService(apiKeyWindow.OmdbApiKey);
                _movieInfoProxy = new MovieInfoProxy(tmdbService, omdbService);
            }
            else
            {
                MessageBox.Show("Введите API ключи", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string title = MovieTitleTextBox.Text;
            string result = _movieInfoProxy.GetMovieInfo(title);
            MoviesListBox.ItemsSource = ParseMovies(result);
        }

        private List<string> ParseMovies(string result)
        {
            // Переводит JSON строку в список из названий фильмов
            return new List<string>() { result };
        }

        private void MoviesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MoviesListBox.SelectedItem != null)
            {
                string selectedMovie = MoviesListBox.SelectedItem.ToString();
                ShowMovieInfo(selectedMovie);
            }
        }

        private void ShowMovieInfo(string movieTitle)
        {
            string result = _movieInfoProxy.GetMovieInfo(movieTitle);
            if (result != null)
            {
                MovieTitleTextBlock.Text = "Название фильма";
                MovieYearTextBlock.Text = "Год выхода фильма";
                MovieDescriptionTextBlock.Text = "Описание фильма";
                MoviePosterImage.Source = new BitmapImage(new Uri("https://d1csarkz8obe9u.cloudfront.net/posterpreviews/movie-poster-template-for-free-design-a28c2f452f5c988ef92d66875b784209_screen.jpg?ts=1636981244"));
                SearchPanel.Visibility = Visibility.Collapsed;
                MovieInfoPanel.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MovieInfoPanel.Visibility = Visibility.Collapsed;
            SearchPanel.Visibility = Visibility.Visible;
            MoviesListBox.SelectedItem = null;
        }
    }
}