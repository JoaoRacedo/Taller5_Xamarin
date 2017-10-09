using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace App1
{
    public partial class SecondPage : ContentPage
    {
        Data info;
        String randOP;
        Entry entry;
        int number1;
        int number2;

        public SecondPage(Data data)
        {
            Title = "Game Page";
            InitializeComponent();
            BindingContext = data;
            info = data;

            Random random = new Random();
            String[] operations = new String[] { "+", "-" };
            randOP = operations[random.Next(0, 2)];
            number1 = random.Next(1, 100);
            number2 = random.Next(1, 100);

            String Op = (number1 + randOP + number2);

            Label head = new Label { Text = Op, Font = Font.BoldSystemFontOfSize(50), HorizontalOptions = LayoutOptions.Center };
            entry = new Entry { Placeholder = "Answer", Keyboard = Keyboard.Numeric };
            Button boton = new Button { Text = "start", Font = Font.SystemFontOfSize(NamedSize.Large), BorderWidth = 1, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            boton.Clicked += ElEventoClick;


            this.Content = new StackLayout
            {
                Children =
                {
                    head,
                    entry,
                    boton
                }
            };
        }

        void ElEventoClick(object sender, EventArgs e)
        {
            if (info.index > info.state)
            {
                if (randOP == "-")
                {
                    if (Int32.Parse(entry.Text) == (number1 - number2))
                    {
                        Navigation.PushAsync(new SecondPage(new Data(info.name, info.score + 1, info.index, info.state + 1)));
                    }
                    else
                    {
                        Navigation.PushAsync(new SecondPage(new Data(info.name, info.score, info.index, info.state + 1)));
                    }

                }
                else
                {
                    if (randOP == "+")
                    {
                        if (Int32.Parse(entry.Text) == (number1 + number2))
                        {
                            Navigation.PushAsync(new SecondPage(new Data(info.name, info.score + 1, info.index, info.state + 1)));
                        }
                        else
                        {
                            Navigation.PushAsync(new SecondPage(new Data(info.name, info.score, info.index, info.state + 1)));
                        }
                    }

                }

			}else{
				Navigation.PushAsync(new MainPage(info.score, info.index));  
			}


        }
    }
}
