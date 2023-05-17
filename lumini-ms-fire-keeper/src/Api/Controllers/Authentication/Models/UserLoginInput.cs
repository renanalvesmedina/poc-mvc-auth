using System.ComponentModel.DataAnnotations;

namespace Lumini.FireKeeper.Api.Controllers.Authentication.Models
{
    /// <summary>
    /// Dados para autenticação.
    /// </summary>
    public class UserLoginInput
    {
        /// <summary>
        /// Email cadastrado na plataforma
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
