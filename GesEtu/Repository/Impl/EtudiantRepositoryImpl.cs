using GesEtu.Entity;
using System.Collections.Generic;
using System.Linq;

namespace GesEtu.Repository.Impl
{
    public class EtudiantRepositoryImpl : IEtudiantRepository
    {
        private readonly List<Etudiant> etudiants = new();
        private int compteur = 1;

        public void AjouterEtudiant(Etudiant etudiant)
        {
            etudiant.Id = compteur++;
            etudiants.Add(etudiant);
        }

        public List<Etudiant> ListerEtudiants() => etudiants;

        public Etudiant? RechercherParId(int id) => etudiants.FirstOrDefault(e => e.Id == id);

        public void SupprimerEtudiant(int id)
        {
            var etu = RechercherParId(id);
            if (etu != null)
                etudiants.Remove(etu);
        }
    }
}
