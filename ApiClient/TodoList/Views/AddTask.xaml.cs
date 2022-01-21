using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TodoList.TascaApi;
using TodoList.Entity;
using static TodoList.Entity.Tasca;

namespace TodoList.Views
{
    /// <summary>
    /// Lógica de interacción para AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public Tasca temp;
        public MainWindow w1;
        public TascaApiClient apiClient;
        public  AddTask(MainWindow main)
        {
            InitializeComponent();
            w1 = main;
            apiClient = new TascaApiClient();

            mostrarResponsables();

        }


        public async void mostrarResponsables()
        {
            await apiClient.GetResponsble();
        }
        //Funcio, per poder afegir una tasca
        private async void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            
            //afageix un nou item al listview
            temp = new Tasca()
            {
                _Id = await apiClient.maxId()+1,
                Nom = txt_nomTasca.Text,
                Descripcio = txt_descripcio.Text,
                DInici = DateTime.Now,
                DFinal = (DateTime)datepicker_data_final.SelectedDate,
                Prioritat_name = cmb_prioritat.SelectedItem.ToString(), //Agafa el valor de l'index
                Prioritat_id = cmb_prioritat.SelectedIndex,
                Responsable_id = cmb_responsable.SelectedIndex,
                Responsable_name = cmb_responsable.SelectedItem.ToString(), //Agafa el valor de l'index
                Estat_name = "To do", //Fixem el valor de l'index, una tasca sempre inicia al ToDo
                estat = Estat.Todo, //Fixem el valor de l'index, una tasca sempre inicia al ToDo
            };

            //Des de la pantalla Afegir passem l'objecte al listview de la pagina principal
            w1.todo.Add(temp);

            //Mostrem la tasca nova en el list view
            w1.lvTascaToDo.ItemsSource = null;
            w1.lvTascaToDo.ItemsSource = w1.todo;

            await apiClient.AddAsync(temp);
            netejaCamps();
        }

        private async void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creem un nou item al listview
                Tasca temp = new Tasca()
                {
                    _Id = int.Parse(txt_id.Text),
                    DInici = (DateTime)datepicker_data_inici.SelectedDate,
                    estat = (Estat)int.Parse(txt_estat.Text),

                    Nom = txt_nomTasca.Text,
                    Descripcio = txt_descripcio.Text,
                    DFinal = (DateTime)datepicker_data_final.SelectedDate,
                    Prioritat_id = cmb_prioritat.SelectedIndex,
                    Responsable_id = cmb_responsable.SelectedIndex,
                    Prioritat_name = cmb_prioritat.SelectedItem.ToString(), //transforma el valor del item seleccionat
                    Responsable_name = cmb_responsable.SelectedItem.ToString(), //transforma el valor del item seleccionat
                    Estat_name = "To do"
                };
                //intercanvia l'item seleccionat per el que acabem de crear
                if (w1.lvTascaToDo.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaToDo.SelectedIndex);
                    w1.todo.Insert(w1.lvTascaToDo.SelectedIndex, temp);
                    w1.lvTascaToDo.ItemsSource = null;
                    w1.lvTascaToDo.ItemsSource = w1.todo;
                }
                else if (w1.lvTascaDoing.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDoing.SelectedIndex);
                    w1.doing.Insert(w1.lvTascaDoing.SelectedIndex, temp);
                    w1.lvTascaDoing.ItemsSource = null;
                    w1.lvTascaDoing.ItemsSource = w1.doing;
                }
                else if (w1.lvTascaDone.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDone.SelectedIndex);
                    w1.done.Insert(w1.lvTascaDone.SelectedIndex, temp);
                    w1.lvTascaDone.ItemsSource = null;
                    w1.lvTascaDone.ItemsSource = w1.done;
                }

                await apiClient.UpdateAsync(temp);

                netejaCamps();

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca i omplir tots els camps", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //metode per netejar els camps
        public void netejaCamps()
        {
            txt_nomTasca.Text = "";
            txt_descripcio.Text = "";
            datepicker_data_final.SelectedDate = null;
            cmb_prioritat.SelectedItem = null;
            cmb_responsable.SelectedItem = null;
            txt_id.Text = "";
            txt_estat.Text = "";
            datepicker_data_inici.SelectedDate = null;
            txt_nomTasca.Focus();
        }
    }
}
