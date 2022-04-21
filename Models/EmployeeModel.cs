// EmployeeModel.cs: Copyright (c) Santosh Kumar Janapala. All rights Reserved

using System;

namespace DemoAsyncAwait.Models
{
    /// <summary>
    /// Employee Model
    /// </summary>
    [Serializable]
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DateOfBirth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        public string Phone { get; set; }

    }
}
