using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

        private void ListOnLoaded(object sender, RoutedEventArgs e)
        {
            var responsiveGridView = (ResponsiveGridView)sender;
            SetItems(responsiveGridView, 50);
        }

        private void ListOnScrollReachedToEnd(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer) sender;
            var responsiveGridView = scrollViewer.GetFirstAncestorOfType<ResponsiveGridView>();
            SetItems(responsiveGridView, 50);
        }

        private void SetItems(ResponsiveGridView list, int itemsCount)
        {
            if (list.ItemsSource == null)
            {
                list.ItemsSource = new ObservableCollection<int>();
            }

            var collection = (ObservableCollection<int>)list.ItemsSource;
            for (int i = 0; i < itemsCount; i++)
            {
                collection.Add(collection.Count + 1);
            }
        }
    }
}
