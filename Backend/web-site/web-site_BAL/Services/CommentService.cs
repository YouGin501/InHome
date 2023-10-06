using System.Linq.Expressions;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentsRepository;
        private readonly IUserRepository _usersRepository;

        public CommentService(ICommentRepository commentsRepository, IUserRepository userRepository)
        {
            _commentsRepository = commentsRepository;
            _usersRepository = userRepository;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var comments = await _commentsRepository.GetAll();
            return comments;
        }

        public async Task<Comment?> GetCommentById(int Id)
        {
            Comment? comment = await _commentsRepository.GetById(Id);
            try
            {
                comment.Author = await _usersRepository.GetById(comment.AuthorId);
            }
            catch (Exception)
            {
                throw;
            }
            return comment;
        }

        public async Task AddComment(Comment comment)
        {
            try
            {
                if (comment == null)
                {
                    throw new ArgumentNullException(nameof(comment));
                }
                else
                {
                    await _commentsRepository.Insert(comment);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateComment(Comment comment)
        {
            try
            {
                if (comment == null)
                {
                    throw new ArgumentNullException(nameof(comment));
                }
                else
                {
                    await _commentsRepository.Update(comment);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteComment(int id)
        {
            try
            {
                await _commentsRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
