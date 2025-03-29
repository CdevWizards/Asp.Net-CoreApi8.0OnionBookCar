using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery,
     List<GetTestimonialQueryResult>>
     {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetTestimonialQueryResult
            {
                 TestimonialID =x.TestimonialID,
                 Comment = x.Comment,
                     ImageUrl = x.ImageUrl,
                      Name = x.Name,
                     Title = x.Title,
            }).ToList();
        }
    }
}