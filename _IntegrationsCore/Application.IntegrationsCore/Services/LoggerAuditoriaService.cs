using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using System.Data;

namespace Application.IntegrationsCore.Services
{
    /// <summary>
    /// Gerenciador de Logs e Auditoria.
    /// 
    /// Esta classe irá controlar as classes de auditoria , status e de logs, como uma classe de negócios.
    /// Ela controla e insere Status, Logs e Detalhes (xml)
    /// Desta forma, temos uma classe apenas, que irá facilitar todo o processo.
    /// 
    /// Além disso ela mantem os dados em memória, para não inserir um a um e inserir todos no final.
    /// </summary>
    public class LoggerAuditoriaService : ILoggerAuditoriaService
    {
        #region PROPRIEDADES INTERNAS
        private readonly ILoggerConfigService _logger_config;

        private IList<LogMsg> _ListLogMsgs { get; set; } = new List<LogMsg>();

        /// <summary>
        //   Status Atual De Processamento:
        //   Este é o objeto de status que será salvo, criado em memória antes.
        ///  OBS: Embora tenhamos uma lista, vamos inicialmente usar apenas um status, pois ainda
        ///  não há necessidade visível de mais de um status ser controlado em memória.
        ///  e iria adicionar complexidade desnecessária.
        /// </summary>
        private IList<LogStatus> _ListLogStatus { get; set; } = new List<LogStatus>();
        
        /// <summary>
        /// A lista de Detalhes , do Log, onde prevemos para gravar os XML 
        /// os trechos de códigos a serem logados dos registros recebidos.
        /// </summary>
        private IList<LogMsgsDetail> _ListLogMsgsDetail { get; set; } = new List<LogMsgsDetail>();

        /// <summary>
        /// Repositório de mensagens
        /// </summary>
        private ILogMsgsRepository? _LogMsgs_Repository = null;
        //private ILogMsgsRepository LogMsgs_Repository
        //{
        //    get
        //    {
        //        if (_LogMsgs_Repository == null)
        //        {
        //            // Cria as classes necessárias
        //            _LogMsgs_Repository = new LogMsgsRepository(_conn);
        //            _logStatus_Repository = new LogStatusRepository(_conn);
        //            _logDetails_Repository = new LogDetailsRepository(_conn);
        //        }
        //        return _LogMsgs_Repository;
        //    }
        //}


        private ILogStatusRepository? _logStatus_Repository;
        //private ILogStatusRepository LogStatusRepository
        //{
        //    get
        //    {
        //        if (_logStatus_Repository == null)
        //            _logStatus_Repository = new LogStatusRepository(_conn);
        //        return _logStatus_Repository;
        //    }
        //}


        private ILogDetailsRepository? _logDetails_Repository;
        //private ILogDetailsRepository LogDetails_Repository
        //{
        //    get
        //    {
        //        if (_logDetails_Repository == null)
        //            _logDetails_Repository = new LogDetailsRepository(_conn);
        //        return _logDetails_Repository;
        //    }
        //}
        #endregion

        #region PROPRIEDADES: Publicas
        /// <summary>
        /// Setar o App para não precisar ficar alimentando toda hora
        /// </summary>
        public EnumIdApp IdApp { get; set; }
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Injeção de dependências, as classes de persistência fundamentais
        /// </summary>
        /// <param name="blommersLoggers_Config"></param>
        /// <param name="logMessager"></param>
        /// <param name="logStatus"></param>
        /// <param name="logDetails"></param>
        public LoggerAuditoriaService(
            ILoggerConfigService loggers_Config,
            ILogMsgsRepository logMessager,
            ILogStatusRepository logStatus,
            ILogDetailsRepository logDetails)
        {
            _logger_config = loggers_Config;
            _LogMsgs_Repository = logMessager;
            _logStatus_Repository = logStatus;
            _logDetails_Repository = logDetails;
        }


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
        public ILoggerAuditoriaService AddLog(EnumIdLogLevel level = EnumIdLogLevel.StatusRunning
                                    , EnumIdError idError = EnumIdError.StatusRunning
                                    , string? string_Key = null
                                    , string messagem = ""
                                    , string user = ""
                                    )
        {
            LogMsg msg = new LogMsg()
            {
                IdLogMsg = null,
                IdApp = this.IdApp,
                AppName = _logger_config.AppName,
                IdDomain = _logger_config.Domain,
                TextLog = messagem,
                IdError = idError,
                IdLogLevel = level,
                ValueKeyFields = string_Key,
                LastUpdateOn = DateTime.Now,
                StartDate = DateTime.Now,
                LastUpdateUser = user
            };

            _ListLogMsgs.Add(msg);

            return this;
        }


        

