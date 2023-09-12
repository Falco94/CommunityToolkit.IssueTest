using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkit.IssueTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new TestView();
	}
}

public class TestView : ContentPage
{
    TestModel model;

    public TestView()
    {
        model = new TestModel();
        BindingContext = model;

        Content = new Grid
        {
            Children =
            {
                new VerticalStackLayout
                {
                    new Label
                    {

                    }.Bind(Label.TextProperty, path: "NestedObject.Test"),

                    new Label
                    {

                    }.Bind(Label.TextProperty, getter: static (TestModel myModel) => myModel.NestedObject.Test),

					new Entry
                    {

                    }.Bind(Entry.TextProperty, static (TestModel model) => model.NestedObject.Test, (TestModel model, string value) => model.NestedObject.Test = value),

                }
            }
        };
    }
}

public partial class TestModel : ObservableObject
{
    [ObservableProperty]
    NestedObject nestedObject = new();

    [ObservableProperty]
    NestedObject? nestedObject2;

    [ObservableProperty]
    string title = "My Title";
}


public partial class NestedObject : ObservableObject
{
    [ObservableProperty]
    string test = "Initial";
}
