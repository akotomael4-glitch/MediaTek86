using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.Controleur;
using MediaTek86.Modele;

namespace MediaTek86.Vue
{
    public partial class FrmAjoutPersonnel : Form
    {
        private PersonnelController controller = new PersonnelController();
        private ServiceController serviceController = new ServiceController();
        public FrmAjoutPersonnel()
        {
            InitializeComponent();
            cbxService.DataSource = serviceController.GetAllServices();

            cbxService.DisplayMember = "Nom";
            cbxService.ValueMember = "Id";
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtPrenom.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return;
            }
            Personnel p = new Personnel();

            p.Nom = txtNom.Text;
            p.Prenom = txtPrenom.Text;

            p.IdService = Convert.ToInt32(cbxService.SelectedValue);

            controller.AjouterPersonnel(p);

            MessageBox.Show("Personnel ajouté");

            this.Close();

        }

        private void cbxService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
