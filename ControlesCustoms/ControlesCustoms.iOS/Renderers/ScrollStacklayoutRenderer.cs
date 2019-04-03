using ControlesCustoms.iOS.Previews;
using ControlesCustoms.iOS.Renderers;
using ControlesCustoms.Standard.Stacklayouts;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScrollStacklayout), typeof(ScrollStacklayoutRenderer))]
namespace ControlesCustoms.iOS.Renderers
{
    public class ScrollStacklayoutRenderer : ViewRenderer<ScrollStacklayout, ScrollStacklayoutPreview>
    {
        public static void Initialize()
        {
        }
        ScrollStacklayoutPreview _control;
        ScrollStacklayout _scrollStacklayout;
        public ScrollStacklayoutRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollStacklayout> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                if (e.NewElement != null)
                {
                    _control = new ScrollStacklayoutPreview();

                    _scrollStacklayout = e.NewElement as ScrollStacklayout;
                    _scrollStacklayout.HeightNavigation = UIScreen.MainScreen.Bounds.Height;
                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {

            }
            else if (e.PropertyName == "OffSetY")
            {

            }
            base.OnElementPropertyChanged(sender, e);
        }

    }
}