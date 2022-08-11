using Microsoft.AspNetCore.Http;
using share.Models;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IFood
    {
        Task<dynamic> GetAll();
        Task<dynamic> GetById(int id);
        Task<dynamic> Add(FoodModel newFood);
        Task<dynamic> Search(string keyword);
        Task<dynamic> Update(FoodModel updatedFood, int id);
        Task<dynamic> Delete(int id);
    }
}
