using System;
namespace DevBuild_Week13_SQLDB_MVC.Models
{
    public class Product
    {
       
        private int id;
        private string name;
        private decimal price;
        private string description;
        private string category;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
    }
}
