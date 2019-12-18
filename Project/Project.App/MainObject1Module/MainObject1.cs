using System;
using FluentValidation;

namespace Project.App.MainObject1Module
{
    public class MainObject1
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }

    public class MainObject1Validator : AbstractValidator<MainObject1>
    {
        public MainObject1Validator()
        {
            RuleFor(x => x.Id)
                .NotEqual(default(Guid));
            RuleFor(x => x.Message)
                .NotNull();
            RuleFor(x => x.Created)
                .NotNull();
        }
    }
}