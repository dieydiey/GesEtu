namespace GesEtu.Entity
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string NomComplet { get; set; }
        public List<double> Notes { get; set; } = new List<double>();

        public double Moyenne => Notes.Count > 0 ? Notes.Average() : 0.0;

        public string Appreciation
        {
            get
            {
                if (Moyenne >= 16) return "Très Bien";
                else if (Moyenne >= 14) return "Bien";
                else if (Moyenne >= 12) return "Assez Bien";
                else if (Moyenne >= 10) return "Passable";
                else return "Insuffisant";
            }
        }
    }
}
