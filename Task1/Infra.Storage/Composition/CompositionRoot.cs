using System.Reflection;
using Domain.Services;
using Infra.Storage.Adapter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infra.Storage.Composition;

public static class CompositionRoot
{
    public static WebApplicationBuilder AddDiscountCodeAdapter(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        builder.Services.TryAddTransient<IDiscountCodesAdapter, DiscountCodesAdapter>();
        builder.Services.TryAddSingleton<InMemoryDataBase>();
        builder.Services.TryAddSingleton<IDataBase, InMemoryDataBase>();
        return builder;
    }
}