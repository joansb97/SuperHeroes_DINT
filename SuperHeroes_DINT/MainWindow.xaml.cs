using System;
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

namespace SuperHeroes_DINT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Superheroe superheroe;
        List<Superheroe> superheroes;
        int numero;
        public MainWindow()
        {
            InitializeComponent();
            numero = 0;
            superheroes = Superheroe.GetSamples();
            Actualiza(superheroes[numero]);
            superheroe = new Superheroe();
            nuevoSuperheroeGrid.DataContext = superheroe;
        }
        private void retrocederheroe_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if(numero >= 1)
            {
                numero--;
                Actualiza(superheroes[numero]);
            }
        }
        private void avanzarheroe_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if(numero < superheroes.Count - 1)
            {
                numero++;
                Actualiza(superheroes[numero]);
            }
        }
        private void Actualiza(Superheroe aux)
        {

            verSuperHeroe.DataContext = aux;
            contadorTextBlock.Text = (numero + 1).ToString() + "/" + superheroes.Count.ToString();

            if (aux.Heroe)
            {
                if (aux.Vengador) avengersImage.Visibility = Visibility.Visible;
                else if(!aux.Vengador) avengersImage.Visibility = Visibility.Hidden;
                if (aux.Xmen) xMenImage.Visibility = Visibility.Visible;
                else if(!aux.Xmen) xMenImage.Visibility = Visibility.Hidden;
            }
            else
            {
                avengersImage.Visibility = Visibility.Hidden;
                xMenImage.Visibility = Visibility.Hidden;
            }

        }
        private void aceptarButton_Click(object sender,RoutedEventArgs e)
        {
            Superheroe aux = superheroe;
            superheroes.Add(aux);
            MessageBox.Show("Superheroe insertado con exito");
            Limpiar();
        }
        private void limpiarButton_Click(object sender,RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            nombreTextBox.Clear();
            imagenTextBox.Clear();
            heroeRadioButton.IsChecked = true;
            villanoRadioButton.IsChecked = false;
            vengadoresCheckbox.IsChecked = false;
            xMenCheckBox.IsChecked = false;
        }

    }
}
