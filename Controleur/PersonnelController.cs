using MediaTek86.dal;
using MediaTek86.Modele;
using System.Collections.Generic;

namespace MediaTek86.Controleur
{
    public class PersonnelController
    {
        private PersonnelDAl personnelDAl = new PersonnelDAl();

        public List<Personnel> GetAllPersonnel()
        {
            return personnelDAl.GetAll();
        }

        public void AjouterPersonnel(Personnel personnel)
        {
            personnelDAl.Ajouter(personnel);
        }

        public void SupprimerPersonnel(int id)
        {
            personnelDAl.supprimer(id);
        }

        public void ModifierPersonnel(Personnel personnel)
        {
            personnelDAl.Modifier(personnel);
        }
    }
}

