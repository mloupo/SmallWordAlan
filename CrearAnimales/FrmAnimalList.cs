using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CrearAnimales.BusinessLogicLayer;
using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;

namespace CrearAnimales.PresentationLayer
{
    public partial class FrmAnimalList : Form
    {
        private FrmAnimalCreated frm;
        public FrmAnimalList()
        {
            InitializeComponent();
            frm = new FrmAnimalCreated();
            frm.FormClosed += FrmAnimalCreated_FormClosed;
        }

        private void FrmAnimalCreated_FormClosed(object sender, FormClosedEventArgs e)
        {
            LlenarDgvAnimals();
        }

        private void FrmAnimalList_Load(object sender, EventArgs e)
        {
            LlenarDgvAnimals();
        }

        private void LlenarDgvAnimals()
        {
            List<Animal> animales = AnimalBLL.GetAllAnimals().ToList(); // Obtenemos la lista de animales
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.Rows.Clear(); // Limpiamos las filas que tenga el DGV
            foreach (Animal animal in animales)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dgvAnimals); // Vamos creando las celdas en el DGV
                // Asignar los valores a cada celda de la fila usando el nombre de la columna
                fila.Cells[0].Value = animal.Id;
                fila.Cells[1].Value = animal.Especie;
                fila.Cells[2].Value = animal.Age;
                fila.Cells[3].Value = animal.Weight;
                fila.Cells[4].Value = animal.Diet;
                fila.Cells[5].Value = animal.Enviroment;
                fila.Cells[6].Value = "X: " + animal.PositionX + "  " + "Y: " + animal.PositionY;
                dgvAnimals.Rows.Add(fila); // Generamos una nueva fila con datos para el DGV
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            frm.ShowDialog();
        }

    }
}