        /// <summary>
        /// Adicionar registro em memória ao log 
        /// </summary>
        /// <param name="idApp">A referência do ponto onde ocorreu a exception é obrigatórioa.</param>
        /// <param name="level">O level é obrigatório, precisamos definir qual a gravidade do registro para todos os registros.</param>
        /// <param name="idError">É opcional, mas é muito bom informar sempre, na realidade o erro é o cadastro de logs, de tipos de mensagens, que definidos, categorizam o log em mensagens específicas, onde podemos tirar métricas, e relatórios. Por isso é importante fornecer, a não ser que realmente aquele caso, não tenha ainda definido oque será. </param>
        /// <param name="string_Key">A chave do registro onde ocorreu o erro! Lembre-se este campo será usado para referênciar os registros. Quando não houver, registro relacionado, poderá ser omitido.</param>
        /// <param name="message_log_detalhes_da_ocorrencia">A mensagem de detalhes é opcional, pois a idéia é sempre que pudermos usarmos erros catalogados, que reduzem o tamanho do log, evitando erros de textos grandes. Porém, há necessidade, de complementar a mesagem, informando questões específicas do ponto onde o erro ocorreu.</param>
        /// <param name="user">Permitimos passar o usuário, como opcional,pois quando houver um aplicativo, onde houver logon, poderá ser fornecido o usuário, ou o código do usuário aqui.</param>
        /// <returns>Retornará o reigstro que foi criado, para ter a referência caso necessário</returns>        
        public ILoggerAuditoriaService AddLog(
            EnumIdApp idApp
            , EnumIdLogLevel level
            , EnumIdError idError = EnumIdError.Undefined
            , string? string_Key = null
            , string message_log_detalhes_da_ocorrencia = ""
            , string user = ""
            )
        {
            LogMsg msg = new LogMsg()
            {
                // Incrementar o Id da Mensagem Para Controle Da Lista
                IdLogMsg = null,
                TextLog = message_log_detalhes_da_ocorrencia,
                IdApp = idApp,
                IdError = idError,
                IdLogLevel = level,
                LastUpdateUser = user,
                ValueKeyFields = string_Key,
                AppName = _logger_config.AppName,
                IdDomain = _logger_config.Domain,
                LastUpdateOn = DateTime.Now,
            };

            _ListLogMsgs.Add(msg);

            return this;
        }


        public ILoggerAuditoriaService AddLog(EnumIdApp idApp
                                    , EnumIdLogLevel level
                                    , string msg
                                    , EnumIdError idError = EnumIdError.Undefined
                                    )
        {
            return AddLog(idApp, level, idError, null, msg);
        }


        public ILoggerAuditoriaService AddLog(EnumIdLogLevel level
                                    , string msg
                                    , EnumIdError idError = EnumIdError.Undefined
                                    )
        {
            return AddLog(this.IdApp, level, idError, null, msg);
        }

        #endregion

        #region ADD DETAILS / ITENS / XML : Métodos para adicionar os detalhes, os dados de XML dos logs
        /// <summary>
        /// Adicionar à referência de uma IdLogMsg já inserida, indicará o resultado dos registros importados.
        /// </summary>
        /// <param name="string_Key">A chave do registro onde ocorreu o erro! Lembre-se este campo será usado para referênciar os registros. Quando não houver, registro relacionado, poderá ser omitido.</param>
        /// <param name="message_xml">Este campo trata-se da mensagem xml, json, recebido na integração, de um registro específico, antes de ser parseado, para podermos logar, originalmente, como chegou.</param>
        /// <returns>Retornará o reigstro que foi criado, para ter a referência caso necessário</returns>        
        public ILoggerAuditoriaService AddLogDetail(string string_Key,string message_xml)
        {
            var msg = _ListLogMsgs.LastOrDefault();
            if (msg != null)
            {
                LogMsgsDetail newDetail = new LogMsgsDetail()
                {
                    IdLogMsg = null,
                    FieldKeyValue = string_Key,
                    IdLogMsgDetail = null,
                    LastUpdateOn = DateTime.Now,
                    RegText = message_xml,
                };
                msg.LogMsgDetails.Add(newDetail);
                _ListLogMsgsDetail.Add(newDetail);
            }
            return this;
        }

