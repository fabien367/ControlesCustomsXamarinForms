using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ControlesCustoms.Android.Previews
{
    public class ScrollStacklayoutPreview : View
    {

        View view;
        public ScrollStacklayoutPreview(Context context) : base(context)
        {
            view = new View(context);
        }
    }
}