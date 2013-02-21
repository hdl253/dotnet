using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MsdnSilverlightWebApp
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GreetMe_Click(object sender, RoutedEventArgs e)
        {
            Greeting.Text = "Hello " + FirstName.Text + "!";
        }

    }
}
