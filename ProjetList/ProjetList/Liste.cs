using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetList
{
    class Liste
    {
        public List<Course> listeCourse { get; set; }
        public List<Course> caddie { get; set; }
        public List<Produit> listeProduit { get; set; }

        public Liste() { }
        public Liste(List<Produit> listeProduit)
        {
            this.listeProduit = listeProduit;
            this.listeCourse = new List<Course>();
            this.caddie = new List<Course>();
        }

        public void AfficherListeCourse()
        {
            if (this.listeCourse.Count == 0)
            {
                Console.WriteLine("Vous n'avez aucun produit dans votre liste");
            }
            else
            {
                Console.WriteLine("Liste des courses :");
                for (int i = 0; i < this.listeCourse.Count; i++)
                {
                    this.listeCourse[i].Afficher();
                }
            }
            Console.WriteLine("Appuyer sur entrer pour retourner au menu :");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        public void AjoutProduitListeCourse()
        {
            try
            {
                var courseToAdd = new Course();
                var prodToAdd = new Produit();
                string stringChampQuant = String.Empty;
                string stringNumero = String.Empty;
                int numero = 0;
                int champQuant = 0;
                int i = 0;

                foreach (var prod in listeProduit)
                {
                    i++;
                    Console.WriteLine($"[{i}] : {prod.nom} - {prod.prix} €");
                }


                //Ici on demande à l'utilisateur de remplir les champs


                //Vérification du Numéro

                if (!int.TryParse(stringNumero, out numero))
                {
                    throw new Exception("Le numéro de produit rentré est invalide");
                }
                else
                {
                    numero = int.Parse(stringNumero);
                    prodToAdd = listeProduit[numero - 1];

                    // Verification de la quantité
                    if (!int.TryParse(stringChampQuant, out champQuant))
                        throw new Exception("La quantité rentrée est invalide");

                    else
                    {
                        champQuant = int.Parse(stringChampQuant);

                        if (champQuant <= 0)
                            throw new Exception("La quantité ne peut pas être négative");

                        courseToAdd.produit = prodToAdd;
                        courseToAdd.quantite= champQuant;

                        listeCourse.Add(courseToAdd);
                    }
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                AjoutProduitListeCourse();
            }
        }

        public void SupprimerProduitListeCourse()
        {
            try
            {
                string stringNumero = String.Empty;
                int numero;
                int i = 0;

                foreach (var course in listeCourse)
                {
                    i++;
                    Console.WriteLine($"[{i}] : {course.produit.nom} x {course.quantite} - prix total : {course.totalPrix}");
                }

                if (!int.TryParse(stringNumero, out numero))
                    throw new Exception("Le numéro rentré est invalide");

                else
                {
                    numero = int.Parse(stringNumero);
                    if (listeCourse[numero - 1] == null)
                        throw new Exception("Le numéro rentré n'est pas compris dans la liste de course");

                    else
                    {
                        var crsToRmv = listeCourse[numero - 1];
                        listeCourse.Remove(crsToRmv);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                SupprimerProduitListeCourse();
            }
        }

        public void AfficherProduitManquant()
        {
            if (this.listeCourse.Count == 0)
            {
                Console.WriteLine("Vous n'avez aucun produit dans votre liste");
            }
            else
            {
                for (int i = 0; i < this.listeCourse.Count; i++)
                {
                    if (this.listeCourse[i].quantitePrise < this.listeCourse[i].quantite)
                    {
                        this.listeCourse[i].Afficher();
                    }
                }
            }
            Console.WriteLine("Appuyer sur entrer pour retourner au menu :");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        public void ModifierProduit()
        {

            return;
        }

        public void AfficherProduitCaddie()
        {
            if (caddie.Count <= 0)
            {
                Console.WriteLine("Le caddie ne contient aucun article.");
            }
            else
            {
                foreach (var crs in caddie)
                {
                    //crs.AfficherProduit();
                }
            }
        }

        public void AjouterProduitCaddie()
        {
            return;
        }

        public void SupprimerProduitCaddie()
        {
            return;
        }

    }
}
