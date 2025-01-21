﻿namespace CQRSNight.CQRSDesignPattern.Commands.ProductCommands
{
    public class UpdateProductCommand
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
    }
}