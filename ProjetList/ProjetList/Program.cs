using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Creation des produits 
            List<string> noms = new List<string> { "lait", "oeuf", "yaourt", "eau", "fromage", "pomme", "fraise", "jambon", "salade" };
            List<decimal> prix = new List<decimal> { 0.53m, 5.85m, 4.40m, 0.18m, 5m, 0.54m, 2.49m, 2.20m, 1.29m };

            List<Produit> listeProduit = new List<Produit>();

            for (int i = 0; i<9; i++)
            {
                try
                {
                    Produit produit = new Produit(noms[i], prix[i]);
                    if (produit.Nom != null && produit.Prix != 0)
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
                if (liste.ListeProduit != listeProduit)
                     throw new Exception("La liste de produit n'a pas été ajoutée à notre instance liste");

                else
                {
                    bool play = true;
                    do
                    {
                        // Menu
                        Console.WriteLine("------------- Menu genéral -------------\n");
                        Console.WriteLine("1. Afficher la liste de course");
                        Console.WriteLine("2. Afficher les produits manquants");
                        Console.WriteLine("3. Ajouter un produit à votre liste ");
                        Console.WriteLine("4. Modifier un produit dans votre liste");
                        Console.WriteLine("5. Supprimer un produit de votre liste");
                        Console.WriteLine("6. Gestion du caddie");
                        Console.WriteLine("7. Quitter\n");

                        int choix = 0;
                        try
                        {
                            Console.WriteLine("Votre choix : ");
                            string choixString = Console.ReadLine();
                            
                            Console.Clear();

                            if (int.TryParse(choixString, out choix))
                            {
                                if (choix != 0 && choix < 8)
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
                                            liste.SupprimerProduitListeCourse();
                                            break;
                                        case 6:
                                            Console.Clear();
                                            bool play2 = true;
                                            while(play2)
                                            {
                                                Console.WriteLine("------------- Votre caddie -------------\n");
                                                Console.WriteLine("1. Afficher le caddie");
                                                Console.WriteLine("2. Ajouter un produit");
                                                Console.WriteLine("3. Supprimer un produit");
                                                Console.WriteLine("4. Quitter\n");

                                                int choixCaddie = 0;

                                                while (choixCaddie <= 0)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Votre choix : ");
                                                        string choixCaddieString = Console.ReadLine();
                                                        
                                                        if (!int.TryParse(choixCaddieString, out choixCaddie) || choixCaddie <= 0 || choixCaddie > 4)
                                                            throw new Exception("\nChoix invalide");
                                                        else
                                                            Console.Clear();
                                                    }
                                                    catch(Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }

                                                switch (choixCaddie)
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
                                                Console.Clear();
                                            };
                                            break;
                                        case 7:
                                            play = false;
                                            break;
                                    }
                                }
                                else
                                {
                                    throw new Exception("\nVotre choix n'est pas dans le menu ");
                                }
                            }
                            else
                            {
                                throw new Exception("\nVotre choix doit être un nombre");
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
