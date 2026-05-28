using MediaTek86.dal;

namespace MediaTek86.Controleur
{
    public class ResponsableController
    {
        private ResponsableDAL responsableDAL = new ResponsableDAL();

        public bool Connexion(string login, string pwd)
        {
            return responsableDAL.Connexion(login, pwd);
        }
    }
}
