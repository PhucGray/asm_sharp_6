using api.Interfaces;
using api.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using share.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace api.Services
{
    public class FoodService : IFood
    {
        protected DataContext _context;
        protected IWebHostEnvironment _webHostEnvironment;

        public FoodService(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<dynamic> GetAll()
        {
            try
            {
                var foods = await _context.Foods.ToListAsync();
                return foods;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<dynamic> GetById(int id)
        {
            try
            {
                var food = await _context.Foods.FindAsync(id);

                if (food != null)
                {
                    return food;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<dynamic> Add(FoodModel newFood)
        {
            try
            {
                await _context.Foods.AddAsync(newFood);
                await _context.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Data = newFood
                };
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<dynamic> Update(FoodModel updatedFood, int id)
        {
            try
            {
                var food = _context.Foods.Find(id);

                food.Name = updatedFood.Name;
                food.Price = updatedFood.Price;
                food.Status = updatedFood.Status;
                food.IsDeleted = updatedFood.IsDeleted;
                food.Image = updatedFood.Image;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                
            }

            return null;
        }

        public async Task<dynamic> Delete(int id)
        {
            try
            {
                var food = _context.Foods.Find(id);
                if (food != null)
                {
                    _context.Foods.Remove(food);
                    await _context.SaveChangesAsync();

                    ImageHelper.Delete(food.Image, _webHostEnvironment);

                    return new
                    {
                        Success = true
                    };
                }

                return new
                {
                    Success = false,
                    Message = "Food(Delete): error"
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Food(Delete): error"
                };
            }
        }
    }
}
