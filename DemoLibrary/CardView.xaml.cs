namespace DemoLibrary;

public partial class CardView : ContentView
{
    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(View), typeof(CardView));
    public View Header
    {
        get => (View)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(View), typeof(CardView));
    public View Body
    {
        get => (View)GetValue(BodyProperty);
        set => SetValue(BodyProperty, value);
    }

    public static readonly BindableProperty FooterProperty = BindableProperty.Create(nameof(Footer), typeof(View), typeof(CardView));
    public View Footer
    {
        get => (View)GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }

    public CardView()
	{
		InitializeComponent();
	}
}