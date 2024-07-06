using SpringService.Models;

namespace SpringService.Services
{
    public class CategoryService
    {
        List<Category> popularServices = []; 
        List<Category> AllServices = [];

        public List<Category> GetPopularServices()
        {
            if (popularServices.Count > 0)
                return popularServices;

            popularServices = [
                new(){
                    Id = 1,
                    Name = "House Cleaning",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Book a house cleaner to take care of your home",
                    Status = true
                },
                new(){
                    Id = 2,
                    Name = "Delivery",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Recieve or send your packages within the state",
                    Status = true
                },
                new(){
                    Id = 3,
                    Name = "Auto Repair",
                    Slug = "a09vje30ri23r",
                    Description = "Get in touch with a mechanic to have your vehicle up and running",
                    Status = true
                },
                new(){
                    Id = 4,
                    Name = "Tech Repair",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Phones, Laptops etc you name it. Our professionals have you covered",
                    Status = true
                }
            ];

            return popularServices;
        }

        public List<Category> GetAllServices()
        {
            if (AllServices.Count > 0)
                return AllServices;

            AllServices = [
                new(){
                    Id = 1,
                    Name = "House Cleaning",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Book a house cleaner to take care of your home",
                    Status = true
                },
                new(){
                    Id = 2,
                    Name = "Delivery",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Recieve or send your packages within the state",
                    Status = true
                },
                new(){
                    Id = 3,
                    Name = "Auto Repair",
                    Slug = "a09vje30ri23r",
                    Description = "Get in touch with a mechanic to have your vehicle up and running",
                    Status = true
                },
                new(){
                    Id = 4,
                    Name = "Tech Repair",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Phones, Laptops etc you name it. Our professionals have you covered",
                    Status = true
                },
                new(){
                    Id = 5,
                    Name = "Electrican",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Get in touch with an electrician",
                    Status = true
                },
                new(){
                    Id = 6,
                    Name = "Plumber",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Get in touch with a plumber",
                    Status = true
                },
                new(){
                    Id = 7,
                    Name = "Dry Cleaner/Laundry man",
                    Slug = "a09vje30ri23r",
                    Image = "image",
                    Description = "Get in touch with a dry cleaner",
                    Status = true
                }
            ];

            return AllServices;
        }
    }

}
