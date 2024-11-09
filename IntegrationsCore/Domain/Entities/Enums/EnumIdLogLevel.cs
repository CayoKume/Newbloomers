namespace IntegrationsCore.Domain.Entities.Enums
{
    /// <summary>
    ///  Log Levels, até o código 6 é o padrão de mercado.
    ///  após o log 6, temos nossos logs mínimos, que são logs de informação.
    ///  desta forma estamos unindo duas ferramentas, 
    ///  logs com nossos apontamentos de segurança, informações necessárias.
    ///  Os nossos logs poderiam ser tipo 6 ou superior para testar
    ///  Geralmente ao definir o nível que desejamos de logs, 
    ///  serão logados alí em diante.
    ///  
    ///  0 - Trace, é o log mais detalhado, quando usamos este log, em homogação, ou em casos específicos onde precisamos descobrir um erro.
    ///  1 - Debug, é o log mais detalhado, quando usamos este log, em homogação, ou em casos específicos onde precisamos descobrir um erro.
    ///  2 - Info: Já podemos deixar ligado em produção, aponta logs, de informações úteis, que podemo nos ajudar.  
    ///  3 - Warning: Mensanges de alerta, são mensagens que não são erros, mas são avisos de coisas mais importante, não é recomendado desligar, a não ser se alguma mensagem estiver enchendo muito o log.
    ///  4 - Error: São as exceptions, não devemos deligar, então temos que ligar para gravar os erros.
    ///  5 - Critical: São erros criticos, por exemplo parou de funcionar, não está funcionando.
    ///  6 - Validations:  No padrão básico, de log de mercado, o default, 6 seriam nenhuma, mas no nosso, o 6 será validações
    ///  Pois iremos inserir validações customizadas como log.
    ///  Neste log iremos colocar regras de validação, apontamentos para relatório.
    ///  7 - Status: Será o status de processamento das rotinas, que é o nível básico de log, 
    ///  o status, indicará o que aconteceu no ciclo do registro.
    /// </summary>
    public enum EnumIdLogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        Validations = 6,
        StatusPending = 7,
        StatusRunning = 8,
        StatusError = 9,
        StatusSuccess = 10,
        None = 11,
    }
}
