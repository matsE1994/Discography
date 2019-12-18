using System;
using FluentValidation;

namespace Project.App.MainObject1Module.Contracts
{
    public class MainObject1CreateModel
    {
        public Guid? Id { get; set; }
        public string? Message { get; set; }
    }
    
    public class MainObject1CreateModelValidator : AbstractValidator<MainObject1CreateModel>
    {
        public MainObject1CreateModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(default(Guid));
            RuleFor(x => x.Message)
                .NotNull().NotEmpty();
        }
    }
}