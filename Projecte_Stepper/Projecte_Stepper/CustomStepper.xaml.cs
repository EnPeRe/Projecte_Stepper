using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projecte_Stepper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomStepper : ContentView
    {

        #region .: Properties :.

        private const string ButtonLeftDefaultText = "-";
        private const string ButtonRightDefaultText = "+";
        private const float CornerRadiusDefaultValue = 5f;
        private const float DefaultRelativeSize = 0.33f;
        private const float ValueDefaultValue = 0f;
        private const float ValueIncrementDefaultValue = 1f;

        #region Buttons

        public int ButtonLeftCornerRadius
        {
            get { return (int)GetValue(ButtonLeftCornerRadiusProperty); }
            set { SetValue(ButtonLeftCornerRadiusProperty, value); }
        }

        public float ButtonLeftRelativeSize
        {
            get { return (float)GetValue(ButtonLeftRelativeSizeProperty); }
            set { SetValue(ButtonLeftRelativeSizeProperty, value); }
        }

        public ElementSize ButtonLeftSize
        {
            get { return (ElementSize)GetValue(ButtonLeftSizeProperty); }
            set { SetValue(ButtonLeftSizeProperty, value); }
        }

        public string ButtonLeftText
        {
            get { return (string)GetValue(ButtonLeftTextProperty); }
            set { SetValue(ButtonLeftTextProperty, value); }
        }

        public int ButtonRightCornerRadius
        {
            get { return (int)GetValue(ButtonRightCornerRadiusProperty); }
            set { SetValue(ButtonRightCornerRadiusProperty, value); }
        }

        public float ButtonRightRelativeSize
        {
            get { return (float)GetValue(ButtonRightRelativeSizeProperty); }
            set { SetValue(ButtonRightRelativeSizeProperty, value); }
        }

        public ElementSize ButtonRightSize
        {
            get { return (ElementSize)GetValue(ButtonRightSizeProperty); }
            set { SetValue(ButtonRightSizeProperty, value); }
        }

        public string ButtonRightText
        {
            get { return (string)GetValue(ButtonRightTextProperty); }
            set { SetValue(ButtonRightTextProperty, value); }
        }

        #endregion

        public LayoutDirection Direction
        {
            get { return (LayoutDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        #region Label

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

        public ElementSize LabelSize
        {
            get { return (ElementSize)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        #endregion

        public LayoutOrder Order
        {
            get { return (LayoutOrder)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        #region Value

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

        #endregion

        #region .: Bindable Properties :.

        #region Buttons

        public static readonly BindableProperty ButtonLeftCornerRadiusProperty =
             BindableProperty.Create(nameof(ButtonLeftCornerRadius), typeof(int), typeof(CustomStepper), (int)CornerRadiusDefaultValue,
                 propertyChanged: OnButtonLeftCornerRadiusPropertyChanged);

        public static readonly BindableProperty ButtonLeftRelativeSizeProperty =
             BindableProperty.Create(nameof(ButtonLeftRelativeSize), typeof(float), typeof(CustomStepper), DefaultRelativeSize,
                 propertyChanged: OnButtonLeftRelativeSizePropertyChanged);

        public static readonly BindableProperty ButtonLeftSizeProperty =
             BindableProperty.Create(nameof(ButtonLeftSize), typeof(ElementSize), typeof(CustomStepper), ElementSize.Large,
                 propertyChanged: OnButtonLeftSizePropertyChanged);

        public static readonly BindableProperty ButtonLeftTextProperty =
            BindableProperty.Create(nameof(ButtonLeftText), typeof(string), typeof(CustomStepper), ButtonLeftDefaultText,
                propertyChanged: OnButtonLeftTextPropertyChanged);

        public static readonly BindableProperty ButtonRightCornerRadiusProperty =
             BindableProperty.Create(nameof(ButtonRightCornerRadius), typeof(int), typeof(CustomStepper), (int)CornerRadiusDefaultValue,
                 propertyChanged: OnButtonRightCornerRadiusPropertyChanged);

        public static readonly BindableProperty ButtonRightRelativeSizeProperty =
             BindableProperty.Create(nameof(ButtonRightRelativeSize), typeof(float), typeof(CustomStepper), DefaultRelativeSize,
                 propertyChanged: OnButtonRightRelativeSizePropertyChanged);

        public static readonly BindableProperty ButtonRightSizeProperty =
             BindableProperty.Create(nameof(ButtonRightSize), typeof(ElementSize), typeof(CustomStepper), ElementSize.Large,
                 propertyChanged: OnButtonRightSizePropertyChanged);

        public static readonly BindableProperty ButtonRightTextProperty =
             BindableProperty.Create(nameof(ButtonRightText), typeof(string), typeof(CustomStepper), ButtonRightDefaultText,
                 propertyChanged: OnButtonRightTextPropertyChanged);

        #endregion

        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(nameof(Direction), typeof(LayoutDirection), typeof(CustomStepper), LayoutDirection.Horizontal,
                propertyChanged: OnDirectionPropertyChanged);

        #region Label

        public static readonly BindableProperty LabelCornerRadiusProperty =
            BindableProperty.Create(nameof(LabelCornerRadius), typeof(float), typeof(CustomStepper), CornerRadiusDefaultValue,
                propertyChanged: OnLabelCornerRadiusPropertyChanged);

        public static readonly BindableProperty LabelIsVisibleProperty =
            BindableProperty.Create(nameof(LabelIsVisible), typeof(bool), typeof(CustomStepper), true,
                propertyChanged: OnLabelIsVisiblePropertyChanged);

        public static readonly BindableProperty LabelSizeProperty =
             BindableProperty.Create(nameof(LabelSize), typeof(ElementSize), typeof(CustomStepper), ElementSize.Large,
                 propertyChanged: OnLabelSizePropertyChanged);

        #endregion

        public static readonly BindableProperty OrderProperty =
            BindableProperty.Create(nameof(Order), typeof(LayoutOrder), typeof(CustomStepper), LayoutOrder.ButtonLabelButton,
                propertyChanged: OnOrderPropertyChanged);

        #region Value

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(float), typeof(CustomStepper), ValueDefaultValue);

        public static readonly BindableProperty ValueIncrementProperty =
            BindableProperty.Create(nameof(ValueIncrement), typeof(float), typeof(CustomStepper), ValueIncrementDefaultValue);

        public static readonly BindableProperty ValueMaxValueProperty =
            BindableProperty.Create(nameof(ValueMaxValue), typeof(float), typeof(CustomStepper), float.MaxValue);

        public static readonly BindableProperty ValueMinValueProperty =
            BindableProperty.Create(nameof(ValueMinValue), typeof(float), typeof(CustomStepper), float.MinValue);

        #endregion

        #endregion

        #region .: Constructor :.

        public CustomStepper()
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

        private static void OnButtonLeftCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if(newValue is int cornerRadius)
            {
                control.ButtonLeft.CornerRadius = cornerRadius;
            }
        }

        private static void OnButtonLeftRelativeSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is float)
            {
                control.SetGeneralLayout();
            }
        }

        private static void OnButtonLeftSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if(newValue is ElementSize elementSize)
            {
                control.SetSize(control.ButtonLeft, elementSize);
            }
        }

        private static void OnButtonLeftTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if(newValue is string buttonLeftText)
            {
                control.ButtonLeft.Text = buttonLeftText;
            }
        }

        private static void OnButtonRightCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is int cornerRadius)
            {
                control.ButtonRight.CornerRadius = cornerRadius;
            }
        }

        private static void OnButtonRightRelativeSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if(newValue is float)
            {
                control.SetGeneralLayout();
            }
        }

        private static void OnButtonRightSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is ElementSize elementSize)
            {
                control.SetSize(control.ButtonRight, elementSize);
            }
        }

        private static void OnButtonRightTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is string buttonRightText)
            {
                control.ButtonRight.Text = buttonRightText;
            }
        }

        private static void OnDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

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
            var control = (CustomStepper)bindable;

            if(newValue is float cornerRadius)
            {
                control.LabelFrame.CornerRadius = cornerRadius;
            }
        }

        private static void OnLabelIsVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is bool labelIsVisible)
            {
                control.LabelFrame.IsVisible = labelIsVisible;
                control.SetGeneralLayout();
            }
        }

        private static void OnLabelSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if (newValue is ElementSize elementSize)
            {
                control.SetSize(control.LabelFrame, elementSize);
            }
        }

        private static void OnOrderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStepper)bindable;

            if(newValue is LayoutOrder layoutOrder)
            {
                switch (layoutOrder)
                {
                    case LayoutOrder.LabelButtonButton:
                        FlexLayout.SetOrder(control.LabelFrame, 0);
                        FlexLayout.SetOrder(control.ButtonLeft, 1);
                        FlexLayout.SetOrder(control.ButtonRight, 2);
                        break;
                    case LayoutOrder.ButtonLabelButton:
                        FlexLayout.SetOrder(control.ButtonLeft, 0);
                        FlexLayout.SetOrder(control.LabelFrame, 1);
                        FlexLayout.SetOrder(control.ButtonRight, 2);
                        break;
                    case LayoutOrder.ButtonButtonLabel:
                        FlexLayout.SetOrder(control.ButtonLeft, 0);
                        FlexLayout.SetOrder(control.ButtonRight, 1);
                        FlexLayout.SetOrder(control.LabelFrame, 2);
                        break;
                    default:
                        break;
                }
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
            ButtonLeftRelativeSize = DefaultRelativeSize;
            ButtonRightRelativeSize = DefaultRelativeSize;
            ButtonLeft.Text = ButtonLeftDefaultText;
            ButtonRight.Text = ButtonRightDefaultText;
            LabelDisplay.Text = ((int)ValueDefaultValue).ToString();
        }

        private void SetGeneralLayout()
        {
            float buttonLeftRelativeSize = ButtonLeftRelativeSize;
            float buttonRightRelativeSize = ButtonRightRelativeSize;
            float total = 1f;

            if ((decimal)(buttonLeftRelativeSize + buttonRightRelativeSize) > 1 || 
                (decimal)(buttonLeftRelativeSize + buttonRightRelativeSize) < 0) 
                    return;

            if (!LabelFrame.IsVisible)
            {
                var newTotalRelative = (decimal)(buttonLeftRelativeSize + buttonRightRelativeSize);

                buttonLeftRelativeSize = buttonLeftRelativeSize / (float)newTotalRelative;
                buttonRightRelativeSize = buttonRightRelativeSize / (float)newTotalRelative;
            }

            decimal labelFrameRelativeSize = (decimal)(total - (buttonLeftRelativeSize + buttonRightRelativeSize));

            if (labelFrameRelativeSize < 0 || labelFrameRelativeSize > 1) return;

            FlexLayout.SetBasis(ButtonLeft, new FlexBasis(buttonLeftRelativeSize, true));
            FlexLayout.SetBasis(ButtonRight, new FlexBasis(buttonRightRelativeSize, true));
            FlexLayout.SetBasis(LabelFrame, new FlexBasis((float)labelFrameRelativeSize, true));
        }

        private void SetSize(View view, ElementSize elementSize)
        {
            switch (elementSize)
            {
                case ElementSize.Max:
                    view.Margin = 0;
                    break;
                case ElementSize.Large:
                    view.Margin = 5;
                    break;
                case ElementSize.MediumLarge:
                    view.Margin = 10;
                    break;
                case ElementSize.Medium:
                    view.Margin = 15;
                    break;
                case ElementSize.MediumSmall:
                    view.Margin = 20;
                    break;
                case ElementSize.Small:
                    view.Margin = 25;
                    break;
                case ElementSize.Tiny:
                    view.Margin = 30;
                    break;
                case ElementSize.Micro:
                    view.Margin = 35;
                    break;
                case ElementSize.Nano:
                    view.Margin = 40;
                    break;
                case ElementSize.Min:
                    view.Margin = 45;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }

    #region .: Configuration Enums :.

    public enum ElementSize
    {
        Max = 0,
        Large = 1,
        MediumLarge = 2,
        Medium = 3,
        MediumSmall = 4,
        Small = 5,
        Tiny = 6,
        Micro = 7,
        Nano = 8,
        Min = 9
    }

    public enum LayoutDirection
    {
        Horizontal = 0,
        Vertical = 1
    }

    public enum LayoutOrder
    {
        LabelButtonButton = 0,
        ButtonLabelButton = 1,
        ButtonButtonLabel = 2
    }

    #endregion
}