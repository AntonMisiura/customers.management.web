using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IDepartmentService
    {
        /// <summary>
        /// add department
        /// </summary>
        /// <param name="department"></param>
        void AddDepartment(Department department);

        /// <summary>
        /// edit department
        /// </summary>
        /// <param name="department"></param>
        void EditDepartment(Department department);

        /// <summary>
        /// delete department
        /// </summary>
        /// <param name="id"></param>
        void DeleteDepartment(int id);
    }
}
