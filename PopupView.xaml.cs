namespace DemoLibrary;

public partial class PopupView : PopupBase
{
    public const string DefaultOkText = "OK";
    public const string DefaultCancelText = "Cancel";


    public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(View), typeof(PopupView));
    public View Body
    {
        get => (View)GetValue(BodyProperty);
        set => SetValue(BodyProperty, value);
    }

    public PopupView()
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (width != -1 && height != -1)
        {
            cardView.WidthRequest = width * 0.5f;
            bodyContentView.Content = Body;
        }
    }
}