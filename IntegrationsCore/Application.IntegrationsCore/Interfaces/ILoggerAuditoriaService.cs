using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.Exceptions;

namespace Application.IntegrationsCore.Interfaces
{
    /// <summary>
    /// Gerenciador de Logs e Auditoria.
    /// 
    /// Esta classe irá controlar as classes de auditoria , status e de logs, como uma classe de negócios.
    /// Ela controla e insere Status, Logs e Detalhes (xml)
    /// Desta forma, temos uma classe apenas, que irá facilitar todo o processo.
    /// 
    /// Além disso ela mantem os dados em memória, para não inserir individual. 
    /// Um a um e inserir todos no final.
    /// </summary>
    public interface ILoggerAuditoriaService
    {
        #region PROPRIEDADES: Publicas
        public EnumIdApp IdApp { get; set; }
        #endregion

        #region ADD LOG: Métodos de Adição de logs
        
        /// <summary>
        /// Criar e adicionar um Log Inicial De Status
        /// </summary>
        /// <param name="level"></param>
        /// <param name="idError"></param>
        /// <param name="string_Key"></param>
        /// <param name="message_log_detalhes_da_ocorrencia"></param>
        /// <returns></returns>
        public ILoggerAuditoriaService AddLog(EnumIdLogLevel level
                                    , EnumIdError idError = EnumIdError.Status
                                    , string? string_Key = null
                                    , string message_log_detalhes_da_ocorrencia = ""
                                    , string user = ""
                                    );

        /// <summary>
        /// Adicionar registro em memória ao log 
        /// </summary>
        /// <param name="idApp">A referência do ponto onde ocorreu a exception é obrigatórioa.</param>
        /// <param name="level">O level é obrigatório, precisamos definir qual a gravidade do registro para todos os registros.</param>
        /// <param name="idError">É opcional, mas é muito bom informar sempre, na realidade o erro é o cadastro de logs, de tipos de mensagens, que definidos, categorizam o log em mensagens específicas, onde podemos tirar métricas, e relatórios. Por isso é importante fornecer, a não ser que realmente aquele caso, não tenha ainda definido oque será. </param>
        /// <param name="string_Key">A chave do registro onde ocorreu o erro! Lembre-se este campo será usado para referênciar os registros. Quando não houver, registro relacionado, poderá ser omitido.</param>
        /// <param name="message_log_detalhes_da_ocorrencia">A mensagem de detalhes é opcional, pois a idéia é sempre que pudermos usarmos erros catalogados, que reduzem o tamanho do log, evitando erros de textos grandes. Porém, há necessidade, de complementar a mesagem, informando questões específicas do ponto onde o erro ocorreu.</param>
        /// <param name="user">Permitimos passar o usuário, como opcional,pois quando houver um aplicativo, onde houver logon, poderá ser fornecido o usuário, ou o código do usuário aqui.</param>
        /// <returns></returns>
        public ILoggerAuditoriaService AddLog(EnumIdApp idApp
                                        , EnumIdLogLevel level
                                        , EnumIdError idError = EnumIdError.Undefined
                                        , string? string_Key = null
                                        , string message_log_detalhes_da_ocorrencia = ""
                                        , string user = ""
                                        );

        

        public ILoggerAuditoriaService AddLog(  EnumIdApp idApp
                                        , EnumIdLogLevel level
                                        , string msg
                                        , EnumIdError idError = EnumIdError.Undefined
                                        );

        public ILoggerAuditoriaService AddLog(EnumIdLogLevel level
                                        , string msg
                                        , EnumIdError idError = EnumIdError.Undefined
                                        );

        #endregion

        #region ADD DETAILS / ITENS / XML : Métodos para adicionar os detalhes, os dados de XML dos logs
        /// <summary>
        /// Adicionar mensagem do tipo detalhes, que será persistido na tabela details
        /// Adicionar à referência de uma IdLogMsg já inserida, indicará o resultado dos registros importados.
        /// </summary>
        /// <param name="string_Key">A chave do registro onde ocorreu o erro! Lembre-se este campo será usado para referênciar os registros. Quando não houver, registro relacionado, poderá ser omitido.</param>
        /// <param name="message_xml">Este campo trata-se da mensagem xml, json, recebido na integração, de um registro específico, antes de ser parseado, para podermos logar, originalmente, como chegou.</param>
        /// <returns>Retornará o reigstro que foi criado, para ter a referência caso necessário</returns>        
        public ILoggerAuditoriaService AddLogDetail(string string_Key,
                                            string message_xml);

        public ILoggerAuditoriaService AddLogDetails(Dictionary<string, 
                                             string> details);
        public ILoggerAuditoriaService AddLogDetails(IList<string> keys);


        #endregion

        #region CREATES / ADD: Métodos para criar os registros e adicionar

        /// <summary>
        /// Cria um registro de status e adicionará na memória do log!
        /// Apenas um registro será criado por vez, se dois registros forem criados
        /// o anterior será sobrescrito e irá se perder.
        /// Caso necessário, mais de um simultâneo  na mesma instância, 
        /// precisará implementar dentro da classe.
        /// </summary>
        /// <param name="level">O level é obrigatório, precisamos definir qual a gravidade do registro para todos os registros.</param>
        /// <param name="message">A mensagem de detalhes é opcional, pois a idéia é sempre que pudermos usarmos erros catalogados, que reduzem o tamanho do log, evitando erros de textos grandes. Porém, há necessidade, de complementar a mesagem, informando questões específicas do ponto onde o erro ocorreu.</param>
        /// <param name="text">tTexto detalhado grande da mensagem</param
        /// <returns></returns>
        public ILoggerAuditoriaService AddNewStatus(
                                EnumIdLogLevel level = EnumIdLogLevel.StatusRunning
                                , string title = "Processamento Iniciado!"
                                , string text = "");

