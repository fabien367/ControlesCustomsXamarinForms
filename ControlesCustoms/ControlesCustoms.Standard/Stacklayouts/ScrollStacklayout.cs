using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ControlesCustoms.Standard.Stacklayouts
{
    public class ScrollStacklayout : StackLayout
    {

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            if ( Xamarin.Essentials.DevicePlatform.Android == Xamarin.Essentials.DeviceInfo.Platform)
                LayoutChildrenAndroid(x, y, width, height);
           else if ( Xamarin.Essentials.DevicePlatform.UWP == Xamarin.Essentials.DeviceInfo.Platform)
                LayoutChildrenUWP(x, y, width, height);
            else if (Xamarin.Essentials.DevicePlatform.iOS == Xamarin.Essentials.DeviceInfo.Platform)
                LayoutChildrenIOS(x, y, width, height);

            base.LayoutChildren(x, y, width, height);
        }

        /// <summary>
        /// Layouts the children Android.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        private void LayoutChildrenAndroid(double x, double y, double width, double height)
        {
            if (Y != HeightNavigation - HeightAncre)
            {
                HeightWithorWithoutNavigation = (HeightNavigation - height);
                this.TranslationY = HeightNavigation - (HeightAncre + HeightWithorWithoutNavigation);
                Position = HeightNavigation - (HeightAncre + HeightWithorWithoutNavigation);
            }
        }
        /// <summary>
        /// Layouts the children uwp.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        private void LayoutChildrenUWP(double x, double y, double width, double height)
        {
            if (Y != HeightNavigation - HeightAncre)
            {
                HeightWithorWithoutNavigation = (HeightNavigation - height);
                this.TranslationY = HeightNavigation - (HeightSpliter+ HeightWithorWithoutNavigation);
                Position = HeightNavigation - (HeightSpliter + HeightWithorWithoutNavigation);
            }
        }
        /// <summary>
        /// Layouts the children ios.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        private void LayoutChildrenIOS(double x, double y, double width, double height)
        {
            if (Y != HeightNavigation - HeightAncre)
            {
                HeightWithorWithoutNavigation = (HeightNavigation - height);
                this.TranslationY = HeightNavigation - (HeightAncre + HeightWithorWithoutNavigation);
                Position = HeightNavigation - (HeightAncre + HeightWithorWithoutNavigation);
                //this.TranslationY = HeightNavigation - HeightAncre;
                //Position = HeightNavigation - HeightAncre;
            }
        }

        #region Properties
        public double HeightWithorWithoutNavigation { get; set; }
        public double Position
        { get; set; }

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
        public static readonly BindableProperty WithNavigationProperty = BindableProperty.Create(
            "WithNavigation",
            returnType: typeof(bool),
            declaringType: typeof(ScrollStacklayout),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        public bool WithNavigation
        {
            get { return (bool)GetValue(WithNavigationProperty); }
            set
            {
                SetValue(WithNavigationProperty, value);
            }
        }
        public static readonly BindableProperty ReStartOffSetYProperty = BindableProperty.Create(
            "ReStartOffSetY",
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

        public static readonly BindableProperty SizeProperty = BindableProperty.Create(
           "Size",
           returnType: typeof(double),
           declaringType: typeof(ScrollStacklayout),
           defaultValue: 0d,
           defaultBindingMode: BindingMode.TwoWay);
        public double Size
        {

            get { return (double)GetValue(SizeProperty); }
            set
            {
                SetValue(SizeProperty, value);
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

        public static readonly BindableProperty HeightChildrenProperty = BindableProperty.Create(
          "HeightChildren",
          returnType: typeof(double),
          declaringType: typeof(ScrollStacklayout),
          defaultValue: 0d,
          defaultBindingMode: BindingMode.TwoWay);
        public double HeightChildren
        {

            get { return (double)GetValue(HeightChildrenProperty); }
            set
            {
                SetValue(HeightChildrenProperty, value);
            }
        }

        public static readonly BindableProperty HeightSpliterProperty = BindableProperty.Create(
          "HeightSpliter",
          returnType: typeof(double),
          declaringType: typeof(ScrollStacklayout),
          defaultValue: 0d,
          defaultBindingMode: BindingMode.TwoWay);
        public double HeightSpliter
        {

            get { return (double)GetValue(HeightSpliterProperty); }
            set
            {
                SetValue(HeightSpliterProperty, value);
            }
        }
        public double HeightNavigation
        { get; set; }


        #endregion



        public ScrollStacklayout()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }





        #region Methodes de mouvements
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            switch (e.StatusType)
            {
                case GestureStatus.Running:

                    if (Xamarin.Essentials.DevicePlatform.UWP == Xamarin.Essentials.DeviceInfo.Platform)
                    {
                        MoveUWP(e);
                    }
                    else if (Xamarin.Essentials.DevicePlatform.iOS == Xamarin.Essentials.DeviceInfo.Platform)
                    {
                        MoveIOS(e);
                    }
                    //else if (Xamarin.Essentials.DevicePlatform.Android == Xamarin.Essentials.DeviceInfo.Platform)
                    //{
                    //    MoveDroid(e);
                    //    //Device.BeginInvokeOnMainThread(async () => );
                    //}
                    else
                        OffSetY = e.TotalY;
                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Completed" + OffSetY);
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

        /// <summary>
        /// Moves the panel ios.
        /// </summary>
        /// <param name="e">E.</param>
        private void MoveDroid(PanUpdatedEventArgs e)
        {
            double positionNotPassed = HeightChildren > Position ? 0 : (Position - HeightChildren + HeightSpliter + 20);
            if (ReStartOffSetY != 0)
            {
                // dépasse pas l'écran
                if (ReStartOffSetY + e.TotalY <= positionNotPassed)
                {
                    Debug.WriteLine("ReStartOffSetY:{0}, y:{1}", (ReStartOffSetY), e.TotalY);

                }
                else if (ReStartOffSetY + e.TotalY >= Position)
                {
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    Debug.WriteLine("position avant offset:" + (OffSetY));
                    Debug.WriteLine("mvt avant offset:" + e.TotalY);
                    //this.TranslateTo(0,
                    //ReStartOffSetY + e.TotalY, 0, Easing.Linear);
                    this.TranslationY = ReStartOffSetY + e.TotalY;
                    OffSetY = ReStartOffSetY + e.TotalY;
                    Debug.WriteLine("mvt apres offset:" + e.TotalY);
                    Debug.WriteLine("position apres offset:" + (OffSetY));
                }

            }
            else
            {
                Debug.WriteLine("1 fois:" + (ReStartOffSetY + e.TotalY));
                if (Position + e.TotalY <= positionNotPassed)
                {

                }
                else if (Position + e.TotalY >= Position)
                {
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    this.TranslationY = Position + e.TotalY;
                    OffSetY = Position + e.TotalY;
                }

            }
        }

        /// <summary>
        /// Moves the panel ios.
        /// </summary>
        /// <param name="e">E.</param>
        private void MoveIOS(PanUpdatedEventArgs e)
        {
            double positionNotPassed = HeightChildren > Position ? 0 : (Position - HeightChildren + HeightSpliter);
            if (ReStartOffSetY != 0)
            {
                // dépasse pas l'écran
                if (ReStartOffSetY + e.TotalY <= positionNotPassed)
                {
                    Debug.WriteLine("ReStartOffSetY:{0}, y:{1}", (ReStartOffSetY), e.TotalY);

                    return;
                }
                else if (ReStartOffSetY + e.TotalY >= Position)
                {
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    Debug.WriteLine("position avant offset:" + (OffSetY));
                    this.TranslationY = ReStartOffSetY + e.TotalY;
                    OffSetY = ReStartOffSetY + e.TotalY;
                    Debug.WriteLine("position apres offset:" + (OffSetY));
                }

            }
            else
            {
                if (Position + e.TotalY <= positionNotPassed)
                {

                }
                else if (Position + e.TotalY >= Position)
                {
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    this.TranslationY = Position + e.TotalY;
                    OffSetY = Position + e.TotalY;
                }

            }
        }

        /// <summary>
        /// Moves the panel uwp.
        /// </summary>
        /// <param name="e">E.</param>
        private void MoveUWP(PanUpdatedEventArgs e)
        {
            double positionNotPassed = HeightChildren > Position ? 0 : (Position - HeightChildren + HeightSpliter );
            if (ReStartOffSetY != 0)
            {
                // dépasse pas l'écran
                if (ReStartOffSetY + e.TotalY <= positionNotPassed)
                {
                    ReStartOffSetY = OffSetY;
                    Debug.WriteLine("ReStartOffSetY:{0}, y:{1}", (ReStartOffSetY), e.TotalY);
                    return;
                }
                else if (ReStartOffSetY + e.TotalY >= Position)
                {
                    ReStartOffSetY = Position;
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    Debug.WriteLine("position avant offset:" + (OffSetY));
                    this.TranslationY = ReStartOffSetY + e.TotalY;
                    OffSetY = ReStartOffSetY + e.TotalY;
                    Debug.WriteLine("position apres offset:" + (OffSetY));
                }

            }
            else
            {
                if (Position + e.TotalY <= positionNotPassed)
                {

                }
                else if (Position + e.TotalY >= Position)
                {
                    Debug.WriteLine("Depasse position initial");
                }
                else
                {
                    this.TranslationY = Position + e.TotalY;
                    OffSetY = Position + e.TotalY;
                }

            }
        }


        #endregion

    }

}
