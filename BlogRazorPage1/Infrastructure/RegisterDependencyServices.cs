using BlogRazorPage.Infrastructure.CookieUtils;
using BlogRazorPage.Infrastructure.FileUtil.Interfaces;
using BlogRazorPage.Infrastructure.FileUtil.Services;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Services.Auth;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Comment;
using BlogRazorPage.Services.Post;
using BlogRazorPage.Services.Role;
using BlogRazorPage.Services.User;

namespace BlogRazorPage.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        var baseAddress = "http://localhost:5001/api/";

        services.AddHttpContextAccessor();

        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();
        services.AddTransient<IFileService, FileService>();

        services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
        //services.AddScoped<IMainPageService, MainPageService>();

        services.AddScoped<ShopCartCookieManager>();

        services.AddCookieManager();

        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<ITransactionService, TransactionService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


        //services.AddHttpClient<IShippingMethodService, ShippingMethodService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<IBannerService, BannerService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICommentService, CommentService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<IOrderService, OrderService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IPostService, PostService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IRoleService, RoleService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<ISellerService, SellerService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<ISliderService, SliderService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        //services.AddHttpClient<IUserAddressService, UserAddressService>(httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(baseAddress);
        //}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IUserService, UserService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


        return services;
    }
}


