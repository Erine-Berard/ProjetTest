using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetList
{
    class Course
    {
        public Produit produit { get; set; } = new Produit();
        public int quantite { get; set; } = 0;
        public int quantitePrise { get; set; } = 0;
        public decimal totalPrix { get
            {
                return quantite * produit.prix;
            }
        }

        public Course() { }
        public Course(Produit produit, int quantite, int quantitePrise)
        {
            this.produit = produit;
            this.quantite = quantite;
            this.quantitePrise = quantitePrise;
        }

        public void Afficher()
        {
            produit.Afficher();
            Console.WriteLine("    - Quantité : " + quantite);
            Console.WriteLine("    - Quantité dans votre caddie : " + quantitePrise);
            Console.WriteLine("    - Prix total : " + totalPrix + "€");


            // On test l'Id, puis la quantité


            return; 
        }
    }
}
