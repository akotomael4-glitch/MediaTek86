using System;
using System.Windows.Forms;

namespace MediaTek86.Modele
{
    public class Absence
    {
        public int Id { get; set; }
        public int IdPersonnel { get; set; }
        public int IdMotif { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public string Personnel { get; set; }
        public string Motif { get; set; }
    }
}