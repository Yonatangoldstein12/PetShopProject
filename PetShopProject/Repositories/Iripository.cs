using PetShopProject.Models;

namespace PetShopProject.Repositories
{
   public interface Iripository
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Category> GetCategories();
        List<Animal> Top2Animal();
        Animal GetAnimalById(int id);
        void Delete(int id); 
        void AddAnimal(Animal animal);
        void UpdateAnimal(int id,Animal animal);
         IEnumerable<Animal> ByCategory(int categoryID);
        IEnumerable<Comments> GetComments(Comments comments);
        IEnumerable <Comments> ShowComments();
    }
}
