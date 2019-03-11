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

            //AnimatorListenerAdapter test; test. ;
            //anim.OnAnimationStart(Animation);
            //Transmissions.CustomControls.ScrollStacklayout
            //var animation = new TranslateAnimation(0, 100, 0, 0);
            //animation.Duration = 800;
            //var set = new AnimationSet(true);
            //set.AddAnimation(animation);

            //Animation.SetAnimationListener(this.AnimationListener);
            if (sender is ScrollStacklayout)
            {
                var control = (ScrollStacklayout)sender;
                var panel = _stacklayout;
                var parent = (ScrollStacklayoutRender)panel.Parent;
                var heightScreen = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height;

                if (e.PropertyName == "OffSetY")
                {
                    var retour = (float)control.OffSetY;
                    var height = parent.Height;
                    var position = parent.GetY();
                    if (position + retour <= 0)
                    {
                        return;
                    }
                    parent.SetY(position + retour);
                }
                else if (e.PropertyName == "Renderer")
                {
                    var position = parent.GetY();
                }
                else
                {
                    parent.SetY(0 + (float)(heightScreen - 200));
                }

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
            }
        }
        
    }
}