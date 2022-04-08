/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbentDosAffaires.Data
{
    public partial class Exposition
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Key]
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [Key]
        [StringLength(50)]
        public string Prénom { get; set; } = null!;
        [Column(TypeName = "decimal(7, 4)")]
        public decimal Dose { get; set; }
        public bool Validée { get; set; }
        public int AffaireDosimétriqueId { get; set; }

        [ForeignKey("AffaireDosimétriqueId")]
        [InverseProperty("Expositions")]
        public virtual AffaireDosimétrique AffaireDosimétrique { get; set; } = null!;
    }
}
