using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Models.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync
                (d => d.DepartmentId == departmentId);

        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return  await appDbContext.Departments.ToListAsync();
        }
    }
}
