﻿using System;
using System.Windows.Forms;
using FarmacySystem.view;
using FarmacySystem.controller;

namespace FarmacySystem.view.Farmaceutico
{
    static class Program
    {
        
        // static void Main(string[] args)
        // {
        //     CrudSale sale = new CrudSale();
        //     DateTime dateTime= DateTime.Now;
        //     sale.InsertSales("Thiago", dateTime, 150, 1);
        // }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
