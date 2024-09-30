using RentApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RentApp.Helpers
{
	public static class EnumExtensions
	{
		public static string GetFriendlyName(this Role role)
		{
			switch (role)
			{
				case Role.User:
					return "Kullanıcı";
				case Role.Admin:
					return "Ev Sahibi";
				case Role.SuperAdmin:
					return "Ortak";
				case Role.Developer:
					return "Geliştirici";
				default:
					return role.ToString();
			}
		}
	}
}
