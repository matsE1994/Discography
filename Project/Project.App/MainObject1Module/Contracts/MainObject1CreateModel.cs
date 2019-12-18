using System;

namespace Project.App.MainObject1Module.Contracts
{
    public class MainObject1CreateModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}