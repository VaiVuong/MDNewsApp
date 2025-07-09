using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    public Article SelectedArticle { get; set; }

    public NewsDetailPage(Article article)
    {
        InitializeComponent();
        SelectedArticle = article;
        BindingContext = SelectedArticle;
    }
}
