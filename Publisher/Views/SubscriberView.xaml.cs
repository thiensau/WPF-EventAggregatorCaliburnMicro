﻿using System;
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

namespace Publisher.Views
{
    /// <summary>
    /// Interaction logic for SubscriberView.xaml
    /// </summary>
    public partial class SubscriberView : Window
    {
        public SubscriberView()
        {
            InitializeComponent();

            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
