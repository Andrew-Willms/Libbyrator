using Microsoft.Maui.Controls;

namespace Libbyrator;



public partial class App : Application {
	
	public App() {

		InitializeComponent();
		MainPage = new AppShell();
	}

}