        public ILoggerAuditoriaService AddLogDetails(Dictionary<string, string> details)
        {
            var log = this._ListLogMsgs.LastOrDefault();
            foreach (var item in details)
            {
                var newDetail = new LogMsgsDetail() { FieldKeyValue = item.Key, RegText = item.Value };
                if (log != null)
                    log.LogMsgDetails.Add(newDetail);
                _ListLogMsgsDetail.Add(newDetail);
            }
            return this;
        }
        /// <summary>
        /// Adiciona a chave como detalhe, este método não adiciona o conteúdo.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="keys"></param>
        public ILoggerAuditoriaService AddLogDetails(IList<string> keys)
        {
            var log = this._ListLogMsgs.LastOrDefault();
            foreach (var i_key in keys)
            {
                var newDetail = new LogMsgsDetail() { FieldKeyValue = i_key };
                if (log != null)
                    log.LogMsgDetails.Add(newDetail);
                _ListLogMsgsDetail.Add(newDetail);
            }
            return this;
        }

        #endregion

        #region CREATES / ADD: Métodos para criar os registros e adicionar

        /// <summary>
        /// Adicionar registro em memória ao log 
        /// </summary>        
        /// <param name="level">O level é obrigatório, precisamos definir qual a gravidade do registro para todos os registros.</param>
        /// <param name="title">A mensagem de detalhes é opcional, pois a idéia é sempre que pudermos usarmos erros catalogados, que reduzem o tamanho do log, evitando erros de textos grandes. Porém, há necessidade, de complementar a mesagem, informando questões específicas do ponto onde o erro ocorreu.</param>
        /// <param name="text">tTexto detalhado grande da mensagem</param
        /// <returns>Retorna a própria instância para facilitar novas actions.</returns>
        public ILoggerAuditoriaService AddNewStatus(
                                    EnumIdLogLevel level = EnumIdLogLevel.StatusRunning
                                    , string title = "Processamento Iniciado!"
                                    , string text = ""
            )
        {
            LogStatus logStatus = new()
            {
                // Incrementar o Id da Mensagem Para Controle Da Lista
                IdLogStatus = null,
                Msg = title,
                Detail = text,
                IdApp = this.IdApp,
                IdLogLevel = level,
                IdDomain = _logger_config.Domain,
                LastUpdateOn = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
            };

            _ListLogStatus.Clear();
            _ListLogStatus.Add(logStatus);
            var lastLogMsg = _ListLogMsgs.Where(i => i.IdLogMsg == null).LastOrDefault();
            if (lastLogMsg != null)
                lastLogMsg.LogStatus.Add(logStatus);
            return this;
        }

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
            )
        {
            LogMsg msg = new LogMsg()
            {
                // Incrementar o Id da Mensagem Para Controle Da Lista
                IdLogMsg = _ListLogMsgs.Count() + 1,
                TextLog = pException.Message,
                IdApp = idApp,
                IdError = idError,
                IdLogLevel = level,
                LastUpdateUser = user,
                ValueKeyFields = string_Key,
                AppName = _logger_config.AppName,
                IdDomain = _logger_config.Domain,
                LastUpdateOn = DateTime.Now,
            };

            _ListLogMsgs.Add(msg);
            return this;
        }


        /// <summary>
        /// As mensagens internas da exception serão importadas para poder inserir no banco.
        /// </summary>
        /// <param name="ex">Informe a Exception_Logger, para importar as mensagens</param>
        /// <param name="IdApp">Informe o App, para fazer sobrescrever da exception filha</param>
        /// <returns></returns>
        public ILoggerAuditoriaService ImportLogsFromException(LoggerException ex, EnumIdApp idApp= EnumIdApp.Undefined)
        {
            if (idApp == EnumIdApp.Undefined)
                idApp = this.IdApp;

            foreach (var msg in ex.LogsMsgs)
            {
                msg.IdApp = idApp;
                _ListLogMsgs.Add(msg);
            }
            return this;
        }


        #endregion

        #region SET / CHANGES : Métodos para atualizar em memória, e facilitar

        /// <summary>
        /// Atualizar o Campos do Status Salvo em memória, para poder salvar depois no final.
        /// (se não houver status em memória não será criado um)
        /// </summary>
        /// <param name="error">Informe o erro específico gerado, enumSuccess Para Concluído Com Sucesso!</param>
        /// <param name="idLevel">Informe o nível da mensagem EnumIdLogLevel, caso de sucesso, informe de level enumInformation ou enumStatus, dependendo da visibilidade desejada conforme o caso.</param>
        /// <param name="messageText">Informe um texto adicional de status a ser exibido no aplicativo desejado.</param>
        /// <returns></returns>
        public ILoggerAuditoriaService SetStatus(EnumIdLogLevel idLevel, string title = "", string text = "")
        {
            foreach (var item in this._ListLogStatus)
            {
                item.IdLogLevel = idLevel;
                item.Msg = title;
                item.Detail = text;
                item.EndDate = DateTime.Now;
            }   
            return this;
        }

