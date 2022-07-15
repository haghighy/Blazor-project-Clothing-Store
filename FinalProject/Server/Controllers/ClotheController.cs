using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Server.DB;
using FinalProject.Shared;

namespace FinalProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/Clothe
    public class ClotheController : Controller
    {
        public static List<Clothe> Clothes = new List<Clothe>
        {
            new Clothe {Id=1, Name = "T_shirt", price = 1_000_000, Color="Black", Image_Src="https://orez.co/wp-content/uploads/2020/12/%DA%A9%D9%81%D8%B4-%D9%85%D8%AC%D9%84%D8%B3%DB%8C-%D9%85%D8%B1%D8%AF%D8%A7%D9%86%D9%87-1.jpg"},
            new Clothe {Id=2, Name = "Pants", price = 1_000, Color="Red", Image_Src="https://luxurymezon.com/uploads/products/151ecd0b97ec30925e35d9be09388be6.jpeg"},
            new Clothe {Id=3, Name = "Hat", price = 50_000, Color="Green", Image_Src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr-9zXYKuT-en2CzDVvNi-ZacxIvJB8fg5oA&usqp=CAU"}
        };
                //[Route("clothes")] //api/Clothe/getAllClothes
        // [HttpGet]
        // [Route("getAllClothes")]
        [HttpGet("getAllClothes")] //api/Clothe/getAllClothes
        public List<Clothe> getAllClothes() => ClotheController.Clothes;
        // [HttpGet("{id}")]
        // [Route("getClotheById")]
        [HttpGet("getClotheById/{id}")]
        public Clothe getClotheById (int id) => 
        // ClotheController.Clothes.Where(clothe => clothe.Id == id).FirstOrDefault();
        getAllClothes().Where(clothe => clothe.Id == id).FirstOrDefault();

        [HttpPost]
        [Route("addNewClothe")]
        public Clothe AddNewClothe(Clothe clothe)
        {
            var newId = ClotheController.Clothes.Last().Id+1;
            var newClothe = new Clothe{Id=newId, Color=clothe.Color,Name=clothe.Name,price=clothe.price, Image_Src=clothe.Image_Src };
            return newClothe;
        }

        [HttpDelete]
        [Route("removeClothes")]
        public List<Clothe> RemoveClothes(int[] ids)
        {
            Clothes = Clothes.Where(arg => !ids.Contains(arg.Id)).ToList();
            return Clothes;
        }

        // [HttpDelete]
        // [Route("deleteClothe")]
        // public void DeleteClothe(int id)
        // {
        //     Clothes = Clothes.Where(arg => arg.Id != id).ToList();
        // }


        [HttpDelete]
        [Route("deleteClothe/{id}")]
        public List<Clothe> DeleteClothe(int id)
        {
            Clothes = Clothes.Where(arg => arg.Id != id).ToList();
            return Clothes;
        }


        [HttpPut]
        [Route("updateClotheName")]
        //[HttpPtu("updateClotheName/{id}/{name})]
        public Clothe UpdateClotheName (int id, string newName)
        {
            var clothe = Clothes.Where(arg => arg.Id == id).FirstOrDefault();
            clothe.Name = newName;
            return clothe;
        }

        [HttpPut]
        [Route("updateClothe")]
        public Clothe UpdateClothe (Clothe newClothe)
        {
            // var clothe = Clothes.Where(arg => arg.Id == newClothe.Id).FirstOrDefault();
            // clothe.SetValue(newClothe);
            // clothe = newClothe;
            // return clothe;
            var idx = Clothes.IndexOf(newClothe);
            Clothes[idx] = newClothe;
            return Clothes[idx];
        }

        private readonly ClotheProvider _provider;
        public ClotheController(ClotheProvider provider)
        {
            this._provider = provider;
        }
        ///////////////////////////////////////
        [HttpPost]
        [Route("addNewClotheToDb")]
        public  Clothe AddNewClotheToDb(Clothe newClothe)
        {
            this._provider.AddClothe(newClothe);
            return newClothe;
        }

        // [HttpPost]
        // [Route("addNewClotheToDb/{price}/{name}/{id}/{color}/{image_src}")]
        // public  Clothe AddNewClotheToDb(int price, string name, int id, string color, string image_src)
        // {
        //     this._provider.AddClothe(price,name,id,color,image_src);
        //     var newClothe = new Clothe{price=price, Name = name, Id=Clothes.Select(arg =>arg.Id).ToArray().LastOrDefault() +1, Color = color, Image_Src = image_src};
        //     return newClothe;
        // }

        // [HttpPost]
        // [Route("addNewClotheToDb")]
        // public  async Task<Clothe> AddNewClotheToDb(Clothe newClothe)
        // {
        //     await this._provider.AddClothe(newClothe);
        //     return newClothe;
        // }
        // [HttpGet]
        // [Route("GetAllClothesFromDb")]
        // public List<Clothe> GetAllClothesFromDb()
        //     => this._provider.GetAllClothes();

        [HttpGet]
        [Route("GetAllClothesFromDb")]
        public  List<Clothe> GetAllClothesFromDb()
            =>  this._provider.GetAllClothes();


        // [HttpDelete]
        // [Route("DeleteClotheFromDb")]
        // public List<Clothe> DeleteClotheFromDb(Clothe delclothe)
        //     =>  this._provider.RemoveClothe(delclothe);

        // [HttpDelete]
        // [Route("DeleteClotheFromDb")]
        // public List<Clothe> DeleteClotheFromDb(Clothe delclothe)
        // {
        //     this._provider.RemoveClothe(delclothe);
        //     return this._provider.GetAllClothes();
        // }

        [HttpDelete]
        [Route("DeleteClotheFromDb/{id}")]
        public void DeleteClotheFromDb(int id)
        {
            this._provider.RemoveClothe(id);
        }

        [HttpDelete]
        [Route("RemoveAllClothesFromDb")]
        public void RemoveAllClothesFromDb()
            =>this._provider.RemoveAllClothes();

        // [HttpPut]
        // [Route("updateClotheFromDb/{price}/{name}/{id}/{color}/{image_src}")]
        // public void UpdateClotheFromDb (int price, string name, int id, string color, string image_src)
        // {
        //     this._provider.UpdateClothe(price,name,id,color,image_src);
        // }


        [HttpPut]
        [Route("updateClotheFromDb")]
        public void UpdateClotheFromDb (Clothe newclothe)
        {
            this._provider.UpdateClothe(newclothe);
        }


    }
}