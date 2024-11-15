using System.ComponentModel.DataAnnotations;

namespace Cours.Models;

public class Dette
{


  public int Id { get; set; }
  public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
  [Range(1, float.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
  public float Montant { get; set; }

  [Range(1, float.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
  public float MontantVerser { get; set; }

  // Relation
  public Client Client { get; set; }
  public int ClientId { get; set; }
   public virtual ICollection<Paiement>? Paiements { get; set; }









}
