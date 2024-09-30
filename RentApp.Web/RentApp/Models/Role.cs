using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public enum Role
    {
        User = 0,
		Admin = 1,
		SuperAdmin = 2,
        Developer = 3
    }
}
