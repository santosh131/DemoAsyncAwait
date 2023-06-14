// EmployeeRepository.cs: Copyright (c) Santosh Kumar Janapala. All rights Reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAsyncAwait.Interfaces;
using DemoAsyncAwait.Models;

namespace DemoAsyncAwait.Concrete
{
    /// <summary>
    /// Concrete class for IEmployeeRepository
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Private Properties

        /// <summary>
        /// Gets (property) Employees
        /// </summary>
        private List<EmployeeModel> Employees
        {
            get
            {
                return new List<EmployeeModel>()
                {
                    new EmployeeModel(){ Id=1, Name="Sam", Address="111 St", DateOfBirth=new DateTime(2000,1,1), Phone="124132861"},
                    new EmployeeModel(){ Id=2, Name="Time", Address="124 st", DateOfBirth=new DateTime(1985,1,1), Phone="2188841321"},
                };
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the Employee by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>Task EmployeeModel </returns>
        public async Task<EmployeeModel> GetEmployeeAsync(EmployeeModel employeeModel)
        {
            return await Task.Run(() => { return Employees.Where(e => e.Id.Equals(employeeModel.Id)).FirstOrDefault(); });
            //return Task.FromResult(Employees.Where(e => e.Id.Equals(employeeModel.Id)).FirstOrDefault());
        }

        /// <summary>
        /// Gets the Employees by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>Task IEnumerable EmployeeModel</returns>
        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(EmployeeModel employeeModel)
        {
            return await Task.Run(() => { return Employees.Where(e => e.Id.Equals(employeeModel.Id)); });
            //return Task.FromResult(Employees.Where(e => e.Id.Equals(employeeModel.Id)));
        }

        #endregion
    }
}
