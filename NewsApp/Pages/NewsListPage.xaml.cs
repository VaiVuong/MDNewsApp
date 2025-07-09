using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private List<Article> Articles;

    public NewsListPage(string categoryName)
    {
        InitializeComponent();

        Title = char.ToUpper(categoryName[0]) + categoryName.Substring(1); // Capitalize title

        Articles = new List<Article>();
        LoadNews(categoryName);
    }

    private async void LoadNews(string category)
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(category);

        Articles = newsResult.Articles;

        CvNewsList.ItemsSource = Articles;  // Make sure CvNewsList is the CollectionView name in your XAML
    }

    private async void CvNewsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var selectedArticle = e.CurrentSelection[0] as Article;
        if (selectedArticle == null)
            return;

        ((CollectionView)sender).SelectedItem = null;

        await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
    }
}
