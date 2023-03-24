using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjetList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creation des produits 
            List<string> noms = new List<string> { "lait", "oeuf", "yaourt", "eau", "fromage", "pomme", "fraise", "jambon", "salade" };
            List<decimal> prix = new List<decimal> { 0.53m, 5.85m, 4.40m, 0.18m, 5m, 0.54m, 2.49m, 2.20m, 1.29m };

            List<Produit> listeProduit = new List<Produit>();

            for (int i = 0; i<9; i++)
            {
                try
                {
                    Produit produit = new Produit(noms[i], prix[i]);
                    if (produit.nom != null && produit.prix != 0)
                    {

                        listeProduit.Add(produit);
                        if (listeProduit[i] == produit)
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception("Le produit n°" + i + " n'a pas été ajouté à la liste");
                        }
                    }
                    else
                    {
                        throw new Exception("Problème dans la création du produit n°" + i + " : Le nom ou le prix est vide");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Creation de l'instance liste
            try
            {
                Liste liste = new Liste(listeProduit);
                if (liste.listeProduit != listeProduit)
                {
                     throw new Exception("La liste de produit n'a pas été ajouter à notre instance liste");
                }
                else
                {
                    bool play = true;
                    do
                    {
                        // Menu
                        Console.WriteLine("Menu :");
                        Console.WriteLine("1. Afficher la liste de course");
                        Console.WriteLine("2. Afficher les produits manquants");
                        Console.WriteLine("3. Ajouter un produit à notre liste ");
                        Console.WriteLine("4. Modifier un produit");
                        Console.WriteLine("5. Gestion du caddie");
                        Console.WriteLine("6. Quitter");

                        try
                        {
                            Console.WriteLine("Votre choix : ");
                            string choixString = Console.ReadLine();
                            int choix = 0;

                            if (int.TryParse(choixString, out choix))
                            {
                                if (choix != 0 && choix < 7)
                                {
                                    switch (choix)
                                    {
                                        case 1:
                                            liste.AfficherListeCourse();
                                            break;
                                        case 2:
                                            liste.AfficherProduitManquant();
                                            break;
                                        case 3:
                                            liste.AjoutProduitListeCourse();
                                            break;
                                        case 4:
                                            liste.ModifierProduit();
                                            break;
                                        case 5:
                                            bool play2 = true;
                                            do
                                            {
                                                Console.WriteLine("Menu caddie :");
                                                Console.WriteLine("1. Afficher le caddie");
                                                Console.WriteLine("2. Ajouter un produit");
                                                Console.WriteLine("3. Supprimer un produit");
                                                Console.WriteLine("4. Quitter");
                                                try
                                                {
                                                    Console.WriteLine("Votre choix : ");
                                                    string choixCaddieString = Console.ReadLine();
                                                    int choixCaddi = 0; 
                                                    if (int.TryParse(choixString, out choix))
                                                    {
                                                        if (choixCaddi != 0 && choix < 5)
                                                        {
                                                            switch (choixCaddi)
                                                            {
                                                                case 1:
                                                                    liste.AfficherProduitCaddie();
                                                                    break;
                                                                case 2:
                                                                    liste.AjouterProduitCaddie();
                                                                    break;
                                                                case 3:
                                                                    liste.SupprimerProduitCaddie();
                                                                    break;
                                                                case 4:
                                                                    play2 = false;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Votre choix n'est pas dans le menu ");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Votre choix doit être un nombre");
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                            } while (play2 == true);
                                            break;
                                        case 6:
                                            play = false;
                                            break;
                                    }

                                }
                                else
                                {
                                    throw new Exception("Votre choix n'est pas dans le menu ");
                                }
                            }
                            else
                            {
                                throw new Exception("Votre choix doit être un nombre");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (play == true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
