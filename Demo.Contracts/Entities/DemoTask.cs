using System.ComponentModel.DataAnnotations;

namespace Demo.Contracts.Entities
{
    public class DemoTask
    {

        #region Properties

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsCompleted { get; set; }

        public virtual List<Step>? Steps { get; set; }

        #endregion
    }
}
