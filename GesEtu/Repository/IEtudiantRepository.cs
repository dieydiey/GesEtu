using GesEtu.Entity;
using System.Collections.Generic;

namespace GesEtu.Repository
{
    public interface IEtudiantRepository
    {
        void AjouterEtudiant(Etudiant etudiant);
        List<Etudiant> ListerEtudiants();
        Etudiant? RechercherParId(int id);
        void SupprimerEtudiant(int id);
    }
}
