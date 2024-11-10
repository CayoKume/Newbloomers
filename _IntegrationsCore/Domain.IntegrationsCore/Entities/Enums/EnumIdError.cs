namespace Domain.IntegrationsCore.Entities.Enums
{
    /// <summary>
    /// name: enumErrors
    /// tipo: enumerator
    /// 
    /// Description:
    /// Irá especificar códigos de erros específicos que possamos categorizar.
    /// Isto é utilizado em todos os sistemas quando possível criar um código de erro
    /// que se repete e podemos criar procedimentos par que seja possível 
    /// resolver os problemas de forma padronizada.
    /// 
    /// Instruções:
    /// 
    ///  Inicialmente, não será possível usarmos o erro para todas as chamadas.
    ///  A maioria será setado undefined.
    ///  quando conseguirmos categorizar uma falha, interceptar e prever.
    ///  então implementamos uma validação antes que a exception estoure, ao interceptar
    ///  cadastramos o erro, como falha prevista, que será adicionada sempre com um
    ///  erro relacionado.
    ///  
    ///  Exemplo: 
    ///  
    ///   Exemplo, se ao desserializar o arquivo ocorrer exception, conforme determinado valor.
    ///   então para resolver, depuramos, e encontramos a falha.
    ///   E então iremos previnir para não ocorrer mais a exception.
    ///   O erro tem que ser interceptado antes, sem deixar estourar.
    ///   Então , validamos o erro, validamos as condições que irão gerar o erro, e logamos.
    ///   a mensagem correta, relacionada.
    ///  
    ///  
    ///    Se uma exception ocorre, em determinado método quando um valor é nulo.
    ///    Agora, verificamos o método e quando o valor é nulo, geramos o log e finalizamos a rotina
    ///    desta forma, não é irá gerar a exception e irá gerar o log que não processou
    ///    falhou e irá logar o motivo correto, 
    ///    por exmplo campo [........] com valor nulo não é possível continuar.
    /// </summary>
    public enum EnumIdError
    {
        Undefined = 0,
        Status = 1,
        StatusRunning = 1,
        Success = 2,
        Exception = 3,
        Erro = 4,
        ExceptionGenerica = 20,
        ArgumentConectionStringIsNull = 10,
        ArgumentoInvalido = 21,


        // Erros integração /  API / endpoint
        /// <summary>
        /// Erro ao consultar end-point
        /// </summary>   
        EndPointException = 30,
        EndPointReturnEmpty = 31,
        EndPointFailOnDeserialize = 32,

        IntegrationsExceptions = 40,

        SqlInsert = 50,
    }
}
