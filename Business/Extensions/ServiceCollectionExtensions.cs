using Business.Abstract;
using Business.Concrete.EntityManagers;
using Business.UOW.Abstract;
using Business.UOW.Concrete;
using DataAccess.Concrete.EfCore.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IBirimKartService, BirimKartManager>();
            serviceCollection.AddScoped<ICariKartService, CariKartManager>();
            serviceCollection.AddScoped<IDepartmanKartService, DepartmanKartManager>();
            serviceCollection.AddScoped<IKasaKartService, KasaKartManager>();
            serviceCollection.AddScoped<IKasaVirmanService, KasaVirmanManager>();
            serviceCollection.AddScoped<IMaasAvansDekontService, MaasAvansDekontManager>();
            serviceCollection.AddScoped<IMasrafDekontService, MasrafDekontManager>();
            serviceCollection.AddScoped<IMasrafKartService, MasrafKartManager>();
            serviceCollection.AddScoped<IPersonelKartService, PersonelKartManager>();
            serviceCollection.AddScoped<ITahsilDekontService, TahsilDekontManager>();
            serviceCollection.AddScoped<ITediyeDekontService, TediyeDekontManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();

            return serviceCollection;
        }
    }
}
