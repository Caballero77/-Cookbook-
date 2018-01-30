namespace Cookbook.BLL.DataTransferObjects
{
    public class NutritionValueDTO
    {
        public string Name { get; set; }

        public double MeasuringUnitValue { get; set; }

        public string MeasuringUnit { get; set; }

        public int MeasuringUnitId { get; set; }

        public int Id { get; set; }
    }
}