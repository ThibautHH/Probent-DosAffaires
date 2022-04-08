/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbentDosAffaires.Data
{
    public partial class AffaireDosimétrique
    {
        public AffaireDosimétrique()
        {
            this.DocumentsAffairesDosimétriques = new HashSet<DocumentAffaireDosimétrique>();
            this.Expositions = new HashSet<Exposition>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Numéro { get; set; } = null!;
        [StringLength(150)]
        public string? Désignation { get; set; }
        public short? NombreAgents { get; set; }
        public int? TempsExposition { get; set; }
        [Column(TypeName = "decimal(7, 4)")]
        public decimal? DosimétriePrévue { get; set; }
        [NotMapped]
        public decimal DoseRéalisée
        {
            get
            {
                decimal doseRéalisée = decimal.Zero;
                foreach (Exposition exposition in this.Expositions)
                    doseRéalisée += exposition.Dose;
                return doseRéalisée;
            }
        }
        [StringLength(10)]
        public string? Notes { get; set; }

        [InverseProperty("AffaireDosimétrique")]
        public virtual ICollection<DocumentAffaireDosimétrique> DocumentsAffairesDosimétriques { get; set; }
        [InverseProperty("AffaireDosimétrique")]
        public virtual ICollection<Exposition> Expositions { get; set; }
    }
}
