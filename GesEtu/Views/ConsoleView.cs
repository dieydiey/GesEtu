using GesEtu.Services;
using System;

namespace GesEtu.Views
{
    public class ConsoleView
    {
        private readonly IEtudiantService service;

        public ConsoleView(IEtudiantService service)
        {
            this.service = service;
        }

        public void Run()
        {
            int choix;
            do
            {
                Console.WriteLine("\n=== MENU GESTION DES ETUDIANTS ===");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher les étudiants");
                Console.WriteLine("3. Ajouter une note à un étudiant");
                Console.WriteLine("4. Afficher les notes et appréciation");
                Console.WriteLine("5. Supprimer un étudiant");
                Console.WriteLine("6. Afficher le meilleur étudiant");
                Console.WriteLine("7. Afficher la moyenne de la classe");
                Console.WriteLine("8. Quitter");
                Console.Write("Choix : ");

                int.TryParse(Console.ReadLine(), out choix);
                Console.WriteLine();

                switch (choix)
                {
                    case 1:
                        Console.Write("Nom complet : ");
                        service.AjouterEtudiant(Console.ReadLine());
                        Console.WriteLine("Étudiant ajouté !");
                        break;

                    case 2:
                        var liste = service.ListerEtudiants();
                        if (liste.Count == 0)
                            Console.WriteLine("Aucun étudiant enregistré.");
                        else
                            liste.ForEach(e => Console.WriteLine($"[{e.Id}] {e.NomComplet} - Moyenne : {e.Moyenne:F2}"));
                        break;

                    case 3:
                        Console.Write("ID Étudiant : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Note : ");
                        double note = double.Parse(Console.ReadLine());
                        service.AjouterNote(id, note);
                        Console.WriteLine("Note ajoutée !");
                        break;

                    case 4:
                        Console.Write("ID Étudiant : ");
                        id = int.Parse(Console.ReadLine());
                        var etu = service.ListerEtudiants().Find(e => e.Id == id);
                        if (etu != null)
                        {
                            Console.WriteLine($"Étudiant : {etu.NomComplet}");
                            Console.WriteLine($"Notes : {string.Join(", ", etu.Notes)}");
                            Console.WriteLine($"Moyenne : {etu.Moyenne:F2} - {etu.Appreciation}");
                        }
                        else Console.WriteLine(" Étudiant introuvable.");
                        break;

                    case 5:
                        Console.Write("ID à supprimer : ");
                        id = int.Parse(Console.ReadLine());
                        service.SupprimerEtudiant(id);
                        Console.WriteLine(" Étudiant supprimé !");
                        break;

                    case 6:
                        var meilleur = service.MeilleurEtudiant();
                        if (meilleur != null)
                            Console.WriteLine($"🏆 Meilleur étudiant : {meilleur.NomComplet} ({meilleur.Moyenne:F2})");
                        else
                            Console.WriteLine("Aucun étudiant disponible.");
                        break;

                    case 7:
                        Console.WriteLine($"Moyenne de la classe : {service.MoyenneClasse():F2}");
                        break;

                    case 8:
                        Console.WriteLine(" Fin du programme !");
                        break;

                    default:
                        Console.WriteLine(" Choix invalide !");
                        break;
                }

            } while (choix != 8);
        }
    }
}
