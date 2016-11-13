// ***********************************************************************
// Assembly         : ResponsiveGridView
// Author           : Vaggelis Diatsigkos
// Created          : 11-13-2016
//
// Last Modified By : Vaggelis
// Last Modified On : 11-13-2016
// ***********************************************************************
// <copyright file="ResponsiveGridView.cs">
//     Copyright ©  2016
// </copyright>
// <summary>Extended functionality of GridView Control for Universal Windows Platform</summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using ResponsiveGridView.Annotations;
using ResponsiveGridView.Extentions;

namespace ResponsiveGridView
{
    /// <summary>
    /// Class ResponsiveGridView.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.GridView" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ResponsiveGridView : GridView, INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The scroll viewer
        /// </summary>
        private ScrollViewer _scrollViewer;
        /// <summary>
        /// The current item width
        /// </summary>
        private double _currentItemWidth;
        /// <summary>
        /// The current item height
        /// </summary>
        private double _currentItemHeight;

        #endregion

        #region Events

        /// <summary>
        /// ScrollReachedToEnd EventHandler
        /// </summary>
        public event EventHandler<ScrollViewerViewChangedEventArgs> ScrollReachedToEnd;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [scrolled to end].
        /// </summary>
        /// <value><c>true</c> if [scrolled to end]; otherwise, <c>false</c>.</value>
        public bool ScrolledToEnd { get; set; }

