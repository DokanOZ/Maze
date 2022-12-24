using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maze
{
    /// <summary>
    /// Interaction logic for TrapWindow.xaml
    /// </summary>
    public partial class TrapWindow : Window
    {
        public TrapWindow(string trap)
        {
            InitializeComponent();

            switch (trap)
            {
                case "Caesar Cipher":
                    CaesarCipherGame();
                    break;
            }
        }

        private void CaesarCipherGame()
        {
            string sentence = "Test";

            GridTrapWindow.RowDefinitions.Add(new RowDefinition());
            GridTrapWindow.RowDefinitions.Add(new RowDefinition());
            GridTrapWindow.RowDefinitions.Add(new RowDefinition());
            GridTrapWindow.ColumnDefinitions.Add(new ColumnDefinition());
            GridTrapWindow.ColumnDefinitions.Add(new ColumnDefinition());
            GridTrapWindow.ColumnDefinitions.Add(new ColumnDefinition());

            Label titleLabel = new Label();
            titleLabel.Content = "Crack the Ceasar Cipher";
            titleLabel.FontSize = 50;
            titleLabel.HorizontalAlignment = HorizontalAlignment.Center;
            titleLabel.VerticalAlignment = VerticalAlignment.Center;

            Label gameLabel = new Label();
            gameLabel.Content = Cipher.CaesarEncoder(sentence, 1);
            gameLabel.FontSize = 40;
            gameLabel.HorizontalAlignment = HorizontalAlignment.Center;
            gameLabel.VerticalAlignment = VerticalAlignment.Center;


            TextBox answerBox = new TextBox();
            answerBox.Text = "Type here";
            answerBox.Background = new SolidColorBrush(Colors.Green);
            answerBox.HorizontalAlignment = HorizontalAlignment.Center;
            answerBox.VerticalAlignment = VerticalAlignment.Center;
            answerBox.FontSize = 40;
            

            Button answerButton = new Button();
            answerButton.Content = "Answer";
            answerButton.Height = 25;
            answerButton.Width = 80;
            answerButton.HorizontalAlignment = HorizontalAlignment.Center;
            answerButton.VerticalAlignment = VerticalAlignment.Center;
            answerButton.Background = new SolidColorBrush(Colors.Aquamarine);
            answerButton.Click += new RoutedEventHandler((sender, e) => btnCaesar_Click(sender, e, answerBox.Text, sentence));

            Grid.SetRow(titleLabel, 0);
            Grid.SetColumnSpan(titleLabel, 3);

            Grid.SetRow(gameLabel, 1);
            Grid.SetColumn(gameLabel, 0);

            Grid.SetRow(answerBox, 1);
            Grid.SetColumn(answerBox, 1);

            Grid.SetRow(answerButton, 1);
            Grid.SetColumn(answerButton, 2);

            GridTrapWindow.Children.Add(titleLabel);
            GridTrapWindow.Children.Add(gameLabel);
            GridTrapWindow.Children.Add(answerBox);
            GridTrapWindow.Children.Add(answerButton);
        }

        private void btnCaesar_Click(object? sender, EventArgs e, string input, string answer)
        {
            if (input == answer)
            {
                this.Close();
            }
        }
    }
}
