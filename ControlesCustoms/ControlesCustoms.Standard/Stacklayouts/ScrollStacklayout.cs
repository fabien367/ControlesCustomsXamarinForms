using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ControlesCustoms.Standard.Stacklayouts
{
    public class ScrollStacklayout : StackLayout
    {

        public static readonly BindableProperty OffSetYProperty = BindableProperty.Create(
            "OffSetY",
            returnType: typeof(double),
            declaringType: typeof(ScrollStacklayout),
            defaultValue: 0d,
            defaultBindingMode: BindingMode.TwoWay);

        public double OffSetY
        {
            get { return (double)GetValue(OffSetYProperty); }
            set
            {
                SetValue(OffSetYProperty, value);
            }
        }
        public static readonly BindableProperty ReStartOffSetYProperty = BindableProperty.Create(
            "OffSetY",
            returnType: typeof(double),
            declaringType: typeof(ScrollStacklayout),
            defaultValue: 0d,
            defaultBindingMode: BindingMode.TwoWay);

        public double ReStartOffSetY
        {
            get { return (double)GetValue(ReStartOffSetYProperty); }
            set
            {
                SetValue(ReStartOffSetYProperty, value);
            }
        }

        public static readonly BindableProperty SizeUWPProperty = BindableProperty.Create(
           "SizeUWP",
           returnType: typeof(double),
           declaringType: typeof(ScrollStacklayout),
           defaultValue: 0d,
           defaultBindingMode: BindingMode.TwoWay);
        public double SizeUWP
        {

            get { return (double)GetValue(SizeUWPProperty); }
            set
            {
                SetValue(SizeUWPProperty, value);
            }
        }

        public static readonly BindableProperty HeightAncreProperty = BindableProperty.Create(
           "HeightAncre",
           returnType: typeof(double),
           declaringType: typeof(ScrollStacklayout),
           defaultValue: 0d,
           defaultBindingMode: BindingMode.TwoWay);
        public double HeightAncre
        {

            get { return (double)GetValue(HeightAncreProperty); }
            set
            {
                SetValue(HeightAncreProperty, value);
            }
        }

        public void UpdatePosition()
        {
            if (SizeUWP>0 && HeightAncre>0)
            {
                base.TranslationY = SizeUWP - HeightAncre;
                //this.LayoutTo(new Rectangle(Bounds.X, SizeUWP - HeightAncre, Width, Height));
            }
        }

        
        
        public ScrollStacklayout()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);            
        }



        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            switch (e.StatusType)
            {
                case GestureStatus.Running:

                    if (Xamarin.Essentials.DevicePlatform.UWP == Xamarin.Essentials.DeviceInfo.Platform)
                    {
                        if ((SizeUWP - HeightAncre) >= ReStartOffSetY + e.TotalY)
                        {
                            if (ReStartOffSetY != 0)
                            {

#if DEBUG
                                Debug.WriteLine("Restart:" + ReStartOffSetY + e.TotalY);
#endif
                                OffSetY = ReStartOffSetY + e.TotalY;
                            }
                            else
                            {

#if DEBUG
                                Debug.WriteLine("Change:" + e.TotalY);
#endif
                                OffSetY = e.TotalY;
                            }
                        }
                        else
                        {

#if DEBUG
                            Debug.WriteLine("Taille max:" + (SizeUWP - HeightAncre));
#endif
                            OffSetY = (SizeUWP - HeightAncre);
                            ReStartOffSetY = (SizeUWP - HeightAncre);
                        }
                    }
                    else
                        OffSetY = e.TotalY;
                    break;
                case GestureStatus.Completed:
#if DEBUG
                    Debug.WriteLine("Completed" + OffSetY);
#endif
                    ReStartOffSetY = OffSetY;
                    break;
                case GestureStatus.Started:
                    break;
                case GestureStatus.Canceled:
                    break;
                default: break;
                    //throw new ArgumentOutOfRangeException();
            }
        }



    }

}
