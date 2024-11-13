namespace Domain.IntegrationsCore.Entities.Enums
{
    /// <summary>
    /// enumerator EnumIdDomain
    /// Nesta classe vamos configurar os enumerators dos aplicativos que serão usados
    /// Nunca deve usar os números de erros diretos nas chamadas
    /// Ao usar o enumerator para referenciar o erro, conseguimos centralizar em
    /// qualquer parte do sistema, que precisarmos chamar, um log, vamos conseguir
    /// referenciar
    /// </summary>
    public enum EnumIdDomain
    {
        Debug = 1,
        Homolog = 2,
        Release = 3,
    }
}
