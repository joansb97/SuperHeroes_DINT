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
        List<Superheroe> superheroes;
        int numero;
        public MainWindow()
        {
            InitializeComponent();
            numero = 0;
            superheroes = Superheroe.GetSamples();
            Actualiza(superheroes[numero]);
        }
        private void retrocederheroe_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if(numero > 1)
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
                verSuperHeroe.Background = Brushes.PaleGreen;
                if (aux.Vengador) avengersImage.Visibility = Visibility.Visible;
                if (aux.Xmen) xMenImage.Visibility = Visibility.Visible;
            }
            else verSuperHeroe.Background = Brushes.IndianRed;

        }
        private void aceptarButton_Click(object sender,RoutedEventArgs e)
        {
            string nombre = nombreTextBox.Text;
            string imagen = imagenTextBox.Text;
            bool vengador;
            bool xmen;
            bool heroe;
            bool villano;
            if (heroeRadioButton.IsChecked == false)
            {
                heroe = false;
                vengador = false;
                xmen = false;
                villano = true;
            }
            else
            {
                heroe = true;
                villano = false;

                if (vengadoresCheckbox.IsChecked == true) vengador = true;
                else vengador = false;

                if (xMenCheckBox.IsChecked == true) xmen = true;
                else xmen = false;
            }
            Superheroe aux = new Superheroe(nombre,imagen,vengador,xmen,heroe,villano);
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
            nombreTextBox.Text = "";
            imagenTextBox.Text = "";
            heroeRadioButton.IsChecked = true;
            villanoRadioButton.IsChecked = false;
            vengadoresCheckbox.IsChecked = false;
            xMenCheckBox.IsChecked = false;
        }

    }
}
