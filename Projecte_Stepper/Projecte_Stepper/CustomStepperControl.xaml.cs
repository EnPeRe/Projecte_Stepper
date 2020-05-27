using System;

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
        private const float LabelCornerRadiusDefaultValue = 5f;
        private const float ValueDefaultValue = 0f;
        private const float ValueIncrementDefaultValue = 1f;

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

        public float ValueMaxValue
        {
            get { return (float)GetValue(ValueMaxValueProperty); }
            set { SetValue(ValueMaxValueProperty, value); }
        }

        public float ValueMinValue
        {
            get { return (float)GetValue(ValueMinValueProperty); }
            set { SetValue(ValueMinValueProperty, value); }
        }

        #endregion

        #region .: Bindable Properties :.

        public static readonly BindableProperty ButtonLeftTextProperty =
            BindableProperty.Create(nameof(ButtonLeftText), typeof(string), typeof(CustomStepperControl), ButtonLeftDefaultText,
                propertyChanged: OnButtonLeftTextPropertyChanged);

        public static readonly BindableProperty ButtonRightTextProperty =
             BindableProperty.Create(nameof(ButtonRightText), typeof(string), typeof(CustomStepperControl), ButtonRightDefaultText,
                 propertyChanged: OnButtonRightTextPropertyChanged);

        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(nameof(Direction), typeof(LayoutDirection), typeof(CustomStepperControl), LayoutDirection.Horizontal,
                propertyChanged: OnDirectionPropertyChanged);

        public static readonly BindableProperty LabelCornerRadiusProperty =
            BindableProperty.Create(nameof(LabelCornerRadius), typeof(float), typeof(CustomStepperControl), LabelCornerRadiusDefaultValue,
                propertyChanged: OnLabelCornerRadiusPropertyChanged);

        public static readonly BindableProperty LabelIsVisibleProperty =
            BindableProperty.Create(nameof(LabelIsVisible), typeof(bool), typeof(CustomStepperControl), true,
                propertyChanged: OnLabelIsVisiblePropertyChanged);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(float), typeof(CustomStepperControl), ValueDefaultValue);

        public static readonly BindableProperty ValueIncrementProperty =
            BindableProperty.Create(nameof(ValueIncrement), typeof(float), typeof(CustomStepperControl), ValueIncrementDefaultValue);

        public static readonly BindableProperty ValueMaxValueProperty =
            BindableProperty.Create(nameof(ValueMaxValue), typeof(float), typeof(CustomStepperControl), float.MaxValue);

        public static readonly BindableProperty ValueMinValueProperty =
            BindableProperty.Create(nameof(ValueMinValue), typeof(float), typeof(CustomStepperControl), float.MinValue);

        #endregion

        #region .: Constructor :.

        public CustomStepperControl()
        {
            InitializeComponent();

            InitializeEvents();
            LoadDefaulValues();
            SetGeneralLayout();
        }

        #endregion

        #region .: Events :.

        private void OnButtonLeftClick(object sender, EventArgs e)
        {
            var isNumber = float.TryParse(LabelDisplay.Text, out float numberValue);
            if (!isNumber) return;

            var newValue = (decimal)(Value - ValueIncrement);

            if ((float)newValue >= ValueMinValue)
            {
                LabelDisplay.Text = (newValue).ToString();
                Value = (float)newValue;
            }
        }

        private void OnButtonRightClick(object sender, EventArgs e)
        {
            var isNumber = float.TryParse(LabelDisplay.Text, out float numberValue);
            if (!isNumber) return;

            var newValue = (decimal)(Value + ValueIncrement);

            if ((float)newValue <= ValueMaxValue)
            {
                LabelDisplay.Text = (newValue).ToString();
                Value = (float)newValue;
            }

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
                control.SetGeneralLayout();
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

        private void SetGeneralLayout()
        {
            float buttonLeftRelativeSize = 0.33f;
            float buttonRightRelativeSize = 0.43f;
            float total = 1f;

            if (!LabelFrame.IsVisible)
            {
                var newTotalRelative = buttonLeftRelativeSize + buttonRightRelativeSize;

                buttonLeftRelativeSize = buttonLeftRelativeSize / newTotalRelative;
                buttonRightRelativeSize = buttonRightRelativeSize / newTotalRelative;
            }

            float labelFrameRelativeSize = total - (buttonLeftRelativeSize + buttonRightRelativeSize);

            if (labelFrameRelativeSize < 0 || labelFrameRelativeSize > 1) return;

            FlexLayout.SetBasis(ButtonLeft, new FlexBasis(buttonLeftRelativeSize, true));
            FlexLayout.SetBasis(ButtonRight, new FlexBasis(buttonRightRelativeSize, true));
            FlexLayout.SetBasis(LabelFrame, new FlexBasis(labelFrameRelativeSize, true));
        }

        #endregion
    }



    public enum LayoutDirection
    {
        Horizontal = 0,
        Vertical = 1
    }
}