using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;
using CrearAnimales.EntitiesLayer.ConcretClass.DietTypes;
using CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Enviroment;
using CrearAnimales.EntitiesLayer.Interfaces;

namespace CrearAnimales.PresentationLayer
{
    public partial class FrmAnimalCreated : Form
    {
        private ValidadorAnimalModel _animalModel = new ValidadorAnimalModel();
        public FrmAnimalCreated()
        {
            InitializeComponent();
        }

        private void FrmAnimalCreated_Load(object sender, EventArgs e)
        {
            CargarCmBox();
        }
        private void CargarCmBox()
        {
            // Dietas
            cmDieta.Items.Clear();
            cmDieta.Text = "Seleccione una opción";
            cmDieta.Items.Add(new Carnivoro());
            cmDieta.Items.Add(new Herbivoro());
            cmDieta.Items.Add(new Omnivoro());
            // Habitats
            cmHabitat.Items.Clear();
            cmHabitat.Text = "Seleccione una opción";
            cmHabitat.Items.Add(new Aerial());
            cmHabitat.Items.Add(new City());
            cmHabitat.Items.Add(new Desert());
            cmHabitat.Items.Add(new Forest());
            cmHabitat.Items.Add(new Mountain());
            cmHabitat.Items.Add(new Ocean());
            cmHabitat.Items.Add(new Sheet());
            cmHabitat.Items.Add(new Underground());
        }
        private void CrearAnimal()
        {
            var animal = new Animal();
            animal.Especie = txtEspecie.Text;
            animal.Age = Convert.ToInt32(txtEdad.Text);
            animal.Weight = Convert.ToInt32(txtPeso.Text);
            animal.Diet = cmDieta.SelectedItem as IDiet;
            animal.Enviroment = cmHabitat.SelectedItem as IEnviroment;

            // Validar el modelo
            List<ValidationResult> resultadosValidacion = _animalModel.ValidarObjeto(animal); // Invocar el método Validar en la instancia de Animal

            if (resultadosValidacion.Count > 0)
            {
                // Mostrar mensajes de error uno por uno
                foreach (var resultado in resultadosValidacion)
                {
                    MessageBox.Show(resultado.ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Los datos son válidos, realizar acciones adicionales
                MessageBox.Show("Animal guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*private void CrearAnimal()
        {
            var animal = new Animal();
            animal.Especie = txtEspecie.Text;
            animal.Age = Convert.ToInt32(txtEdad.Text);
            animal.Weight = Convert.ToInt32(txtPeso.Text);
            animal.Diet = cmDieta.SelectedItem as IDiet;
            animal.Enviroment = cmHabitat.SelectedItem as IEnviroment;
            // Validar el modelo
            List<ValidationResult> resultadosValidacion = _animalModel.ValidarObjeto(animal);
            if (resultadosValidacion.Count > 0)
            {
                // Mostrar mensajes de error uno por uno
                foreach (var resultado in resultadosValidacion)
                {
                    MessageBox.Show(resultado.ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            else
            {
                // Los datos son válidos, realizar acciones adicionales
                MessageBox.Show("Usuario guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearAnimal();
            this.Close();
            LimpiarComponentes();
        }

        public void FrmAnimalCreated_FormClosed(object sender, FormClosedEventArgs e){ }

        #region VisualComponents
        private void LimpiarComponentes()
        {
            txtEdad.Clear();
            txtEspecie.Clear();
            txtPeso.Clear();
            CargarCmBox();
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
        }
    }
}
