// IEmployeeRepository.cs: Copyright (c) Santosh Kumar Janapala. All rights Reserved

using System.Collections.Generic;
using System.Threading.Tasks;
using DemoAsyncAwait.Models;

namespace DemoAsyncAwait.Interfaces
{
    /// <summary>
    /// Interface for Employee Repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets the Employees by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>Task IEnumerable EmployeeModel</returns>
        Task<IEnumerable<EmployeeModel>> GetEmployees(EmployeeModel employeeModel);

        /// <summary>
        /// Gets the Employee by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>Task EmployeeModel</returns>
        /// 
        Task<EmployeeModel> GetEmployee(EmployeeModel employeeModel);

    }
}
