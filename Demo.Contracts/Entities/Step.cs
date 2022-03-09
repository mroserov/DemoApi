using System.ComponentModel.DataAnnotations;

namespace Demo.Contracts.Entities
{
    public class Step
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int DemoTaskId { get; set; }

        public virtual DemoTask? DemoTask { get; set; }

        #endregion

    }
}