﻿using WebBlog.Server.Models.Model;

namespace WebBlog.Server.RepositoryModel
{
    public interface IRepositoryPost
    {
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task<Post> DeletePost(Post post);
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetAllPost();
    }
}
