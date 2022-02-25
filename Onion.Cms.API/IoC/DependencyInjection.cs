using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Cms.ApplicationServices.Arrangements.Command;
using Onion.Cms.ApplicationServices.Arrangements.Queries;
using Onion.Cms.ApplicationServices.Basket.Command;
using Onion.Cms.ApplicationServices.Basket.Queries;
using Onion.Cms.ApplicationServices.Blogs.Commands;
using Onion.Cms.ApplicationServices.Blogs.Queries.Posts;
using Onion.Cms.ApplicationServices.Convertors;
using Onion.Cms.ApplicationServices.Notifications.Commands;
using Onion.Cms.ApplicationServices.Notifications.Queries;
using Onion.Cms.ApplicationServices.Orders.Command;
using Onion.Cms.ApplicationServices.Orders.Queries;
using Onion.Cms.ApplicationServices.Payments.Command;
using Onion.Cms.ApplicationServices.Products.Command.Brands;
using Onion.Cms.ApplicationServices.Products.Command.Categories;
using Onion.Cms.ApplicationServices.Products.Command.Products;
using Onion.Cms.ApplicationServices.Products.Queries.Brands;
using Onion.Cms.ApplicationServices.Products.Queries.Categories;
using Onion.Cms.ApplicationServices.Products.Queries.Products;
using Onion.Cms.ApplicationServices.Services;
using Onion.Cms.ApplicationServices.Services.Interface;
using Onion.Cms.ApplicationServices.Slider.Command;
using Onion.Cms.ApplicationServices.Slider.Queries;
using Onion.Cms.ApplicationServices.Stores.Command;
using Onion.Cms.ApplicationServices.Stores.Queries;
using Onion.Cms.ApplicationServices.User.Command;
using Onion.Cms.ApplicationServices.User.Queries;
using Onion.Cms.ApplicationServices.User.Queries.UserAdress;
using Onion.Cms.Core.Convertors.Interfaces;
using Onion.Cms.Core.Services;
using Onion.Cms.DAL.Arrangements.Repositories;
using Onion.Cms.DAL.Basket.Repositories;
using Onion.Cms.DAL.Blogs.Repositories;
using Onion.Cms.DAL.Context;
using Onion.Cms.DAL.Context.UOW;
using Onion.Cms.DAL.Orders.Repositories;
using Onion.Cms.DAL.Payments.Repositories;
using Onion.Cms.DAL.Product.Repositories.Brands;
using Onion.Cms.DAL.Product.Repositories.Categories;
using Onion.Cms.DAL.Product.Repositories.Products;
using Onion.Cms.DAL.Slider.Repositories;
using Onion.Cms.DAL.Stores.Repositories;
using Onion.Cms.DAL.User.Repositories;
using Onion.Cms.Domain.Arrangements.Commands;
using Onion.Cms.Domain.Arrangements.Dtos;
using Onion.Cms.Domain.Arrangements.Queries;
using Onion.Cms.Domain.Arrangements.Repositories;
using Onion.Cms.Domain.Basket.Commands;
using Onion.Cms.Domain.Basket.Dtos;
using Onion.Cms.Domain.Basket.Queries;
using Onion.Cms.Domain.Basket.Repositories;
using Onion.Cms.Domain.Blogs.Commands.PostCategories;
using Onion.Cms.Domain.Blogs.Commands.Posts;
using Onion.Cms.Domain.Blogs.Dtos;
using Onion.Cms.Domain.Blogs.Queries.PostCategories;
using Onion.Cms.Domain.Blogs.Queries.Posts;
using Onion.Cms.Domain.Blogs.Repositories;
using Onion.Cms.Domain.DTOs;
using Onion.Cms.Domain.DTOs.Site.Products;
using Onion.Cms.Domain.Notifications.Commands;
using Onion.Cms.Domain.Notifications.Dtos;
using Onion.Cms.Domain.Notifications.Queries;
using Onion.Cms.Domain.Notifications.Repositories;
using Onion.Cms.Domain.Orders.Commands;
using Onion.Cms.Domain.Orders.Dtos;
using Onion.Cms.Domain.Orders.Queries;
using Onion.Cms.Domain.Orders.Repositories;
using Onion.Cms.Domain.Payments.Commands;
using Onion.Cms.Domain.Payments.Repositories;
using Onion.Cms.Domain.Product.Commands.Brands;
using Onion.Cms.Domain.Product.Commands.Categories;
using Onion.Cms.Domain.Product.Commands.Products;
using Onion.Cms.Domain.Product.Dtos.Brands;
using Onion.Cms.Domain.Product.Dtos.Categories;
using Onion.Cms.Domain.Product.Dtos.Product;
using Onion.Cms.Domain.Product.Queries.Brands;
using Onion.Cms.Domain.Product.Queries.Categories;
using Onion.Cms.Domain.Product.Queries.Products;
using Onion.Cms.Domain.Product.Repositories.Brands;
using Onion.Cms.Domain.Product.Repositories.Categories;
using Onion.Cms.Domain.Product.Repositories.Products;
using Onion.Cms.Domain.SeedWork;
using Onion.Cms.Domain.Slider.Commands;
using Onion.Cms.Domain.Slider.Dtos;
using Onion.Cms.Domain.Slider.Queries;
using Onion.Cms.Domain.Slider.Repositories;
using Onion.Cms.Domain.Stores.Commands;
using Onion.Cms.Domain.Stores.Dtos;
using Onion.Cms.Domain.Stores.Queries;
using Onion.Cms.Domain.Stores.Repositories;
using Onion.Cms.Domain.User.Commands;
using Onion.Cms.Domain.User.Dtos;
using Onion.Cms.Domain.User.Dtos.UserAddresses;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Domain.User.Queries;
using Onion.Cms.Domain.User.Repositories;
using Onion.Cms.Framework.Commands;
using Onion.Cms.Framework.Common.File;
using Onion.Cms.Framework.Common.Interfaces;
using Onion.Cms.Framework.Dtos;
using Onion.Cms.Framework.Queries;
using Onion.Cms.Framework.Resources;
using Onion.Cms.Framework.Resources.Interface;
using Onion.Cms.Resources.Resources;

