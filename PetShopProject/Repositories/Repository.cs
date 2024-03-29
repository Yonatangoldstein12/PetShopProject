﻿using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using PetShopProject.Services;
using System.Xml.Linq;

namespace PetShopProject.Repositories
{
    public class Repository : Iripository
    {
        private readonly DBContext dBContext;

        public Repository(DBContext _dbContext)
        {
            dBContext = _dbContext;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return dBContext.Animals;
        }
        public List<Animal> Top2Animal()
        {
            return dBContext.Animals.Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();
        }
        public Animal GetAnimalById(int id) => dBContext.Animals.First(a => a.AnimalId == id);
        public void Delete(int id)
        {
            var Animal= dBContext.Animals.Single(animal => animal.AnimalId == id);
            dBContext.Animals.Remove(Animal);
            dBContext.SaveChanges();
        }
        public void AddAnimal(Animal animal)
        {
           dBContext.Add(animal);
           dBContext.SaveChanges();
        }
        public IEnumerable<Category> GetCategories()
        {
            return dBContext.Categories;
        }
        public void UpdateAnimal(int id, Animal animal)
        {
            var animalInDb = dBContext.Animals!.Single(m => m.AnimalId == id);
            animalInDb.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.Category = animal.Category;
            animalInDb.Comments = animal.Comments;
            animalInDb.PicturePath = animal.PicturePath;
            animalInDb.Descripition = animal.Descripition;
            dBContext.SaveChanges();
        }
        public IEnumerable<Animal> ByCategory(int categoryID)
        {
            return dBContext.Categories.Find(categoryID)!.Animals!;
        }

        public IEnumerable<Comments> AddComments( string comment, int id)
        {
            Comments _comment = new()
            {
                Descripition = comment,
                AnimalId = id
            };
            dBContext.Add(_comment);
            dBContext.SaveChanges();
            return dBContext.Comments;
        }
        public IEnumerable <Comments> ShowComments(int Id)
        {
            var animal = dBContext.Animals!.Find(Id);
            return animal.Comments!; 
        }
    }
}

