using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetList
{
    class Liste
    {
        public List<Course> ListeCourse { get; set; }
        public List<Course> Caddie { 
            get {
                var caddie = new List<Course>();

                foreach (var crs in ListeCourse)
                    if (crs.QuantitePrise > 0)
                        caddie.Add(crs);

                return caddie;
            }
        }
        public List<Produit> ListeProduit { get; set; }

        public Liste() { }
        public Liste(List<Produit> listeProduit)
        {
            ListeProduit = listeProduit;
            ListeCourse = new List<Course>();
        }

        private void Clear()
        {
            Console.WriteLine("Appuyer sur une \"Entrer\" pour retourner au menu :");
            Console.ReadLine();
            Console.Clear();
        }

        public void AfficherListeCourse()
        {
            try
            {
                if (ListeCourse.Count == 0)
                    throw new Exception("Votre liste de courses est vide");

                Console.WriteLine("Votre liste de courses :");
                var i = 0;
                foreach (var course in ListeCourse)
                {
                    i++;
                    Console.Write($"{i} ");
                    course.Afficher();
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                
            }
            Clear();
        }

        public void AjoutProduitListeCourse()
        {
            var courseToAdd = new Course();
            var prodToAdd = new Produit();
            string stringChampQuant = String.Empty;
            string stringNumero = String.Empty;
            int numero = 0;
            int champQuant = 0;
            
            while (numero <= 0)
            {
                try
                {
                    int i = 0;
                    Console.WriteLine();

                    foreach (var prod in ListeProduit)
                    {
                        i++;
                        Console.Write($"{i} ");
                        prod.Afficher();
                    }

                    Console.WriteLine("\nVeuillez selectionner un produit à ajouter:");
                    stringNumero = Console.ReadLine();

                    if (!int.TryParse(stringNumero, out numero) || numero <= 0 || numero > ListeProduit.Count)
                        throw new Exception("\nLe numéro de produit rentré est invalide");

                    prodToAdd = ListeProduit[numero - 1];

                    while (champQuant <= 0)
                    {
                        try
                        {
                            Console.WriteLine($"\nChoississez une quantité pour : {prodToAdd.Nom}");
                            stringChampQuant = Console.ReadLine();

                            if (!int.TryParse(stringChampQuant, out champQuant))
                                throw new Exception("\n La quantité rentrée est invalide");

                            if (champQuant <= 0)
                                throw new Exception("\nLa quantité ne peut pas être négative");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            champQuant = 0;
                        }
                    };
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    numero = 0;
                }
            }
            courseToAdd.Produit = prodToAdd;
            courseToAdd.Quantite = champQuant;

            ListeCourse.Add(courseToAdd);
            Console.WriteLine($"\n{champQuant} {prodToAdd.Nom}(s) ajouté(s) à votre liste de courses !");
            Clear();
        }


        public void SupprimerProduitListeCourse()
        {
            string stringNumero = String.Empty;
            int numero = 0;
            int i = 0;

            try
            {
                if (ListeCourse.Count == 0)
                    throw new Exception("Votre liste de course est vide.");

                Console.WriteLine("Votre liste de courses :");
                foreach (var crs in ListeCourse)
                {
                    i++;
                    Console.Write($"{i} ");
                    crs.Afficher();
                }
                while (numero <= 0)
                {
                    try
                    {
                        Console.WriteLine("Veuillez sélectionner le produit à supprimer :");
                        stringNumero = Console.ReadLine();
                        if (!int.TryParse(stringNumero, out numero) || numero <= 0 || numero > ListeCourse.Count)
                            throw new Exception("Le numéro rentré est invalide");

                        ListeCourse.Remove(ListeCourse[numero - 1]);
                        Console.WriteLine("Produit retiré !");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        numero = 0;
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Clear();
        }

        public void AfficherProduitManquant()
        {
            try
            {
                if (ListeCourse.Count == 0)
                    throw new Exception("Votre liste de course est vide.");

                if (Caddie == ListeCourse)
                    Console.WriteLine("On dirait que vous avez tout ce qu'il vous faut !");

                else
                {
                    Console.WriteLine("Voici les produits manquants:");
                    int i = 0;
                    foreach (var crs in ListeCourse)
                    {
                        i++;
                        if (crs.QuantitePrise < crs.Quantite)
                        {
                            Console.Write($"{i} ");
                            ListeCourse[i - 1].Afficher();
                            Console.WriteLine($"Manque : {-(crs.QuantitePrise - crs.Quantite)}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Clear();
        }

        public void ModifierProduit()
        {
            string stringNumero = String.Empty;
            int numero = 0;

            string stringQuant = String.Empty;
            int quantite = 0;

            Course prodToMod = new Course();

            try
            {
                if (ListeCourse.Count == 0)
                    throw new Exception("Votre liste de course est vide.");

                Console.WriteLine("Liste des produits :");

                int i = 0;
                foreach (var crs in ListeCourse)
                {
                    i++;
                    Console.Write($"{i} ");
                    crs.Afficher();
                }

                while (numero <= 0)
                {
                    try
                    {
                        Console.WriteLine("\nVeuillez selectionner un produit:");
                        stringNumero = Console.ReadLine();
                        if (!int.TryParse(stringNumero, out numero) || numero <= 0 || numero > ListeCourse.Count)
                            throw new Exception("\nLe numéro rentré est invalide");

                        prodToMod = ListeCourse[numero - 1];

                        while (quantite <= 0)
                        {
                            try
                            {
                                Console.WriteLine("\nEntrez la nouvelle quantité");
                                stringQuant = Console.ReadLine();
                                if (!int.TryParse(stringQuant, out quantite) || quantite <= 0)
                                    throw new Exception("\nLa quantite rentrée est invalide");

                                prodToMod.Quantite = quantite;
                                Console.WriteLine("Quantité modifiée !");
                                Clear();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                quantite = 0;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        numero = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AfficherProduitCaddie()
        {
            try
            {
                if (Caddie.Count == 0)
                    throw new Exception("Vous n'avez aucun produit dans votre liste");

                Console.WriteLine("Votre liste de courses :");
                int i = 0;
                foreach (var crs in Caddie)
                {
                    i++;
                    Console.Write($"{i} ");
                    crs.Afficher();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Clear();
        }

        public void AjouterProduitCaddie()
        {
            string stringNumero = String.Empty;
            int numero = 0;

            string stringQuantite = String.Empty;
            int quantite = 0;

            Course courToAdd = new Course();

            int i = 0;
            foreach (var crs in ListeCourse)
            {
                i++;
                Console.Write($"{i} ");
                crs.Afficher();
            }

            while (numero <= 0)
            {
                try
                {
                    Console.WriteLine("\nVeuillez selectionner un produit à ajouter:");
                    stringNumero = Console.ReadLine();

                    if (!int.TryParse(stringNumero, out numero) || numero <= 0 || numero > ListeCourse.Count)
                        throw new Exception("\nLe numéro de produit rentré est invalide");

                    courToAdd = ListeCourse[numero - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    numero = 0;
                }
            }

            while (quantite <= 0)
            {
                try
                {
                    Console.WriteLine($"\nChoississez une quantité pour : {courToAdd.Produit.Nom}");
                    stringQuantite = Console.ReadLine();
                    if (!int.TryParse(stringQuantite, out quantite))
                        throw new Exception("\n La quantité rentrée est invalide");

                    if (quantite <= 0)
                        throw new Exception("\nLa quantité ne peut pas être négative");

                    courToAdd.QuantitePrise = quantite;

                    Console.WriteLine($"\n{quantite} {courToAdd.Produit.Nom}(s) ajouté(s) à votre caddie !");
                    Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    quantite = 0;
                }
            }
        }

        public void SupprimerProduitCaddie()
        {
            string stringNumero = String.Empty;
            int numero = 0;

            try
            {
                if (Caddie.Count == 0)
                    throw new Exception("\nVotre caddie est vide.");

                Console.WriteLine("\nVoici votre caddie actuel : ");
                int i = 0;
                foreach(var prod in Caddie)
                {
                    i++;
                    Console.Write($"{i} ");
                    prod.Afficher();
                }

                while (numero <= 0)
                {
                    try
                    {
                        Console.WriteLine("\nVeuillez sélectionner un acticle à retirer.");
                        stringNumero = Console.ReadLine();

                        if (!int.TryParse(stringNumero, out numero) || numero <= 0 || numero > Caddie.Count)
                            throw new Exception("Le numéro entré est invalide");

                        int index = ListeCourse.IndexOf(Caddie[numero - 1]);

                        var artToRmv = ListeCourse[index];

                        artToRmv.QuantitePrise = 0;
                        Console.WriteLine("Article retiré avec succès !");
                        Clear();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Clear();
            }
        }
    }
}
