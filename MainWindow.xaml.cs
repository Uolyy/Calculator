using System;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string output = "";
        double temp = 0;
        string oper = "";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            //string str = (string)((Button)e.OriginalSource).Content;
            string name = ((Button)sender).Name;

            

            switch (name)
            {
                case "One":
                    output += "1";
                    TextBlock.Text = output;
                    break;

                case "Two":
                    output += "2";
                    TextBlock.Text = output;
                    break;

                case "Three":
                    output += "3";
                    TextBlock.Text = output;
                    break;

                case "Four":
                    output += "4";
                    TextBlock.Text = output;
                    break;

                case "Five":
                    output += "5";
                    TextBlock.Text = output;
                    break;

                case "Six":
                    output += "6";
                    TextBlock.Text = output;
                    break;

                case "Seven":
                    output += "7";
                    TextBlock.Text = output;
                    break;

                case "Eight":
                    output += "8";
                    TextBlock.Text = output;
                    break;

                case "Nine":
                    output += "9";
                    TextBlock.Text = output;
                    break;

                case "Zero":
                    if ( output == "")
                    {
                        output += "0" + ",";
                        TextBlock.Text = output;
                        break;
                    }

                    else
                    {
                        output += "0";
                        TextBlock.Text = output;
                        break;
                    }
                    

                case "Point":
                    if (!output.Contains(","))
                    {
                        output += ",";
                        TextBlock.Text = output;                        
                    }
                    break;
            }

        }

        //..................................................................................//

        private void MinusButton_Click (object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";

                oper = "Minus";
            }

        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (output != "" & output != "-")
            {
                temp = double.Parse(output);
                output = "";

                oper = "Plus";
            }
        }

        private void MultiButton_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";

                oper = "Multi";
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";

                oper = "Divide";
            }
        }

        private void PersentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(output))
            {
                double persent = double.Parse(output);
                persent = persent * 0.01;
                output = persent.ToString();
                TextBlock.Text = output;
            }
        }

        //..................................................................................//

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            TextBlock.Text = output;
        }


        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (output.Length > 0)
            {
                output = output.Substring(0, output.Length - 1);
                TextBlock.Text = output;
            }
        }


        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            int lastOper = output.LastIndexOfAny(new char[] { '+', '-', '*', '/' });

            if (lastOper != -1)
            {
                output = output.Remove(lastOper + 1);
                TextBlock.Text = output;
            }
            else
            {
                output = "";
                TextBlock.Text = output;
            }
        }

        //..................................................................................//

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            double square = double.Parse(output);

            output = (square * square).ToString();
            TextBlock.Text = output;
        }


        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                double sqrt = double.Parse(output);

                output = Math.Sqrt(sqrt).ToString();
                TextBlock.Text = output;
            }
        }


        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            double sign = double.Parse(output);

            output = (sign * (-1)).ToString();
            TextBlock.Text = output;
        }


        private void FracButton_Click(object sender, RoutedEventArgs e)
        {
            if (output != "" & output != "0")
            {
                double frac = double.Parse(output);

                output = (1/frac).ToString();
                TextBlock.Text = output;
            }
        }


        //..................................................................................//

        private void EqualButton_Click (object sender, RoutedEventArgs e)
        {
            double outputTemp;
            switch (oper)
            {
                case "Minus":
                    if (!string.IsNullOrEmpty(output))
                    {
                        outputTemp = temp - double.Parse(output);
                        output = outputTemp.ToString();
                        TextBlock.Text = output;
                    }
                    break;

                case "Plus":
                    if (!string.IsNullOrEmpty(output))
                    {
                        outputTemp = temp + double.Parse(output);
                        output = outputTemp.ToString();
                        TextBlock.Text = output;
                    }
                    break;

                case "Multi":
                    if (!string.IsNullOrEmpty(output))
                    {
                        outputTemp = temp * double.Parse(output);
                        output = outputTemp.ToString();
                        TextBlock.Text = output;
                    }                      
                    break;

                case "Divide":
                    if (!string.IsNullOrEmpty(output) && double.Parse(output) != 0)
                    {
                        outputTemp = temp / double.Parse(output);
                        output = outputTemp.ToString();
                        TextBlock.Text = output;
                    }

                    break;                   
            }

        }


        //..................................................................................//
        double memory = 0;
        string memoryTemp = "";

        private void MPlusButton_Click(object sender, RoutedEventArgs e)
        {
            // Добавленме текущего значения output к значению в памяти
            double currentValue = 0;
            if (double.TryParse(output, out currentValue))
            {
                memory += currentValue;
                memoryTemp = memory.ToString();
            }
        }

        private void MMinusButton_Click(object sender, RoutedEventArgs e)
        {
            // Вычитание текущего значения output из значения в памяти
            double currentValue = 0;
            if (double.TryParse(output, out currentValue))
            {
                memory -= currentValue;
                memoryTemp = memory.ToString();
            }
        }

        private void MSButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение текущего значения output в памяти
            memory = double.Parse(output);
            memoryTemp = memory.ToString();
        }


        private void MCButton_Click(object sender, RoutedEventArgs e)
        {
            // Очистка значения в памяти
            memory = 0;
            memoryTemp = "";
        }

        private void MRButton_Click(object sender, RoutedEventArgs e)
        {
            // Запись значения из памяти в output
            output = memoryTemp;
            TextBlock.Text = output;
        }


    }
}
