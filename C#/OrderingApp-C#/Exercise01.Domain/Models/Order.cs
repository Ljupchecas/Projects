﻿using Exercise01.Domain.Enums;

namespace Exercise01.Domain.Models
{
    public class Order
    { 
        public Order() 
        {
            Status = OrderStatus.Processing;
        }

        public Order(int id, string title, string description, OrderStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }
        private string _title;
        public int Id { get; set; }
        public string Title 
        { 
            get => _title;
            set => _title = TextHelper.CapitalizeFirstLetter(value);
        }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public string Print()
        {
            return $"{Title} - {Description}";
        }
    }
}
