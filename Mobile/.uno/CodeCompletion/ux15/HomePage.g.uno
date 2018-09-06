[Uno.Compiler.UxGenerated]
public partial class HomePage: Fuse.Controls.Page
{
    readonly Fuse.Navigation.Router router;
    static HomePage()
    {
    }
    [global::Uno.UX.UXConstructor]
    public HomePage(
		[global::Uno.UX.UXParameter("router")] Fuse.Navigation.Router router)
    {
        this.router = router;
        InitializeUX();
    }
    void InitializeUX()
    {
        var temp = new global::Fuse.Controls.DockPanel();
        var temp1 = new global::Fuse.Controls.StackPanel();
        var temp2 = new global::Fuse.Controls.StackPanel();
        var temp3 = new global::Fuse.Controls.Text();
        var temp4 = new global::Fuse.Controls.Text();
        var temp5 = new global::Fuse.Controls.StackPanel();
        var temp6 = new global::Fuse.Controls.Text();
        var temp7 = new global::Fuse.Controls.Grid();
        var temp8 = new global::Fuse.Controls.Rectangle();
        var temp9 = new global::Fuse.Controls.Text();
        var temp10 = new global::Fuse.Controls.Rectangle();
        var temp11 = new global::Fuse.Controls.Text();
        this.SourceLineNumber = 1;
        this.SourceFileName = "Pages/HomePage.ux";
        temp.SourceLineNumber = 3;
        temp.SourceFileName = "Pages/HomePage.ux";
        temp.Children.Add(temp1);
        temp.Children.Add(temp2);
        temp1.Height = new Uno.UX.Size(10f, Uno.UX.Unit.Percent);
        temp1.SourceLineNumber = 4;
        temp1.SourceFileName = "Pages/HomePage.ux";
        global::Fuse.Controls.DockPanel.SetDock(temp1, Fuse.Layouts.Dock.Top);
        temp2.ItemSpacing = -32f;
        temp2.Height = new Uno.UX.Size(20f, Uno.UX.Unit.Percent);
        temp2.Padding = float4(5f, 5f, 5f, 5f);
        temp2.SourceLineNumber = 5;
        temp2.SourceFileName = "Pages/HomePage.ux";
        global::Fuse.Controls.DockPanel.SetDock(temp2, Fuse.Layouts.Dock.Top);
        temp2.Children.Add(temp3);
        temp2.Children.Add(temp4);
        temp2.Children.Add(temp5);
        temp3.Value = "     Q u e n t i n h a";
        temp3.FontSize = 45f;
        temp3.Color = Fuse.Drawing.Colors.White;
        temp3.SourceLineNumber = 6;
        temp3.SourceFileName = "Pages/HomePage.ux";
        temp4.Value = "Carioca";
        temp4.FontSize = 100f;
        temp4.Color = Fuse.Drawing.Colors.White;
        temp4.SourceLineNumber = 7;
        temp4.SourceFileName = "Pages/HomePage.ux";
        temp5.Padding = float4(15f, 15f, 15f, 15f);
        temp5.SourceLineNumber = 8;
        temp5.SourceFileName = "Pages/HomePage.ux";
        temp5.Children.Add(temp6);
        temp5.Children.Add(temp7);
        temp6.Value = "Uma experiência deliciosa";
        temp6.FontSize = 12f;
        temp6.Color = Fuse.Drawing.Colors.White;
        temp6.SourceLineNumber = 9;
        temp6.SourceFileName = "Pages/HomePage.ux";
        temp7.RowCount = 1;
        temp7.ColumnCount = 2;
        temp7.SourceLineNumber = 10;
        temp7.SourceFileName = "Pages/HomePage.ux";
        temp7.Children.Add(temp8);
        temp7.Children.Add(temp10);
        temp8.Color = Fuse.Drawing.Colors.Red;
        temp8.SourceLineNumber = 11;
        temp8.SourceFileName = "Pages/HomePage.ux";
        global::Fuse.Controls.Grid.SetRow(temp8, 0);
        global::Fuse.Controls.Grid.SetColumn(temp8, 1);
        temp8.Children.Add(temp9);
        temp9.Value = "Uma";
        temp9.FontSize = 12f;
        temp9.Color = Fuse.Drawing.Colors.White;
        temp9.SourceLineNumber = 12;
        temp9.SourceFileName = "Pages/HomePage.ux";
        temp10.Color = Fuse.Drawing.Colors.Blue;
        temp10.SourceLineNumber = 14;
        temp10.SourceFileName = "Pages/HomePage.ux";
        global::Fuse.Controls.Grid.SetRow(temp10, 0);
        global::Fuse.Controls.Grid.SetColumn(temp10, 0);
        temp10.Children.Add(temp11);
        temp11.Value = "Uma";
        temp11.FontSize = 12f;
        temp11.Color = Fuse.Drawing.Colors.White;
        temp11.SourceLineNumber = 14;
        temp11.SourceFileName = "Pages/HomePage.ux";
        this.Children.Add(temp);
    }
}
