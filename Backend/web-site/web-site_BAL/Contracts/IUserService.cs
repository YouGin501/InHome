using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IUserService
    {
        public Task<User?> LoginUser(string email, string password);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User?> GetUserById(int Id);
        public Task<User> AddUser(User user);
        public Task UpdateUser(int id, User user);
        public Task DeleteUser(int userId);
        public Task AddDocuments(List<IFormFile> files, int userId);
        public Task<bool> DeleteDocument(int userId, List<Document> documents);
        public Task UpdatePhoto(IFormFile photo, int userId);
    }
}
