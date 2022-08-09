﻿using api.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using share.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using api.Utils;


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

                return new
                {
                    Success = true,
                    Data = foods
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Food(GetAll): error"
                };
            }
        }

        public async Task<dynamic> GetById(int id)
        {
            try
            {
                var food = await _context.Foods.FindAsync(id);

                if (food != null)
                {
                    return new
                    {
                        Success = true,
                        Data = food
                    };
                }

                return new
                {
                    Success = false
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Food(GetById): error"
                };
            }
        }

        public async Task<dynamic> Add(IFormCollection data)
        {
            try
            {
                var files = data.Files;


                if (data.TryGetValue("foodData", out var someData))
                {
                    var newFood = JsonSerializer.Deserialize<FoodModel>(someData);

                    var dbFoodName = await _context.Foods.Where(food => food.Name == newFood.Name).ToListAsync();

                    if (dbFoodName.Count > 0) return new
                    {
                        Success = false,
                        Message = "Tên món ăn đã tồn tại"
                    };

                    string imagePath = await ImageHelper.Upload(files[0], _webHostEnvironment);

                    newFood.Image = imagePath;

                    await _context.Foods.AddAsync(newFood);
                    await _context.SaveChangesAsync();

                    return new
                    {
                        Success = true,
                        Data = newFood
                    };
                }
            }
            catch (Exception)
            {

            }

            return new
            {
                Success = false,
                Message = "Food(Add): error"
            };
        }

        public async Task<dynamic> Update(IFormCollection data, int id)
        {
            try
            {

                var files = data.Files;


                if (data.TryGetValue("foodData", out var someData))
                {
                    string imagePath = "";

                    var newFood = JsonSerializer.Deserialize<FoodModel>(someData);
                    var food = _context.Foods.Find(id);

                    var dbFoodName = await _context.Foods.Where(food => food.Name == newFood.Name).ToListAsync();

                    if (dbFoodName.Count > 0 && newFood.Name != food.Name) return new
                    {
                        Success = false,
                        Message = "Tên món ăn đã tồn tại"
                    };

                    food.Name = newFood.Name;
                    food.Price = newFood.Price;
                    food.Status = newFood.Status;
                    food.IsDeleted = newFood.IsDeleted;

                    if (files.Count > 0)
                    {
                        imagePath = await ImageHelper.Upload(files[0], _webHostEnvironment);
                        food.Image = imagePath;
                    }

                    await _context.SaveChangesAsync();

                    return new
                    {
                        Success = true,
                        Data = food
                    };
                }
            }
            catch (Exception)
            {

            }

            return new
            {
                Success = false,
                Message = "Food(Update): error"
            };
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
