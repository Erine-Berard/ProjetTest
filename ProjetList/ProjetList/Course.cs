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
            string stringChampId;
            int champId;
            string stringChampQuant;
            int champQuant;



            // On test l'Id, puis la quantité
            

            return; 
        }
    }
}
