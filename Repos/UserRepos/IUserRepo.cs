using E_Commerce_Last_Day_.Dtos.PostDtos;

namespace E_Commerce_Last_Day_.Repos.UserRepos
{
    public interface IUserRepo
    {
        IEnumerable<User_Dto> GetAll();
        User_Dto GetById(int id);
        void UpdateUser(User_Only user_dto , int id);
        void UpdateUserAll(User_Dto user_dto , int id);
        void DeleteUser(int id);
        void Adduser(User_Post_Only_Dto author_dto);
        void AddUserAll(User_Dto author_dto);
    }
}
