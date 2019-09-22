﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public static class DataInitializer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,BookShopDb context)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager,context);
        }
        public static async Task SeedUsers(UserManager<User> userManager,BookShopDb context)
        {
            string username = "admin";
            string password = "Adm$n1";
            if (await userManager.FindByNameAsync(username) == null)
            {
                User admin = new User();
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    var bucket = new Bucket() { User = admin, UserId = admin.Id };
                    admin.Bucket = bucket;
                    await context.Buckets.AddAsync(bucket);
                    await context.SaveChangesAsync();
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Reader","Admin" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (roleExist == false)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
