using MediaTek86.Controleur;
using MediaTek86.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86.Vue
{
    public partial class FrmPersonnel : Form
    {
        public FrmPersonnel()
        {
            InitializeComponent();
        }

        private PersonnelController controller = new PersonnelController();

        private void FrmPersonnel_Load(object sender, EventArgs e)
            
        {
            dataGridView1.DataSource = controller.GetAllPersonnel();

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["Nom"].HeaderText = "Nom";
            dataGridView1.Columns["Prenom"].HeaderText = "Prenom";
            dataGridView1.Columns["Service"].HeaderText = "Service";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows= false;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutPersonnel frm = new FrmAjoutPersonnel();
            frm.ShowDialog();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = controller.GetAllPersonnel();
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Personnel p = new Personnel();

                p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                p.Nom = dataGridView1.CurrentRow.Cells["Nom"].Value.ToString();

                p.Prenom = dataGridView1.CurrentRow.Cells["Prenom"].Value.ToString();

                p.IdService = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdService"].Value);

                FrmModifierPersonnel frm = new FrmModifierPersonnel(p);

                frm.ShowDialog();
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = controller.GetAllPersonnel();
            }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show(
                "Voulez-vous vraiment supprimer ?",
                "Confirmation",
                MessageBoxButtons.YesNo);

            if (resultat == DialogResult.Yes)
            {
                return;
            }
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                controller.SupprimerPersonnel(id);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = controller.GetAllPersonnel();
                MessageBox.Show("Personnel supprimé");
            }
        }
    }
}


