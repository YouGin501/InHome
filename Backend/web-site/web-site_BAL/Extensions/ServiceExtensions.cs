using Microsoft.Extensions.DependencyInjection;
using web_site_BAL.Contracts;
using web_site_BAL.Services;
using web_site_DAL.Repositories;
using web_site_Domain.Interfaces;

namespace web_site_BAL.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IDesignRepository), typeof(DesignRepository));
            services.AddScoped(typeof(IImageUrlRepository), typeof(ImageUrlRepository));
            services.AddScoped(typeof(ILikeRepository), typeof(LikeRepository));
            services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
            services.AddScoped(
                typeof(IPostCategoryRepository),
                typeof(PostCategoryRepository)
            );
            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
            services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
            services.AddScoped(typeof(IRealEstateRepository), typeof(RealEstateRepository));
            services.AddScoped(typeof(IRentRepository), typeof(RentRepository));
            services.AddScoped(
                typeof(IResidentialComplexRepository),
                typeof(ResidentialComplexRepository)
            );
            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(
                typeof(ISubscriptionRepository),
                typeof(SubscriptionRepository)
            );
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAzureBlobStorage, AzureBlobService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IDesignService, DesignService>();
            services.AddTransient<IRentService, RentService>();
            services.AddTransient<IRealEstateService, RealEstateService>();
            services.AddTransient<IResidentialComplexService, ResidentialComplexService>();

            services.AddScoped<CommentService>();
            services.AddScoped<LikeService>();
            services.AddScoped<LocationService>();
            services.AddScoped<PostCategoryService>();
            services.AddScoped<SubscriptionService>();
            services.AddScoped<ProjectService>();
        }
    }
}
