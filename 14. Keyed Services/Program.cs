var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedSingleton<DITest, Test1>("1");
builder.Services.AddKeyedSingleton<DITest, Test2>("2");

var app = builder.Build();

interface DITest { }
class Test1 : DITest { }
class Test2 : DITest { }