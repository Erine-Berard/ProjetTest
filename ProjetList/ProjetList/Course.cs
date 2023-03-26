using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetList
{
    class Course
    {
        public Produit Produit { get; set; } = new Produit();
        public int Quantite { get; set; } = 0;
        public int QuantitePrise { get; set; } = 0;
        public decimal TotalPrix { get
            {
                return Quantite * Produit.Prix;
            }
        }

        public Course() { }
        public Course(Produit produit, int quantite, int quantitePrise)
        {
            Produit = produit;
            Quantite = quantite;
            QuantitePrise = quantitePrise;
        }

        public void Afficher()
        {
            Produit.Afficher();
            Console.WriteLine("    - Quantité : " + Quantite);
            Console.WriteLine("    - Quantité dans votre caddie : " + QuantitePrise);
            Console.WriteLine("    - Prix total : " + TotalPrix + "€");
        }
    }
}
