using GesEtu.Entity;
using GesEtu.Repository;
using System.Collections.Generic;
using System.Linq;

namespace GesEtu.Services.Impl
{
    public class EtudiantServiceImpl : IEtudiantService
    {
        private readonly IEtudiantRepository repository;

        public EtudiantServiceImpl(IEtudiantRepository repository)
        {
            this.repository = repository;
        }

        public void AjouterEtudiant(string nomComplet)
        {
            var etu = new Etudiant { NomComplet = nomComplet };
            repository.AjouterEtudiant(etu);
        }

        public List<Etudiant> ListerEtudiants() => repository.ListerEtudiants();

        public void AjouterNote(int idEtudiant, double note)
        {
            var etu = repository.RechercherParId(idEtudiant);
            if (etu != null)
                etu.Notes.Add(note);
        }

        public void SupprimerEtudiant(int idEtudiant) => repository.SupprimerEtudiant(idEtudiant);

        public Etudiant? MeilleurEtudiant()
        {
            var liste = repository.ListerEtudiants();
            return liste.Count > 0 ? liste.OrderByDescending(e => e.Moyenne).First() : null;
        }

        public double MoyenneClasse()
        {
            var liste = repository.ListerEtudiants();
            return liste.Count > 0 ? liste.Average(e => e.Moyenne) : 0.0;
        }
    }
}
