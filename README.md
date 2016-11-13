# ResponsiveGridView
Extended functionality of **GridView** Control for Universal Windows Platform.

##Main Features:

* Define the columns you want based on the screen size (ColumnsInMobile, ColumnsInTablet, ColumnsInDesktop, ColumnsInHub).
* Set your own screen breakpoints (MaxMobileWidth, MaxTabletWidth, MaxDesktopWidth).
* Set desired ItemWidth and ItemHeight, along with ItemStyle="Relative", and auto-adjust the item template based on the screen size.
* Force the item template with a default style (ItemStyle="Square|Portrait|Landscape").
* Event that detects when scrollbar reaches the end.

##Examples:
```xaml
<ext:ResponsiveGridView 
   ItemStyle="Relative"
   ItemWidth="450"
   ItemHeight="320"
   ColumnsInMobile="1"
   ColumnsInTablet="2"
   ColumnsInDesktop="3"
   ColumnsInHub="4"
   MaxMobileWidth="640"
   MaxTabletWidth="1007"
   MaxDesktopWidth="1920"
   ItemSpace="0 0 5 5"
   ItemBackground="LightGray"
   ScrollReachedToEnd="ListOnScrollReachedToEnd"/>
```
Or if you want to have a shared style:
```xaml
<Style x:Key="BaseResponsiveGridViewStyle" TargetType="ext:ResponsiveGridView">
   <Setter Property="MaxMobileWidth" Value="640"/>
   <Setter Property="MaxTabletWidth" Value="1007"/>
   <Setter Property="MaxDesktopWidth" Value="1920"/>
   <Setter Property="ItemBackground" Value="LightGray"/>
</Style>

<ext:ResponsiveGridView 
   ColumnsInMobile="2"
   ColumnsInTablet="4"
   ColumnsInDesktop="6"
   ColumnsInHub="8"
   ItemStyle="Square"
   ItemSpace="0 0 5 5"
   Style="{StaticResource BaseResponsiveGridViewStyle}"
   ScrollReachedToEnd="ListOnScrollReachedToEnd"/>
```

##Class Wiki:
###Dependency Properties
* **ItemWidth**: double (default)
* **ItemHeight**: double (default)
* **ItemSpace**:  Thickness (default)
* **ItemStyle**: ItemStyleEnum (**Relative**|Square|Portrait|Landscape)
* **ItemVerticalAlignment**: VerticalAlignment (Top|Center|Bottom|**Stretch**)
* **ItemHorizontalAlignment**: HorizontalAlignment (Left|Center|Right|**Stretch**)
* **ItemBackground**: Brush (Colors.Transparent)
* **ColumnsInMobile**: int (1)
* **ColumnsInTablet**: int (1)
* **ColumnsInDesktop**: int (1)
* **ColumnsInHub**: int (1)
* **MaxMobileWidth**: double (640)
* **MaxTabletWidth**: double (1007)
* **MaxDesktopWidth**: double (1920)

###Properties
* **HasScrollReachedToEnd**: bool
* **CurrentItemWidth**: double
* **CurrentItemHeight**: double

###Events
* **ScrollReachedToEnd**
