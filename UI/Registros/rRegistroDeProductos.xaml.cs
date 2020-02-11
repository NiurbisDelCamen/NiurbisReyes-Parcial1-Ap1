using Parcial1_Niurbis.BLL;
using Parcial1_Niurbis.Entidades;
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

namespace Parcial1_Niurbis.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRegistroDeProductos.xaml
    /// </summary>
    public partial class rRegistroDeProductos : Window
    {
        public rRegistroDeProductos()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorInventarioTextBox.Text = string.Empty;
        }

        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();
            if (string.IsNullOrWhiteSpace(ProductoIdTextBox.Text))
            {
                ProductoIdTextBox.Text = "0";
            }
            else
                articulos.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulos.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulos.ValorInventario = Convert.ToInt32(ValorInventarioTextBox.Text);
            return articulos;
        }

        private void LlenaCampo(Articulos articulos)
        {
            ProductoIdTextBox.Text = Convert.ToString(articulos.ProductoId);
            DescripcionTextBox.Text = articulos.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValorInventarioTextBox.Text = Convert.ToString(articulos.ValorInventario);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos articulo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (articulo!= null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show(DescripcionTextBox.Text, "El Campo Descripcion no puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }
                if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show(ExistenciaTextBox.Text, "El Campo Existencia no puede estar vacio");
                ExistenciaTextBox.Focus();
                paso = false;
            }
                if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show(CostoTextBox.Text, "El campo Costo no puede estar vacio");
                CostoTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos;
            bool paso = false;
            if (!Validar())
                return;
            articulos = LlenaClase();

            if ((string.IsNullOrWhiteSpace(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0"))
                paso = ArticulosBLL.Guardar(articulos);

                else
                {
                    if(!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No se puede modificar una persona que no existe","Fallo",MessageBoxButton.OK,MessageBoxImage.Error);
                        return;
                    }
                    paso = ArticulosBLL.Modificar(articulos);
                    if(paso)
                    {
                        Limpiar();
                        MessageBox.Show("Guardado","Exito",MessageBoxButton.OK,MessageBoxImage.Information) ;
                    }
                    else
                    {
                        MessageBox.Show("No fue posible Guardar","Fallo",MessageBoxButton.OK,MessageBoxImage.Error);
                    }

                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clear");
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);
            Limpiar();
            if (ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado","Exito",MessageBoxButton.OK,MessageBoxImage.Information);
            else
            {
                MessageBox.Show(ProductoIdTextBox.Text,"No se puede Eliminar un Articulo que no existe");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Articulos articulos = new Articulos();
            int.TryParse(ProductoIdTextBox.Text, out id);
               Limpiar();
            articulos = ArticulosBLL.Buscar(id)
                if(articulos!=null)
            {
                MessageBox.Show("Articulo Encontrado");
                LlenaCampo(articulos);
            }
                else
            {
                MessageBox.Show("Artiuclo No Encontrado");
            }

        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
