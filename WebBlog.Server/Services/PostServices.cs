using Microsoft.AspNetCore.Mvc;
using WebBlog.Server.Extention;
using WebBlog.Server.Models.Model;
using WebBlog.Server.Models.VIewModel;
using WebBlog.Server.RepositoryModel;

namespace WebBlog.Server.Services
{
    public class PostServices
    {
        private readonly IRepositoryPost repositoryPost;
        public PostServices(IRepositoryPost repository)
        {
            repositoryPost = repository;
        }
        public async Task<PostViewModel> GetPostAsync(int id)
        {
            var post = await repositoryPost.GetPostById(id);
            return post.ToPostVeiwModel();
        }
        public async Task<List<PostViewModel>> GetAllPostsAsync()
        {
            var posts = await repositoryPost.GetAllPost();
            var postViewModels = new List<PostViewModel>();
            foreach (var post in posts) 
            {
                var postViewModel = post.ToPostVeiwModel();
                postViewModels.Add(postViewModel);
            }
            return postViewModels;
        }
        public async Task<PostViewModel> CreatePsotAsync(PostViewModel postView)
        {
            await repositoryPost.CreatePost(postView.ToPost());
            return postView;
        }
        public async Task DeletePostAsync(int id)
        {
            await repositoryPost.DeletePost(id);
        }
        public async Task<PostViewModel> UpdatePostAsync(PostViewModel postView)
        {
            await repositoryPost.UpdatePost(postView.ToPost());
            return postView;
        }
    }
}
