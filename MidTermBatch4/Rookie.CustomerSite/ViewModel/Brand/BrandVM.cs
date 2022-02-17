using System.ComponentModel.DataAnnotations;

namespace Rookie.CustomerSite.ViewModel.Brand
{
    public class BrandVm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
