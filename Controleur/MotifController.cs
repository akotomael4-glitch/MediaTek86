using MediaTek86.dal;
using MediaTek86.Modele;
using System.Collections.Generic;

namespace MediaTek86.Controleur
{
    public class MotifController
    {
        private MotifDAL motifDAl = new MotifDAL();
        public List<Motif> GetAllMotifs()
        {
            return motifDAl.GetAll();
        }
    
    }
}
