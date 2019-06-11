using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhonebookAPI.Context;
using PhonebookAPI.Models;

namespace PhonebookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Phone, PhoneItem>()
                    .ForMember("Place", opt => opt.MapFrom(c => c.Place.Name));
            });

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
