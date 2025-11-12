


using GesEtu.Repository;
using GesEtu.Repository.Impl;
using GesEtu.Services;
using GesEtu.Services.Impl;
using GesEtu.Views;
using Microsoft.Extensions.DependencyInjection;

var ioc = new ServiceCollection();

// Déclaration des dépendances
ioc.AddSingleton<IEtudiantRepository, EtudiantRepositoryImpl>();
ioc.AddSingleton<IEtudiantService, EtudiantServiceImpl>();

// Vue Console
ioc.AddTransient<ConsoleView>();

// Construction du conteneur de services
var services = ioc.BuildServiceProvider();

// Exécution du programme
var view = services.GetRequiredService<ConsoleView>();
view.Run();
