using Android.Content;
using Android.Runtime;
using ControlesCustoms.Android.Previews;
using ControlesCustoms.Android.Renderers;
using ControlesCustoms.Standard.Stacklayouts;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollStacklayout), typeof(ScrollStacklayoutRender))]
namespace ControlesCustoms.Android.Renderers
{
    [Preserve(AllMembers = true)]

    public class ScrollStacklayoutRender : ViewRenderer<ScrollStacklayout, ScrollStacklayoutPreview>
    {
        int _coef;
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
                   
                    var positionNotPassed = MoveAndroid() * _coef;
                    if (positionactuel + retour >= _control.Position*_coef)
                    {
                        control.ReStartOffSetY = 0;
                        return;
                    }
                    else if (positionactuel + retour >= positionNotPassed)
                        parent.SetY(positionactuel + retour);
                    return;
                }

                else if (e.PropertyName == "Height")
                {
                    _coef = (int)(control.Size / HeightScreen);
                    parent.SetY((float)(control.Size - (control.HeightAncre * _coef)));
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
                _control.Size = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height;
            }
        }

        private double MoveAndroid()
        {
            double positionNotPassed = _control.HeightChildren > _control.Position ? 0 : (_control.Position - _control.HeightChildren + _control.HeightSpliter + 20);
            return positionNotPassed;
        }
    }
}