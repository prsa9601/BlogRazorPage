﻿namespace BlogRazorPage.Infrastructure
{
    public class Directories
    {
        public const string ProductImages = "/images/products";
        public const string ArticleImages = "wwwroot/images/Article";

        public static string GetArticleImages(string imageName)=>  $"{ArticleImages.Replace("wwwroot","")}/{imageName}";
        
        public const string ProductGalleryImage = "/images/products/gallery";

        public const string BannerImages = "/images/banners";
        public const string SliderImages = "/images/sliders";

        public const string UserAvatars = "/images/users/avatar";


        public static string GetSliderImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";
        }
        public static string GetAvatar(string imageName)
        {
            return $"{SiteSettings.ServerPath}{UserAvatars}/{imageName}";
        }
        public static string GetProductImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{ProductImages}/{imageName}";
        }
        public static string GetProductImageGallery(string imageName)
        {
            return $"{SiteSettings.ServerPath}{ProductGalleryImage}/{imageName}";
        }
        public static string GetBannerImage(string imageName)
        {
            return $"{SiteSettings.ServerPath}{BannerImages}/{imageName}";
        }

        public static string GetSliderImages(string imageName)
        {
            return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";

        }
    }
}