using System.ComponentModel.DataAnnotations;

namespace Lumini.FireKeeper.Api.Controllers.Authentication.Models
{
    /// <summary>
    /// Criação de usuário para acesso a plataforma.
    /// </summary>
    public class CreateUserInput
    {
        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Email válido para login.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Senha com letras, numeros e símbolo.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Número de telefone válido.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// CPF válido.
        /// </summary>
        [Required]
        public string Document { get; set; }
    }
}
