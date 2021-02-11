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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathToolsLibrary;

namespace WPF_First_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //MessageBox.Show(Calculator.Calculate("1 + ( 2 * 2 )").ToString());
            InitializeComponent();
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            currentStr.Text = "";
            return;
        }        

        private void BackspaceButton(object sender, RoutedEventArgs e)
        {
            if (currentStr.Text.Length <= 1)
            { DeleteButton(sender, e); return; }

            if (!Calculator.IsNumber(currentStr.Text.Last().ToString()) || currentStr.Text[currentStr.Text.Length - 2] == ' ')
            {
                currentStr.Text = currentStr.Text.Remove(currentStr.Text.Length - 1);
            }

            currentStr.Text =  currentStr.Text.Remove(currentStr.Text.Length - 1);
        }

        private void WriteElementInTextBox(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;
            

            bool isNumber = Calculator.IsNumber(currentButton.Content.ToString());
            

            if (!isNumber || currentStr.Text.Length > 0 && Calculator.IsOperator(currentStr.Text.Last().ToString(), new string[] { "+", "-", "/", "*", "(", ")" }))                
            {
                currentStr.Text += " ";
            }

            currentStr.Text += currentButton.Content;

            

        }

        private void EqualsButton(object sender, RoutedEventArgs e)
        {
            currentStr.Text = Convert.ToString(Calculator.Calculate(currentStr.Text));
        }        
    }

    


}
