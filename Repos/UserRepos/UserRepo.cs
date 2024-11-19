using E_Commerce_Last_Day_.Data;
using E_Commerce_Last_Day_.Dtos.GetDtos;
using E_Commerce_Last_Day_.Dtos.PostDtos;
using E_Commerce_Last_Day_.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Last_Day_.Repos.UserRepos
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;
        }
        public void Adduser(User_Post_Only_Dto author_dto)
        {
            var u = new User
            {
                EmailAddress = author_dto.EmailAddress,
                Password = author_dto.Password,
                Username = author_dto.Username,
                Products = _context.Products.Where(x => author_dto.ProductId.Contains(x.Id)).ToList(),
                PaymentCard = _context.PaymentCards.FirstOrDefault(x => x.Id == author_dto.PaymentCardId)
            };
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public void AddUserAll(User_Dto author_dto)
        {
            var u = new User
            {
                EmailAddress = author_dto.EmailAddress,
                Password = author_dto.Password,
                Username = author_dto.Username,
                PaymentCard = new PaymentCard
                {
                    CardholderName = author_dto.PaymentCard_Dto_Only.CardholderName,
                    ExpiryDate = author_dto.PaymentCard_Dto_Only.ExpiryDate,
                    CreditCardNum = author_dto.PaymentCard_Dto_Only.CreditCardNum
                },
                Products = author_dto.Product_Dto_For_Users.Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Category = new Category
                    {
                        Name = x.Name
                    },
                }).ToList(),
            };
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var a = _context.Users.Include(x=> x.PaymentCard).FirstOrDefault(x=> x.Id == id);
            if (a != null)
            {
                _context.Users.Remove(a);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<User_Dto> GetAll()
        {
            var a = _context.Users.Include(x=> x.PaymentCard).Include(x=> x.Products).ThenInclude(x=> x.Category).Select(x=> new User_Dto
            {
                Password = x.Password,
                EmailAddress = x.EmailAddress,
                Username = x.Username,
                Product_Dto_For_Users = x.Products.Select(x => new Product_Dto_For_User
                {
                    Price = x.Price,
                    Description = x.Description,
                    Name = x.Name,
                    Category = new Category_Dto_GetOnlyCategory
                    {
                        Name = x.Name
                    }
                }).ToList(),
                PaymentCard_Dto_Only = new PaymentCard_Dto_Only
                {
                    CardholderName = x.PaymentCard.CardholderName,
                    CreditCardNum = x.PaymentCard.CreditCardNum,
                    ExpiryDate = x.PaymentCard.ExpiryDate,
                }
            }).ToList();
            return a;
        }

        public User_Dto GetById(int id)
        {
            var u = _context.Users.Include(x => x.PaymentCard).Include(x => x.Products).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);
            if (u == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }
            return new User_Dto
            {
                EmailAddress = u.EmailAddress,
                Username = u.Username,
                Password = u.Password,
                Product_Dto_For_Users = u.Products.Select(x => new Product_Dto_For_User
                {
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Category = new Category_Dto_GetOnlyCategory { Name = x.Name }
                }).ToList(),
                PaymentCard_Dto_Only = new PaymentCard_Dto_Only
                {
                    CardholderName = u.PaymentCard.CardholderName,
                    CreditCardNum = u.PaymentCard.CreditCardNum,
                    ExpiryDate = u.PaymentCard.ExpiryDate,
                }
            };
        }

        

        public void UpdateUser(User_Only user_dto, int id)
        {
            var u = _context.Users.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                u.EmailAddress = user_dto.EmailAddress;
                u.Username = user_dto.Username;
                u.Password = user_dto.Password;
                _context.Users.Update(u);
                _context.SaveChanges();
            }
            return;
        }

        public void UpdateUserAll(User_Dto user_dto, int id)
        {
            var u = _context.Users.Include(x=> x.PaymentCard).Include(x=> x.Products).ThenInclude(x=> x.Category).FirstOrDefault(x=> x.Id == id);
            u.Username =user_dto.Username;
            u.Password =user_dto.Password;
            u.EmailAddress=user_dto.EmailAddress;
            u.PaymentCard = new PaymentCard
            {
                CardholderName = user_dto.PaymentCard_Dto_Only.CardholderName,
                CreditCardNum = user_dto.PaymentCard_Dto_Only.CreditCardNum,
                ExpiryDate = user_dto.PaymentCard_Dto_Only.ExpiryDate,
            };
            u.Products = user_dto.Product_Dto_For_Users.Select(x => new Product
            {
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Category = new Category
                {
                    Name = x.Name
                }
            }).ToList();
            _context.Users.Update(u);
            _context.SaveChanges();
        }
    }
}
