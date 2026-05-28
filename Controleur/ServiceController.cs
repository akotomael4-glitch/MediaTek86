using MediaTek86.dal;
using MediaTek86.Modele;
using System.Collections.Generic;

namespace MediaTek86.Controleur
{
    public class ServiceController
    {
        private ServiceDal serviceDal = new ServiceDal();

        public List<Service> GetAllServices()
        {
            return serviceDal.GetAll();
        }
    }
}
