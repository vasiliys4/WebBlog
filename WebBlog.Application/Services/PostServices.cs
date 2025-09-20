using WebBlog.Application.Interfaces;
using WebBlog.Server.Extention;
using WebBlog.Server.Models.VIewModel;

namespace WebBlog.Server.Services
{
    public class PostServices
    {
        private readonly IRepositoryPost repositoryPost;
        //private IWebHostEnvironment appEnvironment;
        public PostServices(IRepositoryPost repository) => repositoryPost = repository;
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
        public async Task<PostViewModel> CreatePostAsync(PostViewModel postView)
        {
            //FileInfo file = new FileInfo(postView.imgPath);
            //if (file != null)
            //{
            //    string path = "/images/post/" + file.Name;
            //    file.CopyTo(new FileStream(appEnvironment.WebRootPath + path, FileMode.Create));
            //}
            await repositoryPost.CreatePost(postView.ToPost());
            return postView;
        }
        public async Task DeletePostAsync(int id)
        {
            await repositoryPost.DeletePost(id);
        }
        public async Task<PostViewModel> UpdatePostAsync(PostViewModel postView, int id)
        {
            await repositoryPost.UpdatePost(postView.ToPost(), id);
            return postView;
        }
    }
}
