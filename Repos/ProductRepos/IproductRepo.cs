using E_Commerce_Last_Day_.Dtos.PostDtos;

namespace E_Commerce_Last_Day_.Repos.ProductRepos
{
    public interface IproductRepo
    {
        IEnumerable<Product_Dto> GetAll();
        Product_Dto GetById(int id);
        void AddProductOnly(Product_Post_Only_Dto productdto);
        void AddproductAll(Product_Dto productdto);
        void DeleteProduct(int id);
        void UpdateProductAll(Product_Dto product , int id);
    }
}
