using ControlesCustoms.Standard.Stacklayouts;
using ControlesCustoms.UWP.Previews;
using ControlesCustoms.UWP.Renderers;
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
                Debug.WriteLine("1er fois");
                var nativeControl = Control as ScrollStacklayoutPreview;
                _control = e.NewElement;

                _control.Children.Add(new ScrollStacklayoutPreview());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var size = ApplicationView.GetForCurrentView().VisibleBounds;
            _control.SizeUWP = size.Height;
            //_control.HeightAncre = _control.Children[0].Height;
            if (e.PropertyName == "OffSetY")
            {
                var retour = _control.OffSetY;
                _position = _position + retour;
                Debug.WriteLine("Position initial du stack: " + _position);
                RenderTransform = new CompositeTransform() { TranslateY = retour };
            }

            else
            {
                _control.TranslationY = (size.Height - _control.HeightAncre);
                _control.ReStartOffSetY = _control.TranslationY;

                Debug.WriteLine("Position initial du stack: " + _position);
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