namespace Onion.Cms.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoc(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mailAddress = configuration.GetValue<string>("EmailInfo:MailAddress");
            var mailPassword = configuration.GetValue<string>("EmailInfo:MailPassword");

            services.AddScoped<CommandDispatcher>();
            services.AddScoped<QueryDispatcher>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityDefaultCnn"),
                    builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));


            services.AddScoped<IEmailService>(provider => new EmailService(mailAddress, mailPassword));

            services.AddScoped<IResourceManager, ResourceManager<SharedResource>>();
            //services.AddScoped<IViewRenderService, RenderViewToString>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IFileHandler, FileHandler>();
            services.AddScoped<IMenuService, MenuService>();

            #region Repository

            services.AddScoped<IApplicationUserInfoCommandRepository, ApplicationUserInfoCommandRepository>();
            services.AddScoped<IBrandsCommandRepository, BrandsCommandRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IArrangementRepository, ArrangementsRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
            #endregion

            #region MediatR

            #region User
            services.AddScoped<IRequestHandler<AddApplicationUserInfoCommand, ResultDto>, UserInfoCommandHandler>();
            services.AddScoped<IRequestHandler<GetApplicationUserInfoQuery, ApplicationUserInfoDto>, UserInfoQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserAddressQueries, List<UserAddressDto>>, UserAddressQueryHandler>();

            services.AddScoped<IRequestHandler<GetZoneQueries, IReadOnlyList<DropDownDto>>, UserAddressQueryHandler>();
            services.AddScoped<IRequestHandler<GetProvinceQueries, IReadOnlyList<DropDownDto>>, UserAddressQueryHandler>();
            services.AddScoped<IRequestHandler<GetDistrictQueries, IReadOnlyList<DropDownDto>>, UserAddressQueryHandler>();

            #endregion

            #region UserAddress
            services.AddScoped<IRequestHandler<AddUserAddressCommand, ResultDto>, UserAddressCommandHandler>();

            services.AddScoped<IRequestHandler<DeleteUserAddressCommand, ResultDto>, UserAddressCommandHandler>();



            #endregion

            #region Slider

            //Command
            services.AddScoped<IRequestHandler<AddSliderCommand, ResultDto>, SliderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSliderCommand, ResultDto>, SliderCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteSliderCommand, ResultDto>, SliderCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<SliderQueries, IReadOnlyList<SliderDto>>, SliderQueryHandler>();
            services.AddScoped<IRequestHandler<SliderByIdQueries, ResultDto<SliderDto>>, SliderQueryHandler>();
            services.AddScoped<IRequestHandler<SliderPaginationQueries, QueryList<SliderDto>>, SliderQueryHandler>();

            #endregion

            #region Arrangement

            //Command
            services.AddScoped<IRequestHandler<AddArrangementCommand, ResultDto>, ArrangementCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteArrangementCommand, ResultDto>, ArrangementCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateArrangementCommand, ResultDto>, ArrangementCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<ArrangementsQueries, IReadOnlyList<ArrangementGetDto>>, ArrangementsQueryHandler>();
            services.AddScoped<IRequestHandler<ArrangementByIdQueries, ResultDto<ArrangementGetDto>>, ArrangementsQueryHandler>();
            services.AddScoped<IRequestHandler<ArrangementsPaginationQueries, QueryList<ArrangementGetDto>>, ArrangementsQueryHandler>();


            #endregion

            #region Store

            //Command
            services.AddScoped<IRequestHandler<StoreCreateCommand, ResultDto>, StoreCommandHandler>();
            services.AddScoped<IRequestHandler<StoreUpdateCommand, ResultDto>, StoreCommandHandler>();
            services.AddScoped<IRequestHandler<StoreUpdateCommand, ResultDto>, StoreCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<StoreQuery, IReadOnlyList<StoreDto>>, StoreQueryHandler>();
            services.AddScoped<IRequestHandler<StorePaginationQuery, QueryList<StoreDto>>, StoreQueryHandler>();
            services.AddScoped<IRequestHandler<StoreGetByIdQuery, ResultDto<StoreDto>>, StoreQueryHandler>();
            services.AddScoped<IRequestHandler<StoreGetByCodeQuery, ResultDto<StoreDto>>, StoreQueryHandler>();
            services.AddScoped<IRequestHandler<StoreGetByCodeQuery, ResultDto<StoreDto>>, StoreQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdminOrderQueries, QueryList<AdminOrderDto>>, AdminOrderQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdminOrderDetailsQueries, OrderDetailsAdminDto>, OrderQueryHandler>();


            #endregion

            #region Products

            #region Brand
            //Command
            services.AddScoped<IRequestHandler<BrandCreateCommand, ResultDto>, AddBrandHandler>();
            services.AddScoped<IRequestHandler<BrandUpdateCommand, ResultDto>, AddBrandHandler>();
            services.AddScoped<IRequestHandler<DeleteBrandByIdCommand, ResultDto>, AddBrandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetBrandQueries, IReadOnlyList<GetBrandDto>>, GetBrandQueryHandler>();
            services.AddScoped<IRequestHandler<GetBrandByIdQueries, GetBrandDto>, GetBrandQueryHandler>();

            #endregion

            #region Category
            //Queries
            services.AddScoped<IRequestHandler<GetCategoryQueries, IReadOnlyList<GetCategoryDto>>, CategoriesQueryHandler>();
            services.AddScoped<IRequestHandler<GetCategoryPaginationQueries, QueryList<GetCategoryDto>>, CategoriesQueryHandler>();
            services.AddScoped<IRequestHandler<GetCategoryByIdQueries, ResultDto<GetCategoryDto>>, CategoriesQueryHandler>();

            //Command
            services.AddScoped<IRequestHandler<CategoryCreateCommand, ResultDto>, AddCategoryHandler>();
            services.AddScoped<IRequestHandler<CategoryUpdateCommand, ResultDto>, AddCategoryHandler>();
            services.AddScoped<IRequestHandler<DeleteCategoryByIdCommand, ResultDto>, AddCategoryHandler>();
            #endregion

            #region Product

            //Command
            services.AddScoped<IRequestHandler<ProductsCreateCommand, ResultDto>, AddProductsHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, ResultDto>, AddProductsHandler>();
            services.AddScoped<IRequestHandler<ProductsUpdateCommand, ResultDto>, AddProductsHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetProductByIdQueries, ResultProductDetailsSiteDto>, ProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAdminProductByIdQueries, ProductDto>, ProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductQueries, ResultProductSiteDto>, ProductsQueryHandler>();

            #endregion


            #endregion

            #region Basket

            //Command
            services.AddScoped<IRequestHandler<AddCartCommand, ResultDto>, BasketCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFromCardCommand, ResultDto>, BasketCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCountCartCommand, ResultDto>, BasketCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetCardQueries, ResultDto<CartDto>>, BasketQueryHandler>();
            services.AddScoped<IRequestHandler<GetCardShippingQueries, ResultDto<CartPayDto>>, BasketQueryHandler>();
            services.AddScoped<IRequestHandler<GetCountItemQueries, ResultDto<int>>, BasketQueryHandler>();



            #endregion

            #region Notification
            //Command
            services.AddScoped<IRequestHandler<NotificationCreateCommand, ResultDto>, NotificationCommandHandler>();
            services.AddScoped<IRequestHandler<NotificationDeleteCommand, ResultDto>, NotificationCommandHandler>();
            services.AddScoped<IRequestHandler<NotificationClearCommand, ResultDto>, NotificationCommandHandler>();
            services.AddScoped<IRequestHandler<NotificationMarkAsReadCommand, ResultDto>, NotificationCommandHandler>();
            //Queries
            services.AddScoped<IRequestHandler<NotificationListQuery, QueryList<GetNotificationDto>>, NotificationQueryHandler>();
            services.AddScoped<IRequestHandler<NotificationQueries, IReadOnlyList<GetNotificationDto>>, NotificationQueryHandler>();
            services.AddScoped<IRequestHandler<NotificationByIdQueries, ResultDto<GetNotificationDto>>, NotificationQueryHandler>();
            services.AddScoped<IRequestHandler<NotificationUnReadCountQueries, ResultDto<int>>, NotificationQueryHandler>();


            #endregion

            #region Blog
            #region Post
            //Queries
            services.AddScoped<IRequestHandler<PostGetByIdQuery, ResultDto<PostGetQueryDto>>, PostQueryHandler>();
            services.AddScoped<IRequestHandler<PostPaginationQueries, QueryList<PostListQueryDto>>, PostQueryHandler>();

            //Command
            services.AddScoped<IRequestHandler<PostCreateCommand, ResultDto>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<PostUpdateCommand, ResultDto>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<PostDeleteCommand, ResultDto>, PostCommandHandler>();
            #endregion
            #region PostCategory
            //Queries
            services.AddScoped<IRequestHandler<PostCategoryListQuery, QueryList<PostCategoryListQueryDto>>, PostCategoryQueryHandler>();
            services.AddScoped<IRequestHandler<PostCategoryGetByIdQuery, ResultDto<PostCategoryGetQueryDto>>, PostCategoryQueryHandler>();

            //Command
            services.AddScoped<IRequestHandler<PostCategoryCreateCommand, ResultDto>, PostCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<PostCategoryUpdateCommand, ResultDto>, PostCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<PostCategoryDeleteCommand, ResultDto>, PostCategoryCommandHandler>();
            #endregion
            #endregion

            #region Payment

            services.AddScoped<IRequestHandler<AddPaymentCommand, ResultDto>, PaymentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCartFinished, ResultDto>, OrderCommandHandler>();

            services.AddScoped<IRequestHandler<AddOrderCommand, ResultDto<OrderDto>>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<GetOrderByIdQueries, OrderDto>, OrderQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrderByUserIdQueries, QueryList<OrderDto>>, OrderQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrderDetailsQueries, QueryList<OrderDetailsDto>>, OrderQueryHandler>();


            #endregion
            //services.AddScoped<CreateUserInfoCommandValidator>();
            services.AddMediatR(typeof(Startup));
            #endregion

            #region Identity

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityError>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(7200);

                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion

            return services;
        }
    }
}
