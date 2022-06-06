using System;
using System.Reflection;
using InventoryManager.Application.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManager.Application
{
	/// <summary>
    /// Clase para registrar el automapper y el MediatR en la injección de dependencia del .NET
    /// </summary>
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
		{
			// this let us add all the posibles profiles in the assembly (inherited from Profile)
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			// this let us add all the handlers and request for the mediator
			services.AddMediatR(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}