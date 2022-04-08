/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.ComponentModel.DataAnnotations;

namespace ProbentDosAffaires.Data
{
    public partial class Intervenant
    {
        [Key]
        public int SalariéId { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(50)]
        public string Prénom { get; set; } = null!;
        public int? FillialeId { get; set; }
    }
}
