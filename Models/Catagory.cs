﻿namespace Online_Restaurant_Management.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}