using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Notes.Application
{
	public static class DependencyIngection
	{
		public static IServiceCollection AddAplication(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
