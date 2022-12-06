using Game_Store.Helpers;
using Game_Store.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_Store.Windows
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public int x = 0;
        public AddGame()
        {
            InitializeComponent();
            try
            {
                cmboxDeveloper.ItemsSource = DevelopersHelper.GetAllDevelopers();
                cmboxPublisherName.ItemsSource = PublisersHepler.GetAllPublisers();
                cmboxStoreId.ItemsSource = StoresHelper.GetAllStores();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < grid.Children.Count; i++)
            {
                if (grid.Children[i] is StackPanel)
                {
                    for (int i2 = 0; i2 < ((StackPanel)grid.Children[i]).Children.Count; i2++)
                    {
                        if (((StackPanel)grid.Children[i]).Children[i2] is TextBox)
                        {

                            ((TextBox)(((StackPanel)grid.Children[i]).Children[i2])).Text = string.Empty;

                        }
                        else if (((StackPanel)grid.Children[i]).Children[i2] is Label)
                        {
                            ((Label)(((StackPanel)grid.Children[i]).Children[i2])).Content = string.Empty;

                        }
                    }
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Game game = new Game()
            {

                name = txtname.Text,
                genre = txtgenre.Text,
                price = Convert.ToInt32(txtprice.Text),
                release_date = Convert.ToDateTime(txtrelease_date.Text),
                review = Convert.ToInt32(txtreview.Text),
                store_id = ((stores)cmboxStoreId.SelectedValue).store_id,
                publisher = ((publishers)cmboxPublisherName.SelectedValue).publisher_id,
                age_limit = Convert.ToInt32(txtage_limit.Text),
                developer = ((Developer)cmboxDeveloper.SelectedValue).developer_id,
                except_country = txtexcept_country.Text,
                description = txtDescrpition.Text,
                isObtainble = checkisObtainble.IsChecked ?? true,

            };


            if (x == 0)
            {
                if (GamesHelper.AddGame(game) > 0)
                {
                    MessageBox.Show("Add Success");
                    this.Close();
                }
                else MessageBox.Show("Not Add Success");
            }
            else
            {
                game.game_id = Convert.ToInt32(txtGameId.Text);

                if (GamesHelper.UpdateGame(game) > 0)
                {
                    MessageBox.Show("Updated Success");
                    this.Close();

                }
                else MessageBox.Show("Update Not Success", "Update Not Success", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //MainWindow window = new MainWindow();
            //window.Show();
            //this.Close();
            //            this.DialogResult = true;
            //this.Visibility= Visibility.Hidden;




            //for (int i = 0; i < grid.Children.Count; i++)
            //{
            //    if (grid.Children[i] is StackPanel)
            //    {
            //        for (int i2 = 0; i2 < ((StackPanel)grid.Children[i]).Children.Count; i2++)
            //        {
            //            if (((StackPanel)grid.Children[i]).Children[i2] is Label)
            //            {
            //                ((Label)(((StackPanel)grid.Children[i]).Children[i2])).Content = "This Field is Required";
            //            }
            //        }
            //    }
            //}



            //this.Height = 700;


        }

    }
}
//for (int i = 0; i < grid.Children.Count; i++)
//{
//    if (grid.Children[i] is StackPanel)
//    {
//        for (int i2 = 0; i2 < ((StackPanel)grid.Children[i]).Children.Count; i2++)
//        {
//            if (((StackPanel)grid.Children[i]).Children[i2] is Label)
//            {
//                ((Label)(((StackPanel)grid.Children[i]).Children[i2])).Content = "This Field is Required";
//            }
//        }
//    }
//}

