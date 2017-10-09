using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin1_daza
{
	public partial class GamePage : ContentPage
	{
		GameData gameData;
		Entry MyEntry;
		String randomOp;
		int num1;
		int num2;

		public GamePage(GameData data)
		{
			Title = "GamePage";
			InitializeComponent();
			BindingContext = data;
			gameData = data;

			Random rnd = new Random();
			String[] operations = new String[] { "+", "-" };
			randomOp = operations[rnd.Next(0, 2)];
			num1 = rnd.Next(1, 100);
			num2 = rnd.Next(1, 100);
			String question = (num1 + randomOp + num2);

			Label header = new Label
			{
				Text = question,
				Font = Font.BoldSystemFontOfSize(50),
				HorizontalOptions = LayoutOptions.Center
			};

			MyEntry = new Entry { Placeholder = "Answer", Keyboard = Keyboard.Numeric };

			Button button = new Button
			{
				Text = "Go!",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			button.Clicked += OnButtonClicked;

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					header,
					MyEntry,
					button
				}
			};

		}
		void OnButtonClicked(object sender, EventArgs e)
		{
			// DisplayAlert("Hola", "Click", "ok");
			if (gameData.win > gameData.intents)
			{
				//Siguiente Juego
				if (randomOp == "+")
				{
					if (Int32.Parse(MyEntry.Text) == (num1 + num2))
					{
						Navigation.PushAsync(new GamePage(new GameData(gameData.win, gameData.points + 1, gameData.playerName, gameData.intents + 1)));   //win, points, name, intent
					}
					else
					{
						Navigation.PushAsync(new GamePage(new GameData(gameData.win, gameData.points, gameData.playerName, gameData.intents + 1)));
					}
				}
				else
				{
					if (randomOp == "-")
					{
						if (Int32.Parse(MyEntry.Text) == (num1 - num2))
						{
							Navigation.PushAsync(new GamePage(new GameData(gameData.win, gameData.points + 1, gameData.playerName, gameData.intents + 1)));
						}
						else
						{
							Navigation.PushAsync(new GamePage(new GameData(gameData.win, gameData.points, gameData.playerName, gameData.intents + 1)));   //win, points, name, intent
						}
					}
				}
			}
			else
			{
				Navigation.PushAsync(new MainPage(gameData.points, gameData.win));   //win, points, name, intent
			}
		}
	}
}