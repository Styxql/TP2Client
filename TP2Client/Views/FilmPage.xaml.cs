using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TP2Client.ViewsModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TP2Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilmPage : Page
    {
        
        public FilmPage()
        {
            this.InitializeComponent();
            this.DataContext = App.Current.Services.GetService<FilmViewModel>();
        }
        //private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        //{
        //    SetCurrentNavigationViewItem(args.SelectedItemContainer as NavigationViewItem);
        //}
        //public void SetCurrentNavigationViewItem(NavigationViewItem item)
        //{
        //    var frame = Window.Current.Content as Frame;

        //    if (item == null)
        //    {
        //        return;
        //    }

        //    if (item.Tag == null)
        //    {
        //        return;
        //    }

        //    frame.Navigate(
        //    Type.GetType(item.Tag.ToString()),
        //    item.Content);
        //    NavigationView.Header = item.Content;
        //    NavigationView.SelectedItem = item;
        //}
        //private void NavigationView_Loaded(object sender,RoutedEventArgs e)
        //{
        //    // Navigates, but does not update the Menu.
        //    // ContentFrame.Navigate(typeof(HomePage));

        //    SetCurrentNavigationViewItem(GetNavigationViewItems(typeof(FilmPage)).First());
        //}


        //public List<NavigationViewItem> GetNavigationViewItems()
        //{
        //    var result = new List<NavigationViewItem>();
        //    var items = NavigationView.MenuItems.Select(i => (NavigationViewItem)i).ToList();
        //    items.AddRange(NavigationView.FooterMenuItems.Select(i => (NavigationViewItem)i));
        //    result.AddRange(items);

        //    foreach (NavigationViewItem mainItem in items)
        //    {
        //        result.AddRange(mainItem.MenuItems.Select(i => (NavigationViewItem)i));
        //    }

        //    return result;
        //}

        //public List<NavigationViewItem> GetNavigationViewItems(
        //    Type type)
        //{
        //    return GetNavigationViewItems().Where(i => i.Tag.ToString() == type.FullName).ToList();
        //}

        //public List<NavigationViewItem> GetNavigationViewItems(
        //    Type type,
        //    string title)
        //{
        //    return GetNavigationViewItems(type).Where(ni => ni.Content.ToString() == title).ToList();
        //}




    }
}
