


using GesEtu.Repository;
using GesEtu.Repository.Impl;
using GesEtu.Services;
using GesEtu.Services.Impl;
using GesEtu.Views;
using Microsoft.Extensions.DependencyInjection;

var ioc = new ServiceCollection();
ioc.AddSingleton<IEtudiantRepository, EtudiantRepositoryImpl>();
ioc.AddSingleton<IEtudiantService, EtudiantServiceImpl>();
ioc.AddTransient<ConsoleView>();
var services = ioc.BuildServiceProvider();
var view = services.GetRequiredService<ConsoleView>();
view.Run();
