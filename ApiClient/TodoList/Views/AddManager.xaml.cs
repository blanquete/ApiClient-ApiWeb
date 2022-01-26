using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoList.Entity;
using TodoList.TascaApi;

namespace TodoList.Views
{
    /// <summary>
    /// Lógica de interacción para AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public TascaApiClient api = new TascaApiClient();
        public AddManager()
        {
            InitializeComponent();
        }
       
        private async void btnAfegirReponsable_Click(object sender, RoutedEventArgs e)
        {
            Responsable responsable = new Responsable();
            if (txtBoxNomResponsable.Text != null)
            {
                responsable.Nom = txtBoxNomResponsable.Text;
                //UserService.afegirResponsable(responsable);
                await api.AfegirResponsable(responsable);
                MessageBox.Show("Has introduït un usuari", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Has de escriure un usuari", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
