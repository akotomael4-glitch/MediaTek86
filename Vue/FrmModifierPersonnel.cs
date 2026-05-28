using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.Modele;
using MediaTek86.Controleur;
using System.Drawing.Text;
namespace MediaTek86.Vue
{
    public partial class FrmModifierPersonnel : Form
    {
        private PersonnelController personnelController = new PersonnelController();
        private Personnel personnel;


        public FrmModifierPersonnel(Personnel p)
        {
            InitializeComponent();
            personnel = p;
            
            txtNom.Text = personnel.Nom;
            txtPrenom.Text = personnel.Prenom;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtPrenom.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return;
            }
            personnel.Nom = txtNom.Text;
            personnel.Prenom = txtPrenom.Text;
            personnel.IdService = 1;

            personnelController.ModifierPersonnel(personnel);

            MessageBox.Show("Personnel modifié avec succès");

            this.Close();
        }
    }
}
