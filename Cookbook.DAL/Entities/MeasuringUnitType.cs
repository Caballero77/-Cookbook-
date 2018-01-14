namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    public class MeasuringUnitType: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<MeasuringUnit> MeasuringUnits { get; set; }
    }
}