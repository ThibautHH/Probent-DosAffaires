/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbentDosAffaires.Data
{
    public partial class DocumentAffaireDosimétrique
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(500)]
        public string Fichier { get; set; } = null!;
        public int AffaireDosimétriqueId { get; set; }

        [ForeignKey("AffaireDosimétriqueId")]
        [InverseProperty("DocumentsAffairesDosimétriques")]
        public virtual AffaireDosimétrique AffaireDosimétrique { get; set; } = null!;
    }
}
