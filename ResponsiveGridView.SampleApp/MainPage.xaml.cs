using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ResponsiveGridView.Extentions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ResponsiveGridView.SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void List_OnLoaded(object sender, RoutedEventArgs e)
        {
            var responsiveGridView = (ResponsiveGridView)sender;
            FillListWithItems(responsiveGridView, 50);
        }

        private void List_OnScrollEnded(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer) sender;
            var responsiveGridView = scrollViewer.GetFirstAncestorOfType<ResponsiveGridView>();
            FillListWithItems(responsiveGridView, 50);
        }

        private void FillListWithItems(ResponsiveGridView list, int length)
        {
            if (list.ItemsSource == null)
            {
                list.ItemsSource = new ObservableCollection<int>();
            }

            var collection = (ObservableCollection<int>)list.ItemsSource;
            for (int i = 0; i < length; i++)
            {
                collection.Add(collection.Count + 1);
            }
        }
    }
}
