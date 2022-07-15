using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FinalProject.Server.Controllers;
using FinalProject.Shared;

namespace FinalProject.Server.DB
{
    public class ClotheProvider
    {
        private readonly ClotheDbContext _context;
        private readonly ILogger _logger;
        public ClotheProvider(ClotheDbContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("ClotheProvider");
        }

        // public void AddClothe(Clothe clothe)
        // {
        //     var newId = this._context.Clothes.Select(arg =>arg.Id).Max() +1;
        //     clothe.Id = newId;
        //     _context.Clothes.Add(clothe);
        //     _context.SaveChanges();
        // }

        ///////////////////////////////////////
        public void AddClothe(Clothe clothe)
        {
            var newId = this._context.Clothes.Select(arg =>arg.Id).ToArray().LastOrDefault() +1;
            clothe.Id = newId;
            _context.Clothes.Add(clothe);
            _context.SaveChanges();
        }

        // public void AddClothe(int price, string name, int id, string color, string image_src)
        // {
        //     var clothe = new Clothe{price=price, Name = name, Id=id, Color = color, Image_Src = image_src};
        //     var newId = this._context.Clothes.Select(arg =>arg.Id).ToArray().LastOrDefault() +1;
        //     clothe.Id = newId;
        //     _context.Clothes.Add(clothe);
        //     _context.SaveChanges();
        // }

        // public async Task AddClothe(Clothe clothe)
        // {
        //     var lastClothe = this._context.Clothes.LastOrDefault();
        //     var newID = 0; 
        //     if (!(lastClothe is null))
        //         newID = lastClothe.Id +1;
        //     clothe.Id = newID;
        //     await _context.Clothes.AddAsync(clothe);
        //     await _context.SaveChangesAsync();
        // }

        // public async Task AddClothe(Clothe clothe)
        // {
        //     var newId = this._context.Clothes.Select(arg =>arg.Id).Max() +1;
        //     clothe.Id = newId;
        //     await _context.Clothes.AddAsync(clothe);
        //     await _context.SaveChangesAsync();
        // }



        // public  List<Clothe> GetAllClothes()
        //     => this._context.Clothes.ToList();

        public  List<Clothe> GetAllClothes()
            => this._context.Clothes.ToList();

        // public  List<Clothe> GetAllClothes()
        // {
        //     foreach(var clothe in this._context.Clothes)
        //     if (clothe.Image_Src == null)
        //         clothe.Image_Src = "salam";
        //     return this._context.Clothes.ToList();
        // }
        
        // public List<Clothe> RemoveClothe(Clothe clothe)
        // {
        //     // this._context.Clothes = this._context.Clothes.Where(arg => arg.Id != clothe.Id);
        //     // this._context.Clothes = this._context.Clothes.Remove(clothe);
        //     this._context.Clothes.Remove(clothe);
        //     return this._context.Clothes.ToList();
        // }

        // public void RemoveClothe(Clothe clothe)
        // {
        //     this._context.Clothes.Remove(clothe);
        //     _context.SaveChanges();
        // }

        public void RemoveClothe(int id)
        {
            var clothe = this._context.Clothes.Where(arg => arg.Id == id).FirstOrDefault();
            this._context.Clothes.Remove(clothe);
            _context.SaveChanges();
        }

        public void RemoveAllClothes()
        {
            foreach(var clothe in this._context.Clothes)
                _context.Clothes.Remove(clothe);
            this._context.Clothes= null;
            _context.SaveChanges();
        }

        // public void UpdateClothe(int price, string name, int id, string color, string image_src)
        // {
        //     foreach (var c in this._context.Clothes)
        //     {
        //         if (c.Id == id)
        //         {
        //             c.price = price;
        //             c.Name=name;
        //             c.Color=color;
        //             c.Image_Src=image_src;
        //         }
        //     }
        //     _context.SaveChanges();
        // }

        public void UpdateClothe(Clothe newclothe)
        {
            // foreach (var c in this._context.Clothes)
            // {
            //     if (c.Id == newclothe.Id)
            //     {
            //         c.price = newclothe.price;
            //         c.Name=newclothe.Name;
            //         c.Color=newclothe.Color;
            //         c.Image_Src=newclothe.Image_Src;
            //     }
            // }

            foreach (var c in this._context.Clothes)
            {
                if (c.Id == newclothe.Id)
                    c.Count--;
            }
            _context.SaveChanges();
        }


    }
}