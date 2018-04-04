using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public Persoon persoon = new Persoon("Jan",3500m,new DateTime(2011,2,13));
        public DataBindingWindow()
        {
            InitializeComponent();
            SortDescription sd = new SortDescription("Source",
                ListSortDirection.Ascending);
            lettertypeComboBox.Items.SortDescriptions.Add(sd);
            lettertypeComboBox.SelectedItem = new FontFamily("Arial");
            veranderPanel.DataContext = persoon;
        }

        public class Persoon : INotifyPropertyChanged
        {
            private string naamValue;
            public string Naam {
                get
                {
                    return naamValue;
                }
                set
                {
                    naamValue = value;
                    RaisePropertyChanged("Naam");
                }
                }

            private decimal weddeValue;

            public decimal Wedde
            {
                get { return weddeValue; }
                set
                {
                    weddeValue = value;
                    RaisePropertyChanged("Wedde");
                }
            }
            private DateTime inDienstValue;

            public DateTime InDienst
            {
                get { return inDienstValue; }
                set
                {
                    inDienstValue = value;
                    RaisePropertyChanged("InDienst");
                }

            }
            public Persoon(string nNaam, decimal nWedde, DateTime nInDienst)
            {
                Naam = nNaam;
                Wedde = nWedde;
                InDienst = nInDienst;
            }

            private void RaisePropertyChanged(string info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        private void toonNaamButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(persoon.Naam);
        }

        private void veranderButton_Click(object sender, RoutedEventArgs e)
        {
            persoon.Naam = "piet";
            persoon.Wedde = 4125.5m;
            persoon.InDienst = new DateTime(2010, 12, 21);
        }
    }
}