        #endregion

        #region ADD EXCEPTION : Métodos para interagir com Exception

        /// <summary>
        /// Adicionar uma exeception à lista de erros atual
        /// </summary>
        /// <param name="pException">Informe o exception ocorrida</param>
        /// <param name="idApp">A referência do ponto onde ocorreu a exception é obrigatórioa.</param>
        /// <param name="message_complementar">A mensagem complementar é opcional, caso, haja informação relevante adicional, informe aqui.</param>
        /// <param name="level">O level pode ser fornecido como opcional caso não seja fornecido será lançado como erro critico..</param>
        /// <param name="idError">É opcional, pois em caso de exceptions, muitos lugares, não serão erros catalogados. Quando o erro é conhecido, e cadastrado na tabela, informe aqui o erro catalogado, por exemplo, falha ao baixar dados da API do Microvix, se o ponto for exato, poderia haver um erro catalogado, para podermos monitorar este ponto do sistema.</param>
        /// <param name="string_Key">A chave do registro onde ocorreu o erro! Lembre-se este campo será usado para referênciar os registros. Quando não houver, registro relacionado, poderá ser omitido.</param>
        /// <param name="user">Permitimos passar o usuário, como opcional,pois quando houver um aplicativo, onde houver logon, poderá ser fornecido o usuário, ou o código do usuário aqui.</param>
        /// <returns>Retornará o reigstro que foi criado, para ter a referência caso necessário</returns>        
        public ILoggerAuditoriaService AddLogException(Exception pException,
                                                EnumIdApp idApp,
                                                EnumIdError idError = EnumIdError.Undefined,
                                                EnumIdLogLevel level = EnumIdLogLevel.Critical,
                                                string message_complementar = "",
                                                string? string_Key = null,
                                                string user = ""
                                                );

        public ILoggerAuditoriaService ImportLogsFromException(LoggerException ex, EnumIdApp idApp = EnumIdApp.Undefined);

        #endregion

        #region SET / CHANGES : Métodos para atualizar em memória, e facilitar
        /// <summary>
        /// Atualizar o Campos do Status Salvo em memória, para poder salvar depois no final.
        /// (se não houver status em memória não será criado um)
        /// </summary>
        /// <param name="idLevel">Informe o nível da mensagem EnumIdLogLevel, caso de sucesso, informe de level enumInformation ou enumStatus, dependendo da visibilidade desejada conforme o caso.</param>
        /// <param name="title">Título, mensagem curta max 200.</param>
        /// <param name="text">Detalhes da exception por exemplo inserir aqui.</param>
        /// <returns></returns>
        ILoggerAuditoriaService SetStatus(EnumIdLogLevel idLevel, string title = "", string text = "");

        /// <summary>
        /// Inicializar o IdApp. Percebemos uma repetição em enviar o IdApp em todo lançamento
        /// e isto poderia gerar erros.
        /// Com este método, iremos inicializar a propriedade IdApp atual, para que todos
        /// os logs sequentes da rotina, sejam do mesmo idApp, sem precisar reenviar.
        /// </summary>
        /// <param name="idApp">Informe o IdAppda rotina</param>
        /// <returns>retorna a própria classe</returns>
        public ILoggerAuditoriaService SetApp(EnumIdApp idApp);

        ILoggerAuditoriaService SetLogMsg(EnumIdLogLevel idLevel, EnumIdError error , string text = "");
        #endregion

        #region GET LIST: Métodos para retornar os dados internos.
        /// <summary>
        /// Obter a lista em memória com as mensagens inseridas
        /// </summary>
        /// <returns></returns>
        public IList<LogMsg> GetListLogs();

        /// <summary>
        /// Obter a lista em memória com as mensagens inseridas
        /// </summary>
        /// <returns></returns>
        public IList<LogMsgsDetail> GetListDetails();

        /// <summary>
        /// Obter o status gerado em memória
        /// </summary>
        /// <returns>Retorna o status criado ou null caso não tenha gerado ainda</returns>
        public LogStatus? GetStatus();

        /// <summary>
        /// Obter o último log de mensagem inserido na lista
        /// </summary>
        /// <returns>retorna uma instancia do ILogMsg</returns>
        public LogMsg? GetLastLog();

        #endregion

        #region COMMITS: Métodos que persistem no banco de dados!
        /// <summary>
        /// Inserir os registros inseridos em memória, e atualizar o status. 
        /// Este método, irá persistir no logger configurado as alterções realiadas
        /// </summary>
        Task CommitAllChanges();

        /// <summary>
        /// Este método irá persistir / atualizar somente as alterações realizadas no STATUS
        /// Ele servirá para atualizar o status sem atualizar os logs.
        /// Em casos onde estamos processando rotinas longas
        /// E desejamos ir atualizando o processamento continuamente.
        /// </summary>
        /// <returns></returns>
        Task CommitUpdateStatus();

        #endregion

        #region CLEAR: Limpeza das listas e dos objetos

        /// <summary>
        /// Limpar Registros, listas inseridas
        /// </summary>
        /// <param name="clearLogs">Limpar as listas de logs e detalhes dos logs.</param>
        /// <param name="clearStatus">Limpar o status</param>
        public ILoggerAuditoriaService Clear(bool clearLogs = true, bool clearStatus = true);

        #endregion
    }
}

