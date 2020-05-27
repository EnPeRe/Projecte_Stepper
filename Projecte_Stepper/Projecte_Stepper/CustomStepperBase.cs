using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projecte_Stepper
{
    public class CustomStepperBase : StackLayout
    {
        Button MinusBtn;
        Button PlusBtn;
        Entry Entry;

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
             propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(CustomStepperBase),
              defaultValue: 1,
              defaultBindingMode: BindingMode.TwoWay);

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public CustomStepperBase()
        {
            MinusBtn = new Button { Text = "-", WidthRequest = 40, FontAttributes = FontAttributes.Bold, FontSize = 15 };
            PlusBtn = new Button { Text = "+", WidthRequest = 40, FontAttributes = FontAttributes.Bold, FontSize = 15 };

            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                case Device.Android:
                    {
                        PlusBtn.BackgroundColor = Color.LightGray;
                        MinusBtn.BackgroundColor = Color.LightGray;
                        break;
                    }
                case Device.iOS:
                    {
                        PlusBtn.BackgroundColor = Color.DarkGray;
                        MinusBtn.BackgroundColor = Color.DarkGray;
                        break;
                    }
            }

            Orientation = StackOrientation.Horizontal;

            MinusBtn.Clicked += MinusBtn_Clicked;
            PlusBtn.Clicked += PlusBtn_Clicked;
            Entry = new Entry
            {
                PlaceholderColor = Color.Gray,
                Keyboard = Keyboard.Numeric,
                WidthRequest = 40,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.FromHex("#3FFF")
            };
            Entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            Entry.TextChanged += Entry_TextChanged;

            Children.Add(MinusBtn);
            Children.Add(Entry);
            Children.Add(PlusBtn);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                this.Text = int.Parse(e.NewTextValue);
        }

        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            Text++;
        }
    }
}
