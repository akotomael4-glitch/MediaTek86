using MediaTek86.Controleur;
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
    public partial class FrmConnexion : Form
    {
        public FrmConnexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            ResponsableController controller = new ResponsableController();

            bool ok = controller.Connexion(txtLogin.Text, txtPwd.Text);
            if (ok)
            {
                FrmAbsence frm = new FrmAbsence();

                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }
        }
    }
}
