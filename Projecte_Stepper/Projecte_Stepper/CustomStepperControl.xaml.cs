using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projecte_Stepper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomStepperControl : ContentView
    {
        #region .: Properties :.

        private const string ButtonLeftDefaultText = "-";
        private const string ButtonRightDefaultText = "+";
        private const float LabelCornerRadiusDefaultValue = 0f;
        private const float ValueDefaultValue = 0f;
        private const float ValueIncrementDefaultValue = 5f;

        public string ButtonLeftText
        {
            get { return (string)GetValue(ButtonLeftTextProperty); }
            set { SetValue(ButtonLeftTextProperty, value); }
        }

        public string ButtonRightText
        {
            get { return (string)GetValue(ButtonRightTextProperty); }
            set { SetValue(ButtonRightTextProperty, value); }
        }

        public LayoutDirection Direction
        {
            get { return (LayoutDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public float LabelCornerRadius
        {
            get { return (float)GetValue(LabelCornerRadiusProperty); }
            set { SetValue(LabelCornerRadiusProperty, value); }
        }

        public bool LabelIsVisible
        {
            get { return (bool)GetValue(LabelIsVisibleProperty); }
            set { SetValue(LabelIsVisibleProperty, value); }
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public float ValueIncrement
        {
            get { return (float)GetValue(ValueIncrementProperty); }
            set { SetValue(ValueIncrementProperty, value); }
        }


        #endregion

        #region .: Bindable Properties :.

        private readonly BindableProperty ButtonLeftTextProperty =
            BindableProperty.Create(nameof(ButtonLeftText), typeof(string), typeof(CustomStepperControl), ButtonLeftDefaultText,
                propertyChanged: OnButtonLeftTextPropertyChanged);

        private readonly BindableProperty ButtonRightTextProperty =
             BindableProperty.Create(nameof(ButtonRightText), typeof(string), typeof(CustomStepperControl), ButtonRightDefaultText,
                 propertyChanged: OnButtonRightTextPropertyChanged);

        private readonly BindableProperty DirectionProperty =
            BindableProperty.Create(nameof(Direction), typeof(LayoutDirection), typeof(CustomStepperControl), LayoutDirection.Horizontal,
                propertyChanged: OnDirectionPropertyChanged);

        private readonly BindableProperty LabelCornerRadiusProperty =
            BindableProperty.Create(nameof(LabelCornerRadius), typeof(float), typeof(CustomStepperControl), LabelCornerRadiusDefaultValue,
                propertyChanged: OnLabelCornerRadiusPropertyChanged);

        private readonly BindableProperty LabelIsVisibleProperty =
            BindableProperty.Create(nameof(LabelIsVisible), typeof(bool), typeof(CustomStepperControl), true,
                propertyChanged: OnLabelIsVisiblePropertyChanged);

        private readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(float), typeof(CustomStepperControl), ValueDefaultValue);

        private readonly BindableProperty ValueIncrementProperty =
            BindableProperty.Create(nameof(ValueIncrement), typeof(float), typeof(CustomStepperControl), ValueIncrementDefaultValue);

        #endregion

        #region .: Constructor :.

        public CustomStepperControl()
        {
            InitializeComponent();

            InitializeEvents();
            LoadDefaulValues();
        }

        #endregion

        #region .: Events :.

        private void OnButtonLeftClick(object sender, EventArgs e)
        {
            var isNumber = float.TryParse(LabelDisplay.Text, out float numberValue);
            if (!isNumber) return;

            Value = numberValue;

            LabelDisplay.Text = (Value - ValueIncrement).ToString();
        }

        private void OnButtonRightClick(object sender, EventArgs e)
        {
            var isNumber = float.TryParse(LabelDisplay.Text, out float numberValue);
            if (!isNumber) return;

            Value = numberValue;
            
            LabelDisplay.Text = (Value + ValueIncrement).ToString();
        }

        #endregion

        #region .: PropertyChanged's :.

        private static void OnButtonLeftTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepperControl)bindable;

            if(newValue is string buttonLeftText)
            {
                control.ButtonLeft.Text = buttonLeftText;
            }
        }

        private static void OnButtonRightTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepperControl)bindable;

            if (newValue is string buttonRightText)
            {
                control.ButtonRight.Text = buttonRightText;
            }
        }

        private static void OnDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepperControl)bindable;

            if (newValue is LayoutDirection layoutDirection)
            {
                if (layoutDirection == LayoutDirection.Vertical)
                    control.GeneralLayout.Direction = FlexDirection.Column;
                else
                    control.GeneralLayout.Direction = FlexDirection.Row;
            }
        }

        private static void OnLabelCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepperControl)bindable;

            if(newValue is float cornerRadius)
            {
                control.LabelFrame.CornerRadius = cornerRadius;
            }
        }

        private static void OnLabelIsVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepperControl)bindable;

            if (newValue is bool labelIsVisible)
            {
                control.LabelFrame.IsVisible = labelIsVisible;
            }
        }

        #endregion

        #region .: Private Methods:

        private void InitializeEvents()
        {
            ButtonLeft.Clicked += OnButtonLeftClick;
            ButtonRight.Clicked += OnButtonRightClick;
        }

        private void LoadDefaulValues()
        {
            ButtonLeft.Text = ButtonLeftDefaultText;
            ButtonRight.Text = ButtonRightDefaultText;
            LabelDisplay.Text = ((int)ValueDefaultValue).ToString();
        }



        #endregion
    }



    public enum LayoutDirection
    {
        Horizontal = 0,
        Vertical = 1
    }
}