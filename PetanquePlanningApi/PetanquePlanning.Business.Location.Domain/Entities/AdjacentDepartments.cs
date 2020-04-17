using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class AdjacentDepartments : EntityWithCompositeId, IEntityWithCompositeId
    {
        /// <summary>
        /// First adjacent department
        /// </summary>
        public Department FirstDepartment { get; set; }

        /// <summary>
        /// Second adjacent department
        /// </summary>
        public Department SecondDepartment { get; set; }

        /// <summary>
        /// First department id
        /// </summary>
        public long FirstDepartmentId { get; set; }

        /// <summary>
        /// Second department id
        /// </summary>
        public long SecondDepartmentId { get; set; }
    }
}