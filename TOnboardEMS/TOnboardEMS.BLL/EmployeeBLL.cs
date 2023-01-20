using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class EmployeeBLL
    {
        private readonly OnboardContext Context;
        public EmployeeBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<Employee> ViewAllEmployees()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<EmployeeRepository>().GetAll();
            }
        }

        public Employee ViewEmployeeById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<EmployeeRepository>().GetById(Id);
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<EmployeeRepository>().Add(employee);
                uow.Commit();

            }
        }

        public void UpdateEmployeeDetails(Employee employee)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<EmployeeRepository>().Update(employee);
                uow.Commit();
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<EmployeeRepository>().Delete(employee);
                uow.Commit();
            }
        }

        public void RemoveEmployeeById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                RoleRepository repository = uow.GetRepository<RoleRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }
        }
    }
}
