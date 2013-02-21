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

namespace HaoSLTest
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBlock1.Text += "你再点我试试！！";
        }

        private void textBlock1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.textBlock1.Text += "你敢点我";
        }

        private void textBlock1_KeyUp(object sender, KeyEventArgs e)
        {
            textBlock1.Text = "你敢敲键盘"+e.Key.ToString()+":"+e.OriginalSource+":"+e.PlatformKeyCode;
        }

        private void LayoutRoot_KeyUp(object sender, KeyEventArgs e)
        {
            this.textBlock1.Text += "你还敢敲键盘" + e.Key.ToString() + ":" + e.OriginalSource + ":" + e.PlatformKeyCode;
        }
    }
}
