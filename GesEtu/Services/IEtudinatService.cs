using GesEtu.Entity;
using System.Collections.Generic;

namespace GesEtu.Services
{
    public interface IEtudiantService
    {
        void AjouterEtudiant(string nomComplet);
        List<Etudiant> ListerEtudiants();
        void AjouterNote(int idEtudiant, double note);
        void SupprimerEtudiant(int idEtudiant);
        Etudiant? MeilleurEtudiant();
        double MoyenneClasse();
    }
}
