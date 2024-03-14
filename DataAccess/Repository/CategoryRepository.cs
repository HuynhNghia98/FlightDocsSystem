using FlightDocsSystem.DataAccess.Data;
using FlightDocsSystem.DataAccess.Repository.IRepository;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
		}

		public void Update(Category category)
		{
			_db.Update(category);
		}
	}
}
