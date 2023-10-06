namespace web_site_Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        IPostCategoryRepository PostCategory { get; }
        IPostRepository Post { get; }

        IRentRepository Rent { get; }
        IRealEstateRepository RealEstate { get; }
        IDesignRepository Design { get; }

        IResidentialComplexRepository ResidentialComplex { get; }
        ILocationRepository Location { get; }
        ICommentRepository Comment { get; }
        ILikeRepository Like { get; }
        ISubscriptionRepository Subscription { get; }
        IImageUrlRepository ImageUrl { get; }

        IProjectRepository Project { get; }

    }
}
