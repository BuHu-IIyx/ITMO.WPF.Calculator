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


namespace MyWindowsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalcUI : Window
    {
       
        /// Required designer variable.
		
		//private System.ComponentModel.Container components = null;

       
        public CalcUI()
        {
            InitializeComponent();
			foreach(UIElement c in NumPad.Children)
            {
				((Button)c).Click += Button_Click;
            }
        }

		private void Button_Click(object sender, RoutedEventArgs e)
        {
			string ButtonName = (string)((Button)e.OriginalSource).Content;
			
			switch (ButtonName)
            {
				case "-/+":
					OutputDisplay.Text = CalcEngine.CalcSign();
					break;
				case ".":
					OutputDisplay.Text = CalcEngine.CalcDecimal();
					break;
				case "+":
					CalcEngine.CalcOperation(CalcEngine.Operator.eAdd);
					break;
				case "-":
					CalcEngine.CalcOperation(CalcEngine.Operator.eSubtract);
					break;
				case "x":
					CalcEngine.CalcOperation(CalcEngine.Operator.eMultiply);
					break;
				case "/":
					CalcEngine.CalcOperation(CalcEngine.Operator.eDivide);
					break;
				case "Date":
					OutputDisplay.Text = CalcEngine.GetDate();
					CalcEngine.CalcReset();
					break;
				case "C":
					CalcEngine.CalcReset();
					OutputDisplay.Text = "0";
					break;
				case "=":
					OutputDisplay.Text = CalcEngine.CalcEqual();
					CalcEngine.CalcReset();
					break;
				case "Exit":
					this.Close();
					break;
				default:
					OutputDisplay.Text = CalcEngine.CalcNumber(ButtonName);
					break;
			}

        }
    }
}
