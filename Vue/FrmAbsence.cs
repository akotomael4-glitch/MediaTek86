using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.Controleur;
using MediaTek86.Modele;
namespace MediaTek86.Vue
{
    public partial class FrmAbsence : Form
    {
        private AbsenceController controller = new AbsenceController();
        public FrmAbsence()
        {
            InitializeComponent();
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            dataGridViewAbsences.DataSource = controller.GetAllAbsences();

            dataGridViewAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAbsences.MultiSelect = false;
            dataGridViewAbsences.ReadOnly = true;
            dataGridViewAbsences.RowHeadersVisible = false;
            dataGridViewAbsences.AllowUserToAddRows = false;

        }
        private void FrmAbsence_Load(object sender, EventArgs e)
        {
            dataGridViewAbsences.DataSource = controller.GetAllAbsences();

            dataGridViewAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAbsences.MultiSelect = false;
            dataGridViewAbsences.ReadOnly = true;
            dataGridViewAbsences.RowHeadersVisible = false;
            dataGridViewAbsences.AllowUserToAddRows = false;

            dataGridViewAbsences.Columns["Id"].Visible = false;
            dataGridViewAbsences.Columns["IdPersonnel"].Visible = false;
            dataGridViewAbsences.Columns["IdMotif"].Visible = false;

            dataGridViewAbsences.Columns["DateDebut"].HeaderText = "Date début";
            dataGridViewAbsences.Columns["DateFin"].HeaderText = "Date fin";
            dataGridViewAbsences.Columns["Personnel"].HeaderText = "Personnel";
            dataGridViewAbsences.Columns["Motif"].HeaderText = "Motif";


        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewAbsences.CurrentRow != null)
            {
                DialogResult resultat = MessageBox.Show(
                "Voulez-vous vraiment supprimer cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultat != DialogResult.Yes)
                {
                    return;
                }

                int id = Convert.ToInt32(dataGridViewAbsences.CurrentRow.Cells["Id"].Value);

                controller.SupprimerAbsence(id);

                ChargerAbsences();

                MessageBox.Show("Absence supprimée");
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutAbsence frm = new FrmAjoutAbsence();

            frm.ShowDialog();

            ChargerAbsences();
        }
        private void ChargerAbsences()
        {
            dataGridViewAbsences.DataSource = null;
            dataGridViewAbsences.DataSource = controller.GetAllAbsences();

            dataGridViewAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAbsences.AllowUserToAddRows = false;
            dataGridViewAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAbsences.MultiSelect = false;

            dataGridViewAbsences.Columns["Id"].Visible = false;
            dataGridViewAbsences.Columns["IdPersonnel"].Visible = false;
            dataGridViewAbsences.Columns["IdMotif"].Visible = false;

            dataGridViewAbsences.Columns["DateDebut"].HeaderText = "Date début";
            dataGridViewAbsences.Columns["DateFin"].HeaderText = "Date fin";
            dataGridViewAbsences.Columns["Personnel"].HeaderText = "Personnel";
            dataGridViewAbsences.Columns["Motif"].HeaderText = "Motif";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridViewAbsences.CurrentRow != null)
            {
                Absence absence = (Absence)dataGridViewAbsences.CurrentRow.DataBoundItem;

                FrmAjoutAbsence frm = new FrmAjoutAbsence(absence);

                frm.ShowDialog();

                ChargerAbsences();


            }
        }
    }
}

