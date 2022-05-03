﻿using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkProducts
    {
        public static List<Product> ShowAllProducts()
        {
            var products = new List<Product>();

            using (var db = new Decrypt_LibraryContext())
            {
                products = db.Products.ToList();
                return products;
            }
        }
        public static List<CategoryName_Product> ShowSearchedProduct(string selectedTitle)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var products = (from prod in db.Products
                                join cate in db.Categories on prod.CategoryId equals cate.Id
                                select new CategoryName_Product
                                {
                                    Id = prod.Id,
                                    Title = prod.Title,
                                    AuthorName = prod.AuthorName,
                                    Category = cate.CategoriesName
                                }).ToList();

                var findProduct = products.Where(p => p.Title.ToLower().Contains(selectedTitle.ToLower()) || p.Category.ToLower().Contains(selectedTitle.ToLower())).ToList();

                return findProduct;
            }
        }
        public static Product ShowSpecificProductID(int selectedID)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.SingleOrDefault(p => p.Id == selectedID);

                return product;
            }
        }
        public static List<Product> ShowSpecificProductAuthor(string selectedAuthor)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.Where(p => p.AuthorName.Contains(selectedAuthor));

                return products;
            }
        }
        public static List<Product> ShowAllProductsOnSpecificShelf(int shelfId)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.Where(p => p.Id == shelfId);

                return products;
            }
        }
        public static SelectedProduct ShowProductInformation(int productId)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var products = (from prod in db.Products
                             join age in db.Audiences on prod.AudienceId equals age.Id
                             join lang in db.Languages on prod.LanguageId equals lang.Id
                             join cate in db.Categories on prod.CategoryId equals cate.Id
                             join shelf in db.Shelves on prod.ShelfId equals shelf.Id
                             select new SelectedProduct
                             {
                                 Id = prod.Id,
                                 Audience = age.AgeGroup,
                                 
                                 Category = cate.CategoriesName,
                                 Shelf = shelf.Shelfname,
                                 Title = prod.Title,
                                 AuthorName = prod.AuthorName,
                                 Description = prod.Description,
                                 Narrator = prod.Narrator,
                                 Isbn = prod.Isbn,
                                 Publisher = prod.Publisher,
                                 Pages = prod.Pages,
                                 Playtime = prod.Playtime,
                                 PublishDate = prod.PublishDate,
                                 Status = prod.Status
                             }).ToList();                

                var selectProduct = products.FirstOrDefault(sp => sp.Id == productId);

                return selectProduct;
            }
        }

        public static void RemoveSpecificProductID(int selectedID)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.Where(p => p.Id == selectedID).SingleOrDefault();

                var productList = db.Products;

                productList.Remove(product);
                db.SaveChanges();
            }
        }

        public static void AddAProduct(Product product)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var productList = db.Products;

                productList.Add(product);
                db.SaveChanges();
            }
        }
    }
}
