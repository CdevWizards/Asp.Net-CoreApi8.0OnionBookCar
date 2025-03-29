

using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.CarRepositories;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;
using UpdateFeatureCommandHandler = UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers.UpdateFeatureCommandHandler;
using UdemyCarBook.Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Locations.Mediator.Handlers.LocationHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers;
using UdemyCarBook.Application.Pricings.Mediator.Handlers.PricingHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers;
using UdemyCarBook.Application.Services.Mediator.Handlers.ServiceHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;
using UdemyCarBook.Application.SocialMedias.Mediator.Handlers.SocialMediaHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;
using UdemyCarBook.Application.Testimonials.Mediator.Handlers.TestimonialHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;
using UdemyCarBook.Application.Authors.Mediator.Handlers.AuthorHandlers;
using UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;
using UdemyCarBook.Application.Blogs.Mediator.Handlers.BlogHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyBlogBook.Application.Features.Mediator.Handlers.BlogHandlers;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Application.Interfaces.CarPricingRepository;
using UdemyCarBook.Persistence.Repositories.CarPricingRepositories;
using UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Persistence.Repositories.TagCloudRepositories;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Repositories.StatisticsRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository),typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));


builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreatAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarPricingQueryHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();



builder.Services.AddScoped<GetFeatureQueryHandler>();
builder.Services.AddScoped<GetFeatureByIdQueryHandler>();
builder.Services.AddScoped<CreateFeatureCommandHandler>();
builder.Services.AddScoped<RemoveFeatureCommandHandler>();
builder.Services.AddScoped<UpdateFeatureCommandHandler>();

builder.Services.AddScoped<GetFooterAddressQueryHandler>();
builder.Services.AddScoped<GetFooterAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateFooterAddressCommandHandler>();
builder.Services.AddScoped<RemoveFooterAddressCommandHandler>();
builder.Services.AddScoped<UpdateFooterAddressCommandHandler>();

builder.Services.AddScoped<GetLocationQueryHandler>();
builder.Services.AddScoped<GetLocationByIdQueryHandler>();
builder.Services.AddScoped<CreateLocationCommandHandler>();
builder.Services.AddScoped<RemoveLocationCommandHandler>();
builder.Services.AddScoped<UpdateLocationCommandHandler>();

builder.Services.AddScoped<GetPricingQueryHandler>();
builder.Services.AddScoped<GetPricingByIdQueryHandler>();
builder.Services.AddScoped<CreatePricingCommandHandler>();
builder.Services.AddScoped<RemovePricingCommandHandler>();
builder.Services.AddScoped<UpdatePricingCommandHandler>();

builder.Services.AddScoped<GetServiceQueryHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();

builder.Services.AddScoped<GetSocialMediaQueryHandler>();
builder.Services.AddScoped<GetSocialMediaByIdQueryHandler>();
builder.Services.AddScoped<CreateSocialMediaCommandHandler>();
builder.Services.AddScoped<RemoveSocialMediaCommandHandler>();
builder.Services.AddScoped<UpdateSocialMediaCommandHandler>();

builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();

builder.Services.AddScoped<GetAuthorQueryHandler>();
builder.Services.AddScoped<GetAuthorByIdQueryHandler>();
builder.Services.AddScoped<CreateAuthorCommandHandler>();
builder.Services.AddScoped<RemoveAuthorCommandHandler>();
builder.Services.AddScoped<UpdateAuthorCommandHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetBlogQueryHandler>();
builder.Services.AddScoped<GetBlogByIdQueryHandler>();
builder.Services.AddScoped<CreateBlogCommandHandler>();
builder.Services.AddScoped<RemoveBlogCommandHandler>();
builder.Services.AddScoped<UpdateBlogCommandHandler>();
builder.Services.AddScoped<GetLast3BlogsWithAuthorsQueryHandler>();

builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger Middleware'ini ekliyoruz.
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UdemyCarBook API V1");
        c.RoutePrefix = string.Empty; // Swagger UI ana kökte çalışsın
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
