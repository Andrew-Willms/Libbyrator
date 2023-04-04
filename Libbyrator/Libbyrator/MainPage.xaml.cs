using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Libbyrator;



public partial class MainPage : ContentPage {

	public string TargetDirectoryPath { get; set; } = "";

	public ObservableCollection<string> Test { get; set; } = new();

	public MainPage() {
		InitializeComponent();
	}

}