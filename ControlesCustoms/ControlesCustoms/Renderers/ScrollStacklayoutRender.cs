using Android.Content;
using Android.Runtime;
using Android.Views;
using ControlesCustoms.Android.Previews;
using ControlesCustoms.Android.Renderers;
using ControlesCustoms.Standard.Stacklayouts;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.Animations.Animation;

[assembly: ExportRenderer(typeof(ScrollStacklayout), typeof(ScrollStacklayoutRender))]
namespace ControlesCustoms.Android.Renderers
{
    [Preserve(AllMembers = true)]

    public class ScrollStacklayoutRender : ViewRenderer<ScrollStacklayout, ScrollStacklayoutPreview>
    {
        ScrollStacklayout _control;
        float _position;
        public double HeightScreen
        {
            get { return Application.Current.MainPage.Height; }
        }
        public ScrollStacklayoutRender() : base()
        {

        }
        public async static void Init()
#pragma warning restore CS1998 
        {
            var temp = DateTime.Now;
        }
        ScrollStacklayoutPreview _stacklayout;
        public ScrollStacklayoutRender(Context context) : base(context)
        {

        }



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (sender is ScrollStacklayout)
            {
                var control = (ScrollStacklayout)sender;
                var panel = _stacklayout;
                var parent = (ScrollStacklayoutRender)panel.Parent;
                if (e.PropertyName == "OffSetY")
                {
                    var retour = (float)control.OffSetY;
                    var height = parent.Height;
                    var positionactuel = parent.GetY();
                    if (control.WithNavigation && _position == 0)
                    {
                        _position = positionactuel;
                    }
                    if (positionactuel + retour >= _position)
                    {
                        parent.SetY(_position);
                        control.ReStartOffSetY = 0;
                        return;
                    }
                    parent.SetY(positionactuel + retour);
                }

                else if (e.PropertyName == "Height" && !control.WithNavigation)
                {
                    int coef = (int)(control.SizeUWP / HeightScreen);
                    parent.SetY((float)(control.SizeUWP - (control.HeightAncre * coef)));
                    _position = parent.GetY();
                }
                else
                    control.HeightNavigation = HeightScreen;

            }
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollStacklayout> e)
        {

            base.OnElementChanged(e);
            if (Control == null)
            {
                _stacklayout = new ScrollStacklayoutPreview(Context);
                SetNativeControl(_stacklayout);
                _control = e.NewElement;
                _control.SizeUWP = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height;
            }
        }

    }
}