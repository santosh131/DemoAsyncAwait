// EmployeeController.cs: Copyright (c) Santosh Kumar Janapala. All rights Reserved

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAsyncAwait.Interfaces;
using DemoAsyncAwait.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAsyncAwait.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Private Varaibles
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for EmployeeController
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Employees by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>Task IEnumerable EmployeeModel></returns>
        [HttpGet]
        [Route("GetEmployeesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEmployeesAsync([FromQuery] EmployeeModel employeeModel)
        {
            if (IsEmployeeValid(employeeModel))
                return BadRequest();
            else
                return Ok((await _employeeRepository.GetEmployeesAsync(employeeModel).ConfigureAwait(false)).AsEnumerable());
        }

        /// <summary>
        /// Gets the Employee by EmployeeModel
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>EmployeeModel</returns>
        [HttpGet]
        [Route("GetEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEmployeeAsync([FromQuery] EmployeeModel employeeModel)
        {
            if (IsEmployeeValid(employeeModel))
                return BadRequest();
            else
                return await GetEmployeeDataAsync(employeeModel).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the Employee by Id
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns>EmployeeModel</returns>
        [HttpGet]
        [Route("GetEmployeeByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeByIdAsync(int? id)
        {
            EmployeeModel employeeModel = new EmployeeModel { Id = id };
            if (IsEmployeeValid(employeeModel))
                return BadRequest();
            else
                return Ok(await GetEmployeeDataAsync(employeeModel).ConfigureAwait(false));
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if the Employee is valid
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>bool</returns>
        private static bool IsEmployeeValid(EmployeeModel employeeModel)
        {
            return !employeeModel.Id.HasValue || employeeModel.Id.Value < 1;
        }

        /// <summary>
        /// Gets the Employee data
        /// </summary>
        /// <param name="employeeModel">EmployeeModel</param>
        /// <returns>EmployeeModel</returns>
        private async Task<IActionResult> GetEmployeeDataAsync(EmployeeModel employeeModel)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeModel).ConfigureAwait(false);
            if (employee == null)
                return NotFound("Employee is not found");
            else
                return Ok(employee);
        }
        #endregion

    }
}
