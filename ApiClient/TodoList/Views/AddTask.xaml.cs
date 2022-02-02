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
        public List<Prioritat> prioritats;
        public List<Responsable> responsables;

        public  AddTask(MainWindow main)
        {
            InitializeComponent();
            w1 = main;
            apiClient = new TascaApiClient();
        }

        public async void mostrarResponsables()
        {
            await apiClient.GetResponsable();
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
                Estat_name = "To Do", //Fixem el valor de l'index, una tasca sempre inicia al ToDo
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
                Tasca temp2 = new Tasca();
               
                temp2.Id = txt_ObjectId.Text;
                temp2._Id = int.Parse(txt_id.Text);
                temp2.DInici = (DateTime)datepicker_data_inici.SelectedDate;
                temp2.estat = (Estat)int.Parse(txt_estat.Text);

                temp2.Nom = txt_nomTasca.Text;
                temp2.Descripcio = txt_descripcio.Text;
                temp2.DFinal = (DateTime)datepicker_data_final.SelectedDate;
                temp2.Prioritat_id = cmb_prioritat.SelectedIndex;
                temp2.Responsable_id = cmb_responsable.SelectedIndex;
                temp2.Prioritat_name = cmb_prioritat.SelectedItem.ToString(); //transforma el valor del item seleccionat
                temp2.Responsable_name = cmb_responsable.SelectedItem.ToString(); //transforma el valor del item seleccionat
                temp2.Estat_name = "To do";
               


                //intercanvia l'item seleccionat per el que acabem de crear
                if (w1.lvTascaToDo.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaToDo.SelectedIndex);
                    w1.todo.Insert(w1.lvTascaToDo.SelectedIndex, temp2);
                    w1.lvTascaToDo.ItemsSource = null;
                    w1.lvTascaToDo.ItemsSource = w1.todo;
                }
                else if (w1.lvTascaDoing.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDoing.SelectedIndex);
                    w1.doing.Insert(w1.lvTascaDoing.SelectedIndex, temp2);
                    w1.lvTascaDoing.ItemsSource = null;
                    w1.lvTascaDoing.ItemsSource = w1.doing;
                }
                else if (w1.lvTascaDone.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDone.SelectedIndex);
                    w1.done.Insert(w1.lvTascaDone.SelectedIndex, temp2);
                    w1.lvTascaDone.ItemsSource = null;
                    w1.lvTascaDone.ItemsSource = w1.done;
                }

                await apiClient.UpdateAsync(temp2);

                netejaCamps();

                w1.updateListViews();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Has de seleccionar una tasca i omplir tots els camps\n\n\n" + ex.Message + "\n\n\n" + ex.Source + "\n\n\n" + ex.StackTrace + "\n\n\n" + ex.HelpLink+ "\n\n\n" + ex.Data, "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            responsables = await apiClient.GetResponsable();
            foreach (Responsable resp in responsables)
            {
                cmb_responsable.Items.Add(resp.Nom);
            }
            prioritats = await apiClient.GetPrioritats();

             foreach (Prioritat prio in prioritats)
             {
                 cmb_prioritat.Items.Add(prio.Nom);
             }
        }
    }
}
