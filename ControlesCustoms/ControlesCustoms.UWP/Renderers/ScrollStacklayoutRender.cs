using ControlesCustoms.Standard.Stacklayouts;
using ControlesCustoms.UWP.Previews;
using ControlesCustoms.UWP.Renderers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ScrollStacklayout), typeof(ScrollStacklayoutRender))]
namespace ControlesCustoms.UWP.Renderers
{
    public class ScrollStacklayoutRender : ViewRenderer<ScrollStacklayout, ScrollStacklayoutPreview>
    {
        ScrollStacklayout _control;
        readonly CoreDispatcher _dispatcher = Window.Current.Dispatcher;
        double _position = 0;
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollStacklayout> e)
        {

            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _control = e.NewElement;
                _control.HeightNavigation = ApplicationView.GetForCurrentView().VisibleBounds.Height;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName== "Height")
            {
                _control.HeightNavigation = ApplicationView.GetForCurrentView().VisibleBounds.Height;
            }
            
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