        /// <summary>
        /// Gets or sets the width of the current item.
        /// </summary>
        /// <value>The width of the current item.</value>
        public double CurrentItemWidth
        {
            get { return _currentItemWidth; }
            set { _currentItemWidth = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the height of the current item.
        /// </summary>
        /// <value>The height of the current item.</value>
        public double CurrentItemHeight
        {
            get { return _currentItemHeight; }
            set { _currentItemHeight = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the width of the item.
        /// </summary>
        /// <value>The width of the item.</value>
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the item space.
        /// </summary>
        /// <value>The item space.</value>
        public Thickness ItemSpace
        {
            get { return (Thickness)GetValue(ItemSpaceProperty); }
            set { SetValue(ItemSpaceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the item style.
        /// </summary>
        /// <value>The item style.</value>
        public ItemStyleEnum ItemStyle
        {
            get { return (ItemStyleEnum)GetValue(ItemStyleProperty); }
            set { SetValue(ItemStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the item vertical alignment.
        /// </summary>
        /// <value>The item vertical alignment.</value>
        public VerticalAlignment ItemVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(ItemVerticalAlignmentProperty); }
            set { SetValue(ItemVerticalAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the item horizontal alignment.
        /// </summary>
        /// <value>The item horizontal alignment.</value>
        public HorizontalAlignment ItemHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(ItemHorizontalAlignmentProperty); }
            set { SetValue(ItemHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the item background.
        /// </summary>
        /// <value>The item background.</value>
        public Brush ItemBackground
        {
            get { return (Brush)GetValue(ItemBackgroundProperty); }
            set { SetValue(ItemBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the columns in mobile.
        /// </summary>
        /// <value>The columns in mobile.</value>
        public int ColumnsInMobile
        {
            get { return (int)GetValue(ColumnsInMobileProperty); }
            set { SetValue(ColumnsInMobileProperty, value); }
        }

        /// <summary>
        /// Gets or sets the columns in tablet.
        /// </summary>
        /// <value>The columns in tablet.</value>
        public int ColumnsInTablet
        {
            get { return (int)GetValue(ColumnsInTabletProperty); }
            set { SetValue(ColumnsInTabletProperty, value); }
        }

        /// <summary>
        /// Gets or sets the columns in desktop.
        /// </summary>
        /// <value>The columns in desktop.</value>
        public int ColumnsInDesktop
        {
            get { return (int)GetValue(ColumnsInDesktopProperty); }
            set { SetValue(ColumnsInDesktopProperty, value); }
        }

        /// <summary>
        /// Gets or sets the columns in hub.
        /// </summary>
        /// <value>The columns in hub.</value>
        public int ColumnsInHub
        {
            get { return (int)GetValue(ColumnsInHubProperty); }
            set { SetValue(ColumnsInHubProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum width of the mobile.
        /// </summary>
        /// <value>The maximum width of the mobile.</value>
        public double MaxMobileWidth
        {
            get { return (double)GetValue(MaxMobileWidthProperty); }
            set { SetValue(MaxMobileWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum width of the tablet.
        /// </summary>
        /// <value>The maximum width of the tablet.</value>
        public double MaxTabletWidth
        {
            get { return (double)GetValue(MaxTabletWidthProperty); }
            set { SetValue(MaxTabletWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum width of the desktop.
        /// </summary>
        /// <value>The maximum width of the desktop.</value>
        public double MaxDesktopWidth
        {
            get { return (double)GetValue(MaxDesktopWidthProperty); }
            set { SetValue(MaxDesktopWidthProperty, value); }
        } 

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The item width property
        /// </summary>
        public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register(
            "ItemWidth", typeof(double), typeof(ResponsiveGridView), new PropertyMetadata(default(double)));

        /// <summary>
        /// The item height property
        /// </summary>
        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register(
            "ItemHeight", typeof(double), typeof(ResponsiveGridView), new PropertyMetadata(default(double)));

        /// <summary>
        /// The item space property
        /// </summary>
        public static readonly DependencyProperty ItemSpaceProperty = DependencyProperty.Register(
            "ItemSpace", typeof(Thickness), typeof(ResponsiveGridView), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The item style property
        /// </summary>
        public static readonly DependencyProperty ItemStyleProperty = DependencyProperty.Register(
            "ItemStyle", typeof(ItemStyleEnum), typeof(ResponsiveGridView), new PropertyMetadata(ItemStyleEnum.Relative));

        /// <summary>
        /// The item horizontal alignment property
        /// </summary>
        public static readonly DependencyProperty ItemHorizontalAlignmentProperty = DependencyProperty.Register(
            "ItemHorizontalAlignment", typeof(HorizontalAlignment), typeof(ResponsiveGridView), new PropertyMetadata(HorizontalAlignment.Stretch));

        /// <summary>
        /// The item vertical alignment property
        /// </summary>
        public static readonly DependencyProperty ItemVerticalAlignmentProperty = DependencyProperty.Register(
            "ItemVerticalAlignment", typeof(VerticalAlignment), typeof(ResponsiveGridView), new PropertyMetadata(VerticalAlignment.Stretch));

        /// <summary>
        /// The item background property
        /// </summary>
        public static readonly DependencyProperty ItemBackgroundProperty = DependencyProperty.Register(
            "ItemBackground", typeof(Brush), typeof(ResponsiveGridView), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        /// <summary>
        /// The columns in mobile property
        /// </summary>
        public static readonly DependencyProperty ColumnsInMobileProperty = DependencyProperty.Register(
            "ColumnsInMobile", typeof(int), typeof(ResponsiveGridView), new PropertyMetadata(1));

        /// <summary>
        /// The columns in tablet property
        /// </summary>
        public static readonly DependencyProperty ColumnsInTabletProperty = DependencyProperty.Register(
            "ColumnsInTablet", typeof(int), typeof(ResponsiveGridView), new PropertyMetadata(1));

        /// <summary>
        /// The columns in desktop property
        /// </summary>
        public static readonly DependencyProperty ColumnsInDesktopProperty = DependencyProperty.Register(
            "ColumnsInDesktop", typeof(int), typeof(ResponsiveGridView), new PropertyMetadata(1));

        /// <summary>
        /// The columns in hub property
        /// </summary>
        public static readonly DependencyProperty ColumnsInHubProperty = DependencyProperty.Register(
            "ColumnsInHub", typeof(int), typeof(ResponsiveGridView), new PropertyMetadata(1));

        /// <summary>
        /// The mobile maximum width property
        /// </summary>
        public static readonly DependencyProperty MaxMobileWidthProperty = DependencyProperty.Register(
            "MaxMobileWidth", typeof(double), typeof(ResponsiveGridView), new PropertyMetadata(640.0));

        /// <summary>
        /// The tablet maximum width property
        /// </summary>
        public static readonly DependencyProperty MaxTabletWidthProperty = DependencyProperty.Register(
            "MaxTabletWidth", typeof(double), typeof(ResponsiveGridView), new PropertyMetadata(1007.0));

        /// <summary>
        /// The desktop maximum width property
        /// </summary>
        public static readonly DependencyProperty MaxDesktopWidthProperty = DependencyProperty.Register(
            "MaxDesktopWidth", typeof(double), typeof(ResponsiveGridView), new PropertyMetadata(1920.0));

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsiveGridView"/> class.
        /// </summary>
        public ResponsiveGridView()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
            SizeChanged += OnSizeChanged;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Prepares the container for item override.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="item">The item.</param>
        protected override void PrepareContainerForItemOverride(DependencyObject obj, object item)
        {
            base.PrepareContainerForItemOverride(obj, item);
            var element = obj as FrameworkElement;
            if (element == null)
            {
                return;
            }

            element.SetBinding(WidthProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("CurrentItemWidth"),
                Mode = BindingMode.TwoWay
            });

            element.SetBinding(HeightProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("CurrentItemHeight"),
                Mode = BindingMode.TwoWay
            });

            element.SetBinding(MarginProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("ItemSpace"),
                Mode = BindingMode.TwoWay
            });

            element.SetBinding(BackgroundProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("ItemBackground"),
                Mode = BindingMode.TwoWay
            });

            element.SetBinding(HorizontalContentAlignmentProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("ItemHorizontalAlignment"),
                Mode = BindingMode.TwoWay
            });

            element.SetBinding(VerticalContentAlignmentProperty, new Binding
            {
                Source = this,
                Path = new PropertyPath("ItemVerticalAlignment"),
                Mode = BindingMode.TwoWay
            });
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the <see cref="E:Loaded" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="routedEventArgs">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _scrollViewer = this.GetFirstDescendantOfType<ScrollViewer>();
            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged += ScrollViewerOnViewChanged;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Unloaded" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="routedEventArgs">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Loaded -= OnLoaded;
            Unloaded -= OnUnloaded;
            SizeChanged -= OnSizeChanged;

            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged -= ScrollViewerOnViewChanged;
                _scrollViewer = null;
            }
        }

        /// <summary>
        /// ScrollViewer on view changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ScrollViewerViewChangedEventArgs"/> instance containing the event data.</param>
        private void ScrollViewerOnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_scrollViewer.VerticalOffset < _scrollViewer.ScrollableHeight)
            {
                ScrolledToEnd = false;
                return;
            }
            ScrolledToEnd = true;
            ScrollReachedToEnd?.Invoke(sender, e);
        }

        /// <summary>
        /// Handles the <see cref="E:SizeChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SizeChangedEventArgs"/> instance containing the event data.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = e.NewSize.Width;
            var deviceType = GetDeviceTypeByControlWidth(width);
            var columns = GetColumnsByDeviceType(deviceType);

            CurrentItemWidth = (width / columns) - (ItemSpace.Left + ItemSpace.Right + 1);
            switch (ItemStyle)
            {
                case ItemStyleEnum.Relative:
                    CurrentItemHeight = CurrentItemWidth * ItemHeight / ItemWidth;
                    break;
                case ItemStyleEnum.Square:
                    CurrentItemHeight = CurrentItemWidth;
                    break;
                case ItemStyleEnum.Portrait:
                    CurrentItemHeight = CurrentItemWidth * 4 / 3;
                    break;
                case ItemStyleEnum.Landscape:
                    CurrentItemHeight = CurrentItemWidth * 9 / 16;
                    break;
            }
        }

        /// <summary>
        /// Gets the device type by control width.
        /// </summary>
        /// <param name="width">Control width.</param>
        /// <returns>DeviceTypeEnum.</returns>
        private DeviceTypeEnum GetDeviceTypeByControlWidth(double width)
        {
            if (width > MaxDesktopWidth)
            {
                return DeviceTypeEnum.Hub;
            }

            if (width > MaxTabletWidth)
            {
                return DeviceTypeEnum.Desktop;
            }

            if (width > MaxMobileWidth)
            {
                return DeviceTypeEnum.Tablet;
            }

            return DeviceTypeEnum.Mobile;
        }

        /// <summary>
        /// Gets the columns by device type.
        /// </summary>
        /// <param name="deviceType">Type of the device.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentOutOfRangeException">deviceType</exception>
        private int GetColumnsByDeviceType(DeviceTypeEnum deviceType)
        {
            switch (deviceType)
            {
                case DeviceTypeEnum.Mobile:
                    return ColumnsInMobile;
                case DeviceTypeEnum.Tablet:
                    return ColumnsInTablet;
                case DeviceTypeEnum.Desktop:
                    return ColumnsInDesktop;
                case DeviceTypeEnum.Hub:
                    return ColumnsInDesktop;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deviceType));
            }
        }

        #endregion

        #region Enumerations

        /// <summary>
        /// Enum ItemStyleEnum
        /// </summary>
        public enum ItemStyleEnum
        {
            Relative, Square, Portrait, Landscape
        }

        /// <summary>
        /// Enum DeviceTypeEnum
        /// </summary>
        public enum DeviceTypeEnum
        {
            Mobile, Tablet, Desktop, Hub
        }

        #endregion

        #region Notify Property Changed

        /// <summary>
        /// PropertyChanged event 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
