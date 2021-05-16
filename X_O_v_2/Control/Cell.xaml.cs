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
using X_O_v_2.View.ViewModel;

namespace X_O_v_2.Control
{
    /// <summary>
    /// Логика взаимодействия для Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        public Cell()
        {
            InitializeComponent();

        }
        private RelayCommand click; 
        public RelayCommand Click
        {
            get { return click ?? (click = new RelayCommand(act => {  })); }
        }
    }
    
}