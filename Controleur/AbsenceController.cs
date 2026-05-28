using MediaTek86 .dal;
using MediaTek86 .Modele;
using System.Collections .Generic;
using System.Drawing.Text;


namespace MediaTek86.Controleur
{
    public class AbsenceController
    {
        private AbsenceDAL absenceDAL = new AbsenceDAL();

        public List<Absence> GetAllAbsences()
        {
            return absenceDAL.GetAll();
        }
        public void AjouterAbsence(Absence absence)
        {
            absenceDAL.Add(absence);

        }

        public void ModifierAbsence(Absence absence)
        {
            absenceDAL.Modifier(absence);
        }


        public void SupprimerAbsence(int id)
        {
            absenceDAL.Supprimer(id);
        }

        public bool Chevauchement(Absence absence)
        {
            return absenceDAL.Chevauchement(absence);
        }
    }
}