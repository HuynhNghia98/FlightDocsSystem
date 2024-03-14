using FlightDocsSystem.Models;

namespace FlightDocsSystem.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
	}
}
