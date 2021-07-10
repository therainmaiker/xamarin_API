using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Xamarin.Models;
using Api_Xamarin.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public ObservableCollection<Product> ProductsCollection;
        public ObservableCollection<Category> CategoriesCollection;

        public Home()
        {
            InitializeComponent();

            ProductsCollection = new ObservableCollection<Product>();
            CategoriesCollection = new ObservableCollection<Category>();
            GetProducts();
            GetCategories();
            
            LblUserName.Text = Preferences.Get("userName", string.Empty);

        }


        private async void GetCategories()
        {
            var categories = await StoreApiService.GetCategories();
            foreach (var category in categories)
            {
                CategoriesCollection.Add(category);
            }

            CvCategories.ItemsSource = CategoriesCollection;
        }


        private async void GetProducts()
        {
            var products = await StoreApiService.GetProducts();
            foreach (var product in products)
            {
                ProductsCollection.Add(product);
            }

            CvProducts.ItemsSource = ProductsCollection;
        }


        private async void TapMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }


        private void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            CloseHamburgerMenu();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // var response = await StoreApiService.GetTotalCartItems(Preferences.Get("userId", 0));
            // LblTotalItems.Text = response.TotalItems.ToString();
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CloseHamburgerMenu();
        }


        private async void CloseHamburgerMenu()
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }


        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignUp());
        }


        private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
            if (currentSelection == null) return;
            // Navigation.PushModalAsync(new ProductListPage(currentSelection.Id,currentSelection.Name));
            ((CollectionView) sender).SelectedItem = null;
        }

        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var currentSelection = e.CurrentSelection.FirstOrDefault() as TrendingProduct;
            // if (currentSelection == null) return;
            // Navigation.PushModalAsync(new ProductDetailPage(currentSelection.Id));
            ((CollectionView) sender).SelectedItem = null;
        }
    }
}