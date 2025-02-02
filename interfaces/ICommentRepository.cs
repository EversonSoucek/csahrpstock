using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.models;

namespace api.interfaces
{
    public interface ICommentRepository
    {
        Task<List<CommentDto>> GetAllSync();
        Task<Comment?> GetByIdSync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commentModel);
        Task<Comment?> DeleteAsync (int id);
    }
}