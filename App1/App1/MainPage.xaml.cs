using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : ContentPage
	{

        public MainPage(int stuff,int sta)
		{
			Title = "Main";
			InitializeComponent();

        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
            String name = NameEntry.Text;
            int[] operations = new int[] { 3, 5, 10 };
            int index = operations[NumPicker.SelectedIndex];
            Navigation.PushAsync(new SecondPage(new Data(name,0,index,1)));
		}
    }
}
