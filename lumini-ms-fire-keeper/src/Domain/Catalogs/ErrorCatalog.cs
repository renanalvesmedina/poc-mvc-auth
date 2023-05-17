using Lumini.Common.Model;

namespace Lumini.FireKeeper.Domain.Catalogs
{
    public static class ErrorCatalog
    {
        public static ErrorCatalogEntry Generic => ("LUMINI-KF-GEN-01", "Generic Error!");
        public static ErrorCatalogEntry WithMessage(string desc) => ("LUMINI-KF-GEN-02", desc);
        public static ErrorCatalogEntry InvalidDocument => ("LUMINI-KF-GEN-02", "CPF Inválido!");
        public static ErrorCatalogEntry InvalidEmail => ("LUMINI-KF-GEN-03", "Email inválido!");

        public static class Authentication
        {
            public static ErrorCatalogEntry NotCreated(string desc) => ("LUMINI-AUTHENTICATION-USER-01", desc);
            public static ErrorCatalogEntry NotFound => ("LUMINI-AUTHENTICATION-USER-02", "Usuário não encontrado!");
            public static ErrorCatalogEntry InvalidPassword => ("LUMINI-AUTHENTICATION-USER-03", "Senha inválida!");
            public static ErrorCatalogEntry NotFoundRoles => ("LUMINI-AUTHENTICATION-USER-03", "Usuário não tem função atribuida!");
        }
    }
}
