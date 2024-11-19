using E_Commerce_Last_Day_.Data;
using E_Commerce_Last_Day_.Dtos.GetDtos;
using E_Commerce_Last_Day_.Dtos.PostDtos;
using E_Commerce_Last_Day_.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Last_Day_.Repos.ProductRepos
{
    public class ProductRepo : IproductRepo
    {
        private readonly DataContext _context;
        public ProductRepo(DataContext context)
        {
            _context = context;
        }
        public void AddproductAll(Product_Dto productdto)
        {
            var p = new Product
            {
                Name = productdto.Name,
                Description = productdto.Description,
                Price = productdto.Price,
                Category = new Category
                {
                    Name = productdto.Category_Dto_GetOnlyCategory.Name
                },
                Users = productdto.User_WithOut_Product_Dtos.Select(x => new User
                {
                    EmailAddress = x.EmailAddress,
                    Password = x.Password,
                    Username = x.Username,
                    PaymentCard = new PaymentCard
                    {
                        CardholderName = x.PaymentCard_Dto_Only.CardholderName,
                        CreditCardNum = x.PaymentCard_Dto_Only.CreditCardNum,
                        ExpiryDate = x.PaymentCard_Dto_Only.ExpiryDate
                    },

                }).ToList(),
            };
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void AddProductOnly(Product_Post_Only_Dto productdto)
        {
            var p = new Product
            {
                Name = productdto.Name,
                Description = productdto.Description,
                Price = productdto.Price,
                Category = _context.Categories.FirstOrDefault(x => x.Id == productdto.CategoryId),
                Users = _context.Users.Where(x => productdto.UserId.Contains(x.Id)).ToList(),
            };
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
           var p = _context.Products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                _context.Products.Remove(p);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<Product_Dto> GetAll()
        {
            var p = _context.Products.Include(x=> x.Category).Include(x=> x.Users).ThenInclude(x=> x.PaymentCard).Select(x=> new Product_Dto
            {
                Name=x.Name,
                Description=x.Description,
                Price=x.Price,
                Category_Dto_GetOnlyCategory = new Category_Dto_GetOnlyCategory
                {
                    Name = x.Name,
                },
                User_WithOut_Product_Dtos = x.Users.Select(x=> new User_WithOut_Product_Dto
                {
                    EmailAddress = x.EmailAddress,
                    Password=x.Password,
                    Username= x.Username,
                    PaymentCard_Dto_Only = new PaymentCard_Dto_Only
                    {
                        CardholderName = x.PaymentCard.CardholderName,
                        CreditCardNum = x.PaymentCard.CreditCardNum,
                        ExpiryDate = x.PaymentCard.ExpiryDate,
                    }
                }).ToList(),
            }).ToList();
            return p;
        }

        public Product_Dto GetById(int id)
        {
            var p = _context.Products.Include(x => x.Category).Include(x => x.Users).ThenInclude(x => x.PaymentCard).FirstOrDefault(x=> x.Id == id);
            return new Product_Dto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category_Dto_GetOnlyCategory = new Category_Dto_GetOnlyCategory
                {
                    Name = p.Category.Name
                },
                User_WithOut_Product_Dtos = p.Users.Select(x => new User_WithOut_Product_Dto
                {
                    EmailAddress = x.EmailAddress,
                    Password = x.Password,
                    Username = x.Username,
                }).ToList(),
            };
        }

        public void UpdateProductAll(Product_Dto product, int id)
        {
            var p = _context.Products.Include(x => x.Category).Include(x => x.Users).ThenInclude(x => x.PaymentCard).FirstOrDefault(x => x.Id == id);
            p.Price = product.Price;
            p.Description = product.Description;
            p.Name = product.Name;
            p.Category = new Category
            {
                Name = product.Category_Dto_GetOnlyCategory.Name,
            };
            p.Users = product.User_WithOut_Product_Dtos.Select(x => new User
            {
                EmailAddress = x.EmailAddress,
                Password= x.Password,
                Username= x.Username,
                PaymentCard = new PaymentCard
                {
                    CardholderName = x.PaymentCard_Dto_Only.CardholderName,
                    CreditCardNum = x.PaymentCard_Dto_Only.CreditCardNum,
                    ExpiryDate = x.PaymentCard_Dto_Only.ExpiryDate,
                }
            }).ToList();
            _context.Products.Update(p);
            _context.SaveChanges();
        }
    }
}
