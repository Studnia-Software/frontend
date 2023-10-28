﻿namespace ClientFrontend.Models;

public class Farm
{
    public int Id { get; set; }
    public int User_Id { get; set; }
    public string Name { get; set; }
    public string Delivery_days { get; set; }
    public string Delivery_time { get; set; }

    public List<Product> Products { get; set; }
}