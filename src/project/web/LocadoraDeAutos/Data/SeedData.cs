using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LocadoraDeAutos.Models;

namespace LocadoraDeAutos.Data
{
    public static class SeedData
    {
        public static void Initialize(LocadoraDeAutosContext context)
        {
            if (!context.Carro.Any())
            {
                context.Carro.AddRange(
                    new CarroViewModel
                    {
                        Nome = "Carro 1",
                        Modelo = "Modelo 1",
                        Marca = "Marca 1",
                        Preco = 60.90m
                    },
                    new CarroViewModel
                    {
                        Nome = "Carro 2",
                        Modelo = "Modelo 2",
                        Marca = "Marca 2",
                        Preco = 60.90m
                    }
                );

                context.SaveChanges();
            }
        }
    }
}