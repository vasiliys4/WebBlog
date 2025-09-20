using WebBlog.Server.Models.IdentityModel;
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
                id = model.PostId,
                text = content.TextPost,
                name = model.Title,
                imgPath = content.ImagePath
            };
        }
        public static Post ToPost(this PostViewModel model)
        {
            var content = new ContentPost 
            {
                ImagePath = model.imgPath,
                TextPost = model.text
            };
            return new Post
            {
                PostId = model.id,
                Title = model.name,
                Content = content,
            };
        }
        
    }
}
