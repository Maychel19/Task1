using System.ComponentModel.DataAnnotations;

namespace StudyCaseAGIT.Models
{
    public class ProductionPlan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Produksi hari Senin harus diisi.")]
        public int Monday { get; set; }

        [Required(ErrorMessage = "Produksi hari Selasa harus diisi.")]
        public int Tuesday { get; set; }

        [Required(ErrorMessage = "Produksi hari Rabu harus diisi.")]
        public int Wednesday { get; set; }

        [Required(ErrorMessage = "Produksi hari Kamis harus diisi.")]
        public int Thursday { get; set; }

        [Required(ErrorMessage = "Produksi hari Jumat harus diisi.")]
        public int Friday { get; set; }


        [Required(ErrorMessage = "Tanggal perencanaan harus diisi.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(ProductionPlan), nameof(ValidatePlanDate))]
        public DateTime PlanDate { get; set; }


        public static ValidationResult ValidatePlanDate(DateTime planDate, ValidationContext context)
        {
            if (planDate < DateTime.Today)
            {
                return new ValidationResult("Tanggal perencanaan tidak boleh di masa lalu.");
            }
            return ValidationResult.Success;
        }
    }
}
