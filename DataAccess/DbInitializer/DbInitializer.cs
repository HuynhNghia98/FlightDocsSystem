using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlightDocsSystem.DataAccess.Data;
using FlightDocsSystem.DataAccess.Repository.IRepository;
using FlightDocsSystem.Models;
using FlightDocsSystem.Utilities;

namespace FlightDocsSystem.DataAccess.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_unitOfWork = unitOfWork;
		}

		public void Initializer()
		{
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}
			}
			catch (Exception ex) { }

			//Tạo Role nếu không có
			if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Pilot)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Crew)).GetAwaiter().GetResult();

				//Tạo tài khoản admin
				var newUser = new ApplicationUser
				{
					UserName = "admin",
					Email = "nghiaht0412@gmail.com",
					FullName = "Nghia",
					PhoneNumber = "0123456789",
					IsAdmin = true,
				};

				_userManager.CreateAsync(newUser, "123").GetAwaiter().GetResult();

				var user = _db.ApplicationUsers.FirstOrDefault(x => x.Id == newUser.Id);
				_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

				//Tạo category
				Category newCategory = new()
				{
					Name = "Loại chuyến bay 1",
					Details = ""
				};
				_unitOfWork.Category.Add(newCategory);
				_unitOfWork.Save();
			}
			return;
		}
	}
}
