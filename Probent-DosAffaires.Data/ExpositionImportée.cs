/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbentDosAffaires.Data
{
    public partial class ExpositionImportée
    {
        [Key]
        [StringLength(50)]
        public string Intervenant { get; set; } = null!;
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(7, 4)")]
        public decimal Dose { get; set; }
    }
}
