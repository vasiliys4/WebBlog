using WebBlog.Server.Models.Model;
using WebBlog.Server.Models.VIewModel;

namespace WebBlog.Server.Extention
{
    public static class ServicesExtention
    {
        public static PostViewModel ToPostVeiwModel(this Post model)
        {
            var content = model.Content;

            return new PostViewModel
            {
                PostViewModelId = model.PostId,
                PostText = content.TextPost,
                PostTitle = model.Title,
                ImgPath = content.ImagePath
            };
        }
        public static Post ToPost(this PostViewModel model)
        {
            var content = new ContentPost 
            {
                ImagePath = model.ImgPath,
                TextPost = model.PostText
            };
            return new Post
            {
                PostId = model.PostViewModelId,
                Title = model.PostTitle,
                Content = content,
            };
        }
    }
}
