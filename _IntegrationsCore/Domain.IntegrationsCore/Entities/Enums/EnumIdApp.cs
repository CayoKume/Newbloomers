namespace Domain.IntegrationsCore.Entities.Enums
{
    /// <summary>
    /// Enumerator: EnumIdApp
    /// Eliminar problema de 'chumbar'  códigos de erros 
    /// usar a referência do erro enumerator.
    /// Usada para passarmos ao logar, o id correto do app , para o método de erros.
    /// sem precisar buscar na tabela, o código e evitar erros.
    /// quando criarmos logs personalizados, vamos inserir o ponto do sistema um log.
    /// vamos inserir a referência usando sempre o enum
    /// para não chumbar o id do código de erro em pontos do sistema 
    /// </summary>
    public enum EnumIdApp
    {
        Undefined = 0,
        NewBloomersSystems = 10,
        Database = 20,
        Jobs = 30,
        Procedures = 40,
        Trigguers = 50,
        Systems = 60,
        Erp = 70,
        ECommerce = 80,

        Services = 100,
        Workers = 102,
        Worker_Invoice = 104,
        Worker_Orders = 106,

        Integrations = 100,
        IntegrationsLogs = 101,

        IntegrationsOrders = 104,
        IntegrationsProducts = 106,
        LogsRepository = 107,

        Integracao_B2CConsultaClientes = 200,
        Jobs_B2CConsultaClientes = 300,
    }
}