        /// <summary>
        /// Inicializar o IdApp. Percebemos uma repetição em enviar o IdApp em todo lançamento
        /// e isto poderia gerar erros.
        /// Com este método, iremos inicializar a propriedade IdApp atual, para que todos
        /// os logs sequentes da rotina, sejam do mesmo idApp, sem precisar reenviar.
        /// </summary>
        /// <param name="idApp">Informe o IdAppda rotina</param>
        /// <returns>retorna a própria classe</returns>
        public ILoggerAuditoriaService SetApp(EnumIdApp idApp)
        {
            this.IdApp = idApp;
            return this;
        }

        public ILoggerAuditoriaService SetLogMsg(EnumIdLogLevel idLevel, EnumIdError idError, string text = "")
        {
            var logMsg = _ListLogMsgs.LastOrDefault();

            logMsg.IdError = idError;
            logMsg.IdLogLevel = idLevel;
            logMsg.TextLog = text;
            logMsg.EndDate = System.DateTime.Now;

            return this;
        }

        #endregion

        #region GET LIST: Métodos para retornar os dados internos.

        /// <summary>
        /// Obter a lista em memória com as mensagens inseridas
        /// </summary>
        /// <returns></returns>
        public IList<LogMsg> GetListLogs()
        {
            return _ListLogMsgs;
        }

        /// <summary>
        /// Obter a lista em memória com as mensagens inseridas
        /// </summary>
        /// <returns></returns>
        public IList<LogMsgsDetail> GetListDetails()
        {
            return _ListLogMsgsDetail;
        }

        /// <summary>
        /// Obter o status gerado em memória
        /// </summary>
        /// <returns>Retorna o status criado ou null caso não tenha gerado ainda</returns>
        public LogStatus? GetStatus()
        {
            if (_ListLogStatus.Count == 0)
                return null;

            return _ListLogStatus.FirstOrDefault();
        }

        /// <summary>
        /// Obter o último log de mensagem inserido na lista
        /// </summary>
        /// <returns>retorna uma instancia do ILogMsg</returns>
        public LogMsg? GetLastLog()
        {
            if (this._ListLogMsgs.Count == 0)
                return null;
            else
                return _ListLogMsgs.FirstOrDefault();
        }
        #endregion

        #region COMMITS: Métodos que persistem no banco de dados!

        public async Task CommitAllChanges()
        {
            /* ******
             * Implementação do Logger em Banco de Dados
            ***/

            // LogMsgs: Primeiro tem que gravar as mensagens para ter o Id para relacionar
            if (_ListLogMsgs.Count > 0)
                await _LogMsgs_Repository.BulkInsert(_ListLogMsgs);
                
            // Detalhe: Migramos para este gravando os filhos do log.
            if (_ListLogMsgs != null)
            {
                foreach (var iLogMsg in _ListLogMsgs)
                {
                    if (iLogMsg.LogMsgDetails != null && iLogMsg.LogMsgDetails.Count > 0)
                        await _logDetails_Repository.BulkInsert(iLogMsg.LogMsgDetails);
                }
            }
            // Status: Grava o status, hoje tem apenas um na lista.
            if (_ListLogStatus != null)
            {
                foreach (var iLogStatus in _ListLogStatus)
                {
                    await _logStatus_Repository.Update(iLogStatus);
                }
            }

            Clear();
        }


        public async Task CommitUpdateStatus()
        {
            /* ******
             * Implementação do Logger em Banco de Dados
            ***/
            for (int i = 0; i < _ListLogStatus.Count; i++)
            {
                await _logStatus_Repository.Update(_ListLogStatus[i]);
            }

            if (_ListLogMsgs.Count > 0)
                await _LogMsgs_Repository.BulkInsert(_ListLogMsgs);

            if (_ListLogMsgsDetail.Count > 0)
                await _logDetails_Repository.BulkInsert(_ListLogMsgsDetail);

            for (int i = 0; i < _ListLogMsgs.Count; i++)
            {
                if (_ListLogMsgs[i].LogMsgDetails.Count > 0)
                    await _logDetails_Repository.BulkInsert(_ListLogMsgs[i].LogMsgDetails);
            }

            Clear();
        }

        #endregion

        #region CLEAR: Limpeza das listas e dos objetos

        /// <summary>
        /// Limpar Registros, listas inseridas
        /// </summary>
        /// <param name="clearLogs">Limpar as listas de logs e detalhes dos logs.</param>
        /// <param name="clearStatus">Limpar o status</param>
        public ILoggerAuditoriaService Clear(bool clearLogs = true, bool clearStatus = true)
        {
            if (clearLogs)
            {
                _ListLogMsgs.Clear();
                _ListLogMsgsDetail.Clear();
            }

            if (clearStatus)
                _ListLogStatus.Clear();

            return this;
        }

        #endregion
    }

}


