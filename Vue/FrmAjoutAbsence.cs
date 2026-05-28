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
    public partial class FrmAjoutAbsence : Form
    {
        private PersonnelController personnelController = new PersonnelController();
        private MotifController motifController = new MotifController();
        private AbsenceController controller = new AbsenceController();
        private Absence editingAbsence = null;

        public FrmAjoutAbsence()
        {
            InitializeComponent();
        }

        // Added constructor to support editing an existing Absence
        public FrmAjoutAbsence(Absence absence)
        {
            InitializeComponent();
            editingAbsence = absence;
        }

        private void FrmAjoutAbsence_Load(object sender, EventArgs e)
        {
            cboPersonnel.DataSource = personnelController.GetAllPersonnel();
            cboPersonnel.DisplayMember = "Nom";

            cboMotif.DataSource = motifController.GetAllMotifs();
            cboMotif.DisplayMember = "Libelle";

            // If editing an existing absence, pre-select values
            if (editingAbsence != null)
            {
                // Select personnel by Id
                var personnels = cboPersonnel.DataSource as List<Personnel>;
                if (personnels != null)
                {
                    var selPers = personnels.FirstOrDefault(p => p.Id == editingAbsence.IdPersonnel);
                    if (selPers != null) cboPersonnel.SelectedItem = selPers;
                }

                // Select motif by Id
                var motifs = cboMotif.DataSource as List<Motif>;
                if (motifs != null)
                {
                    var selMot = motifs.FirstOrDefault(m => m.Id == editingAbsence.IdMotif);
                    if (selMot != null) cboMotif.SelectedItem = selMot;
                }

                dtpDateDebut.Value = editingAbsence.DateDebut;
                dtpDateFin.Value = editingAbsence.DateFin;
            }

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Absence absence = new Absence
            {
                IdPersonnel = ((Personnel)cboPersonnel.SelectedItem).Id,
                IdMotif = ((Motif)cboMotif.SelectedItem).Id,
                DateDebut = dtpDateDebut.Value,
                DateFin = dtpDateFin.Value
            };
            if (editingAbsence != null)
            {
                absence.Id = editingAbsence.Id;
            }

            if (controller.Chevauchement(absence))
            {
                MessageBox.Show("Chevauchement d'absence détecté");

                return;
            }
            
            if (editingAbsence == null)
            {
                controller.AjouterAbsence(absence);
                MessageBox.Show("Absence ajoutée");

            }
            else
            {
                absence.Id = editingAbsence.Id;

                controller.ModifierAbsence(absence);

                MessageBox.Show("Absence modifiée");


            }
            this.Close();
        }
    }
}
