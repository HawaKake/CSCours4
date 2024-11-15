using System.ComponentModel.DataAnnotations;

namespace Cours.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom doit avoir au moins 5 caractères et inférieur à 20 caractères")]
    public string Nom { get; set; }
    [Required(ErrorMessage = "Le prenom est obligatoire")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Le prenom doit avoir au moins 5 caractères et inférieur à 40 caractères")]
    public string Prenom { get; set; }

    [Required(ErrorMessage = "Le login est obligatoire")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Le login doit avoir au moins 5 caractères et inférieur à 40 caractères")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Le password est obligatoire")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Le login doit avoir au moins 5 caractères")]
    public string Password { get; set; }

    // Relationships
    public Client? Client { get; set; }

    



}
