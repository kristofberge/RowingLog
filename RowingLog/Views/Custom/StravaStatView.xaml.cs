using Xamarin.Forms;

namespace RowingLog.Views.Custom
{
    public partial class StravaStatView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(StravaStatView),
            default(string)
        );

        public static readonly BindableProperty NumberProperty = BindableProperty.Create(
            nameof(Number),
            typeof(string),
            typeof(StravaStatView),
            default(string)
        );

        public static readonly BindableProperty UnitProperty = BindableProperty.Create(
            nameof(Unit),
            typeof(string),
            typeof(StravaStatView),
            default(string)
        );

        public StravaStatView()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Number
        {
            get => (string)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }
    }
}
