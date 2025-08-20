using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services;
using Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Validations.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Validations.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using FluentValidation;
using Infrastructure.LinxMicrovix.Outbound.WebService.Api;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data;
using Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce;
using Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix;
using LinxMicrovix.Outbound.Web.Service.Application.Services.LinxMicrovix;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedB2CLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixCommandHandler, LinxMicrovixCommandHandler>();
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped<IAPICall, APICall>();

            services.AddScoped<IB2CConsultaClassificacaoService, B2CConsultaClassificacaoService>();
            services.AddScoped<IB2CConsultaClassificacaoRepository, B2CConsultaClassificacaoRepository>();
            services.AddScoped<IB2CConsultaClassificacaoCommandHandler, B2CConsultaClassificacaoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClassificacaoValidator>();

            services.AddScoped<IB2CConsultaClientesService, B2CConsultaClientesService>();
            services.AddScoped<IB2CConsultaClientesRepository, B2CConsultaClientesRepository>();
            services.AddScoped<IB2CConsultaClientesCommandHandler, B2CConsultaClientesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesValidator>();

            services.AddScoped<IB2CConsultaClientesContatosService, B2CConsultaClientesContatosService>();
            services.AddScoped<IB2CConsultaClientesContatosRepository, B2CConsultaClientesContatosRepository>();
            services.AddScoped<IB2CConsultaClientesContatosCommandHandler, B2CConsultaClientesContatosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesContatosValidator>();

            services.AddScoped<IB2CConsultaClientesContatosParentescoService, B2CConsultaClientesContatosParentescoService>();
            services.AddScoped<IB2CConsultaClientesContatosParentescoRepository, B2CConsultaClientesContatosParentescoRepository>();
            services.AddScoped<IB2CConsultaClientesContatosParentescoCommandHandler, B2CConsultaClientesContatosParentescoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesContatosParentescoValidator>();

            services.AddScoped<IB2CConsultaClientesEnderecosEntregaService, B2CConsultaClientesEnderecosEntregaService>();
            services.AddScoped<IB2CConsultaClientesEnderecosEntregaRepository, B2CConsultaClientesEnderecosEntregaRepository>();
            services.AddScoped<IB2CConsultaClientesEnderecosEntregaCommandHandler, B2CConsultaClientesEnderecosEntregaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesEnderecosEntregaValidator>();

            services.AddScoped<IB2CConsultaClientesEstadoCivilService, B2CConsultaClientesEstadoCivilService>();
            services.AddScoped<IB2CConsultaClientesEstadoCivilRepository, B2CConsultaClientesEstadoCivilRepository>();
            services.AddScoped<IB2CConsultaClientesEstadoCivilCommandHandler, B2CConsultaClientesEstadoCivilCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesEstadoCivilValidator>();

            services.AddScoped<IB2CConsultaClientesSaldoService, B2CConsultaClientesSaldoService>();
            services.AddScoped<IB2CConsultaClientesSaldoRepository, B2CConsultaClientesSaldoRepository>();
            services.AddScoped<IB2CConsultaClientesSaldoCommandHandler, B2CConsultaClientesSaldoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesSaldoValidator>();

            services.AddScoped<IB2CConsultaClientesSaldoLinxService, B2CConsultaClientesSaldoLinxService>();
            services.AddScoped<IB2CConsultaClientesSaldoLinxRepository, B2CConsultaClientesSaldoLinxRepository>();
            services.AddScoped<IB2CConsultaClientesSaldoLinxCommandHandler, B2CConsultaClientesSaldoLinxCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaClientesSaldoLinxValidator>();

            services.AddScoped<IB2CConsultaCNPJsChaveService, B2CConsultaCNPJsChaveService>();
            services.AddScoped<IB2CConsultaCNPJsChaveRepository, B2CConsultaCNPJsChaveRepository>();
            services.AddScoped<IB2CConsultaCNPJsChaveCommandHandler, B2CConsultaCNPJsChaveCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaCNPJsChaveValidator>();

            services.AddScoped<IB2CConsultaCodigoRastreioService, B2CConsultaCodigoRastreioService>();
            services.AddScoped<IB2CConsultaCodigoRastreioRepository, B2CConsultaCodigoRastreioRepository>();
            services.AddScoped<IB2CConsultaCodigoRastreioCommandHandler, B2CConsultaCodigoRastreioCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaCodigoRastreioValidator>();

            services.AddScoped<IB2CConsultaColecoesService, B2CConsultaColecoesService>();
            services.AddScoped<IB2CConsultaColecoesRepository, B2CConsultaColecoesRepository>();
            services.AddScoped<IB2CConsultaColecoesCommandHandler, B2CConsultaColecoesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaColecoesValidator>();

            services.AddScoped<IB2CConsultaEmpresasService, B2CConsultaEmpresasService>();
            services.AddScoped<IB2CConsultaEmpresasRepository, B2CConsultaEmpresasRepository>();
            services.AddScoped<IB2CConsultaEmpresasCommandHandler, B2CConsultaEmpresasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaEmpresasValidator>();

            services.AddScoped<IB2CConsultaEspessurasService, B2CConsultaEspessurasService>();
            services.AddScoped<IB2CConsultaEspessurasRepository, B2CConsultaEspessurasRepository>();
            services.AddScoped<IB2CConsultaEspessurasCommandHandler, B2CConsultaEspessurasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaEspessurasValidator>();

            services.AddScoped<IB2CConsultaFlagsService, B2CConsultaFlagsService>();
            services.AddScoped<IB2CConsultaFlagsRepository, B2CConsultaFlagsRepository>();
            services.AddScoped<IB2CConsultaFlagsCommandHandler, B2CConsultaFlagsCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaFlagsValidator>();

            services.AddScoped<IB2CConsultaFormasPagamentoService, B2CConsultaFormasPagamentoService>();
            services.AddScoped<IB2CConsultaFormasPagamentoRepository, B2CConsultaFormasPagamentoRepository>();
            services.AddScoped<IB2CConsultaFormasPagamentoCommandHandler, B2CConsultaFormasPagamentoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaFormasPagamentoValidator>();

            services.AddScoped<IB2CConsultaFornecedoresService, B2CConsultaFornecedoresService>();
            services.AddScoped<IB2CConsultaFornecedoresRepository, B2CConsultaFornecedoresRepository>();
            services.AddScoped<IB2CConsultaFornecedoresCommandHandler, B2CConsultaFornecedoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaFornecedoresValidator>();

            services.AddScoped<IB2CConsultaGrade1Service, B2CConsultaGrade1Service>();
            services.AddScoped<IB2CConsultaGrade1Repository, B2CConsultaGrade1Repository>();
            services.AddScoped<IB2CConsultaGrade1CommandHandler, B2CConsultaGrade1CommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaGrade1Validator>();

            services.AddScoped<IB2CConsultaGrade2Service, B2CConsultaGrade2Service>();
            services.AddScoped<IB2CConsultaGrade2Repository, B2CConsultaGrade2Repository>();
            services.AddScoped<IB2CConsultaGrade2CommandHandler, B2CConsultaGrade2CommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaGrade2Validator>();

            services.AddScoped<IB2CConsultaImagensService, B2CConsultaImagensService>();
            services.AddScoped<IB2CConsultaImagensRepository, B2CConsultaImagensRepository>();
            services.AddScoped<IB2CConsultaImagensCommandHandler, B2CConsultaImagensCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaImagensValidator>();

            services.AddScoped<IB2CConsultaImagensHDService, B2CConsultaImagensHDService>();
            services.AddScoped<IB2CConsultaImagensHDRepository, B2CConsultaImagensHDRepository>();
            services.AddScoped<IB2CConsultaImagensHDCommandHandler, B2CConsultaImagensHDCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaImagensHDValidator>();

            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresService, B2CConsultaLegendasCadastrosAuxiliaresService>();
            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresRepository, B2CConsultaLegendasCadastrosAuxiliaresRepository>();
            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresCommandHandler, B2CConsultaLegendasCadastrosAuxiliaresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaLegendasCadastrosAuxiliaresValidator>();

            services.AddScoped<IB2CConsultaLinhasService, B2CConsultaLinhasService>();
            services.AddScoped<IB2CConsultaLinhasRepository, B2CConsultaLinhasRepository>();
            services.AddScoped<IB2CConsultaLinhasCommandHandler, B2CConsultaLinhasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaLinhasValidator>();

            services.AddScoped<IB2CConsultaMarcasService, B2CConsultaMarcasService>();
            services.AddScoped<IB2CConsultaMarcasRepository, B2CConsultaMarcasRepository>();
            services.AddScoped<IB2CConsultaMarcasCommandHandler, B2CConsultaMarcasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaMarcasValidator>();

            services.AddScoped<IB2CConsultaNFeService, B2CConsultaNFeService>();
            services.AddScoped<IB2CConsultaNFeRepository, B2CConsultaNFeRepository>();
            services.AddScoped<IB2CConsultaNFeCommandHandler, B2CConsultaNFeCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaNFeValidator>();

            services.AddScoped<IB2CConsultaNFeSituacaoService, B2CConsultaNFeSituacaoService>();
            services.AddScoped<IB2CConsultaNFeSituacaoRepository, B2CConsultaNFeSituacaoRepository>();
            services.AddScoped<IB2CConsultaNFeSituacaoCommandHandler, B2CConsultaNFeSituacaoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaNFeSituacaoValidator>();

            services.AddScoped<IB2CConsultaPalavrasChavePesquisaService, B2CConsultaPalavrasChavePesquisaService>();
            services.AddScoped<IB2CConsultaPalavrasChavePesquisaRepository, B2CConsultaPalavrasChavePesquisaRepository>();
            services.AddScoped<IB2CConsultaPalavrasChavePesquisaCommandHandler, B2CConsultaPalavrasChavePesquisaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPalavrasChavePesquisaValidator>();

            services.AddScoped<IB2CConsultaPedidosService, B2CConsultaPedidosService>();
            services.AddScoped<IB2CConsultaPedidosRepository, B2CConsultaPedidosRepository>();
            services.AddScoped<IB2CConsultaPedidosCommandHandler, B2CConsultaPedidosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosValidator>();

            services.AddScoped<IB2CConsultaPedidosIdentificadorService, B2CConsultaPedidosIdentificadorService>();
            services.AddScoped<IB2CConsultaPedidosIdentificadorRepository, B2CConsultaPedidosIdentificadorRepository>();
            services.AddScoped<IB2CConsultaPedidosIdentificadorCommandHandler, B2CConsultaPedidosIdentificadorCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosIdentificadorValidator>();

            services.AddScoped<IB2CConsultaPedidosItensService, B2CConsultaPedidosItensService>();
            services.AddScoped<IB2CConsultaPedidosItensRepository, B2CConsultaPedidosItensRepository>();
            services.AddScoped<IB2CConsultaPedidosItensCommandHandler, B2CConsultaPedidosItensCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosItensValidator>();

            services.AddScoped<IB2CConsultaPedidosPlanosService, B2CConsultaPedidosPlanosService>();
            services.AddScoped<IB2CConsultaPedidosPlanosRepository, B2CConsultaPedidosPlanosRepository>();
            services.AddScoped<IB2CConsultaPedidosPlanosCommandHandler, B2CConsultaPedidosPlanosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosPlanosValidator>();

            services.AddScoped<IB2CConsultaPedidosStatusService, B2CConsultaPedidosStatusService>();
            services.AddScoped<IB2CConsultaPedidosStatusRepository, B2CConsultaPedidosStatusRepository>();
            services.AddScoped<IB2CConsultaPedidosStatusCommandHandler, B2CConsultaPedidosStatusCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosStatusValidator>();

            services.AddScoped<IB2CConsultaPedidosTiposService, B2CConsultaPedidosTiposService>();
            services.AddScoped<IB2CConsultaPedidosTiposRepository, B2CConsultaPedidosTiposRepository>();
            services.AddScoped<IB2CConsultaPedidosTiposCommandHandler, B2CConsultaPedidosTiposCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPedidosTiposValidator>();

            services.AddScoped<IB2CConsultaPlanosService, B2CConsultaPlanosService>();
            services.AddScoped<IB2CConsultaPlanosRepository, B2CConsultaPlanosRepository>();
            services.AddScoped<IB2CConsultaPlanosCommandHandler, B2CConsultaPlanosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPlanosValidator>();

            services.AddScoped<IB2CConsultaPlanosParcelasService, B2CConsultaPlanosParcelasService>();
            services.AddScoped<IB2CConsultaPlanosParcelasRepository, B2CConsultaPlanosParcelasRepository>();
            services.AddScoped<IB2CConsultaPlanosParcelasCommandHandler, B2CConsultaPlanosParcelasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaPlanosParcelasValidator>();

            services.AddScoped<IB2CConsultaProdutosService, B2CConsultaProdutosService>();
            services.AddScoped<IB2CConsultaProdutosRepository, B2CConsultaProdutosRepository>();
            services.AddScoped<IB2CConsultaProdutosCommandHandler, B2CConsultaProdutosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosValidator>();

            services.AddScoped<IB2CConsultaProdutosAssociadosService, B2CConsultaProdutosAssociadosService>();
            services.AddScoped<IB2CConsultaProdutosAssociadosRepository, B2CConsultaProdutosAssociadosRepository>();
            services.AddScoped<IB2CConsultaProdutosAssociadosCommandHandler, B2CConsultaProdutosAssociadosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosAssociadosValidator>();

            services.AddScoped<IB2CConsultaProdutosCampanhasService, B2CConsultaProdutosCampanhasService>();
            services.AddScoped<IB2CConsultaProdutosCampanhasRepository, B2CConsultaProdutosCampanhasRepository>();
            services.AddScoped<IB2CConsultaProdutosCampanhasCommandHandler, B2CConsultaProdutosCampanhasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCampanhasValidator>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesService, B2CConsultaProdutosCamposAdicionaisDetalhesService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesRepository, B2CConsultaProdutosCamposAdicionaisDetalhesRepository>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler, B2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCamposAdicionaisDetalhesValidator>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesService, B2CConsultaProdutosCamposAdicionaisNomesService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesRepository, B2CConsultaProdutosCamposAdicionaisNomesRepository>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesCommandHandler, B2CConsultaProdutosCamposAdicionaisNomesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCamposAdicionaisNomesValidator>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresService, B2CConsultaProdutosCamposAdicionaisValoresService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresRepository, B2CConsultaProdutosCamposAdicionaisValoresRepository>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresCommandHandler, B2CConsultaProdutosCamposAdicionaisValoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCamposAdicionaisValoresValidator>();

            services.AddScoped<IB2CConsultaProdutosCodebarService, B2CConsultaProdutosCodebarService>();
            services.AddScoped<IB2CConsultaProdutosCodebarRepository, B2CConsultaProdutosCodebarRepository>();
            services.AddScoped<IB2CConsultaProdutosCodebarCommandHandler, B2CConsultaProdutosCodebarCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCodebarValidator>();

            services.AddScoped<IB2CConsultaProdutosCustosService, B2CConsultaProdutosCustosService>();
            services.AddScoped<IB2CConsultaProdutosCustosRepository, B2CConsultaProdutosCustosRepository>();
            services.AddScoped<IB2CConsultaProdutosCustosCommandHandler, B2CConsultaProdutosCustosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosCustosValidator>();

            services.AddScoped<IB2CConsultaProdutosDepositosService, B2CConsultaProdutosDepositosService>();
            services.AddScoped<IB2CConsultaProdutosDepositosRepository, B2CConsultaProdutosDepositosRepository>();
            services.AddScoped<IB2CConsultaProdutosDepositosCommandHandler, B2CConsultaProdutosDepositosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosDepositosValidator>();

            services.AddScoped<IB2CConsultaProdutosDetalhesService, B2CConsultaProdutosDetalhesService>();
            services.AddScoped<IB2CConsultaProdutosDetalhesRepository, B2CConsultaProdutosDetalhesRepository>();
            services.AddScoped<IB2CConsultaProdutosDetalhesCommandHandler, B2CConsultaProdutosDetalhesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosDetalhesValidator>();

            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosService, B2CConsultaProdutosDetalhesDepositosService>();
            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosRepository, B2CConsultaProdutosDetalhesDepositosRepository>();
            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosCommandHandler, B2CConsultaProdutosDetalhesDepositosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosDetalhesDepositosValidator>();

            services.AddScoped<IB2CConsultaProdutosDimensoesService, B2CConsultaProdutosDimensoesService>();
            services.AddScoped<IB2CConsultaProdutosDimensoesRepository, B2CConsultaProdutosDimensoesRepository>();
            services.AddScoped<IB2CConsultaProdutosDimensoesCommandHandler, B2CConsultaProdutosDimensoesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosDimensoesValidator>();

            services.AddScoped<IB2CConsultaProdutosFlagsService, B2CConsultaProdutosFlagsService>();
            services.AddScoped<IB2CConsultaProdutosFlagsRepository, B2CConsultaProdutosFlagsRepository>();
            services.AddScoped<IB2CConsultaProdutosFlagsCommandHandler, B2CConsultaProdutosFlagsCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosFlagsValidator>();

            services.AddScoped<IB2CConsultaProdutosImagensService, B2CConsultaProdutosImagensService>();
            services.AddScoped<IB2CConsultaProdutosImagensRepository, B2CConsultaProdutosImagensRepository>();
            services.AddScoped<IB2CConsultaProdutosImagensCommandHandler, B2CConsultaProdutosImagensCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosImagensValidator>();

            services.AddScoped<IB2CConsultaProdutosInformacoesService, B2CConsultaProdutosInformacoesService>();
            services.AddScoped<IB2CConsultaProdutosInformacoesRepository, B2CConsultaProdutosInformacoesRepository>();
            services.AddScoped<IB2CConsultaProdutosInformacoesCommandHandler, B2CConsultaProdutosInformacoesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosInformacoesValidator>();

            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaService, B2CConsultaProdutosPalavrasChavePesquisaService>();
            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaRepository, B2CConsultaProdutosPalavrasChavePesquisaRepository>();
            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaCommandHandler, B2CConsultaProdutosPalavrasChavePesquisaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosPalavrasChavePesquisaValidator>();

            services.AddScoped<IB2CConsultaProdutosPromocaoService, B2CConsultaProdutosPromocaoService>();
            services.AddScoped<IB2CConsultaProdutosPromocaoRepository, B2CConsultaProdutosPromocaoRepository>();
            services.AddScoped<IB2CConsultaProdutosPromocaoCommandHandler, B2CConsultaProdutosPromocaoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosPromocaoValidator>();

            services.AddScoped<IB2CConsultaProdutosStatusService, B2CConsultaProdutosStatusService>();
            services.AddScoped<IB2CConsultaProdutosStatusRepository, B2CConsultaProdutosStatusRepository>();
            services.AddScoped<IB2CConsultaProdutosStatusCommandHandler, B2CConsultaProdutosStatusCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosStatusValidator>();

            services.AddScoped<IB2CConsultaProdutosTabelasService, B2CConsultaProdutosTabelasService>();
            services.AddScoped<IB2CConsultaProdutosTabelasRepository, B2CConsultaProdutosTabelasRepository>();
            services.AddScoped<IB2CConsultaProdutosTabelasCommandHandler, B2CConsultaProdutosTabelasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosTabelasValidator>();

            services.AddScoped<IB2CConsultaProdutosTabelasPrecosService, B2CConsultaProdutosTabelasPrecosService>();
            services.AddScoped<IB2CConsultaProdutosTabelasPrecosRepository, B2CConsultaProdutosTabelasPrecosRepository>();
            services.AddScoped<IB2CConsultaProdutosTabelasPrecosCommandHandler, B2CConsultaProdutosTabelasPrecosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosTabelasPrecosValidator>();

            services.AddScoped<IB2CConsultaProdutosTagsService, B2CConsultaProdutosTagsService>();
            services.AddScoped<IB2CConsultaProdutosTagsRepository, B2CConsultaProdutosTagsRepository>();
            services.AddScoped<IB2CConsultaProdutosTagsCommandHandler, B2CConsultaProdutosTagsCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaProdutosTagsValidator>();

            services.AddScoped<IB2CConsultaSetoresService, B2CConsultaSetoresService>();
            services.AddScoped<IB2CConsultaSetoresRepository, B2CConsultaSetoresRepository>();
            services.AddScoped<IB2CConsultaSetoresCommandHandler, B2CConsultaSetoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaSetoresValidator>();

            services.AddScoped<IB2CConsultaStatusService, B2CConsultaStatusService>();
            services.AddScoped<IB2CConsultaStatusRepository, B2CConsultaStatusRepository>();
            services.AddScoped<IB2CConsultaStatusCommandHandler, B2CConsultaStatusCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaStatusValidator>();

            services.AddScoped<IB2CConsultaTagsService, B2CConsultaTagsService>();
            services.AddScoped<IB2CConsultaTagsRepository, B2CConsultaTagsRepository>();
            services.AddScoped<IB2CConsultaTagsCommandHandler, B2CConsultaTagsCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaTagsValidator>();

            services.AddScoped<IB2CConsultaTipoEncomendaService, B2CConsultaTipoEncomendaService>();
            services.AddScoped<IB2CConsultaTipoEncomendaRepository, B2CConsultaTipoEncomendaRepository>();
            services.AddScoped<IB2CConsultaTipoEncomendaCommandHandler, B2CConsultaTipoEncomendaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaTipoEncomendaValidator>();

            services.AddScoped<IB2CConsultaTiposCobrancaFreteService, B2CConsultaTiposCobrancaFreteService>();
            services.AddScoped<IB2CConsultaTiposCobrancaFreteRepository, B2CConsultaTiposCobrancaFreteRepository>();
            services.AddScoped<IB2CConsultaTiposCobrancaFreteCommandHandler, B2CConsultaTiposCobrancaFreteCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaTiposCobrancaFreteValidator>();

            services.AddScoped<IB2CConsultaTransportadoresService, B2CConsultaTransportadoresService>();
            services.AddScoped<IB2CConsultaTransportadoresRepository, B2CConsultaTransportadoresRepository>();
            services.AddScoped<IB2CConsultaTransportadoresCommandHandler, B2CConsultaTransportadoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaTransportadoresValidator>();

            services.AddScoped<IB2CConsultaUnidadeService, B2CConsultaUnidadeService>();
            services.AddScoped<IB2CConsultaUnidadeRepository, B2CConsultaUnidadeRepository>();
            services.AddScoped<IB2CConsultaUnidadeCommandHandler, B2CConsultaUnidadeCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaUnidadeValidator>();

            services.AddScoped<IB2CConsultaVendedoresService, B2CConsultaVendedoresService>();
            services.AddScoped<IB2CConsultaVendedoresRepository, B2CConsultaVendedoresRepository>();
            services.AddScoped<IB2CConsultaVendedoresCommandHandler, B2CConsultaVendedoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<B2CConsultaVendedoresValidator>();

            return services;
        }

        public static IServiceCollection AddScopedLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixCommandHandler, LinxMicrovixCommandHandler>();
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped<IAPICall, APICall>();

            services.AddScoped<ILinxClientesFornecService, LinxClientesFornecService>();
            services.AddScoped<ILinxClientesFornecRepository, LinxClientesFornecRepository>();
            services.AddScoped<ILinxClientesFornecCommandHandler, LinxClientesFornecCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxClientesFornecValidator>();

            services.AddScoped<ILinxClientesEnderecosEntregaService, LinxClientesEnderecosEntregaService>();
            services.AddScoped<ILinxClientesEnderecosEntregaRepository, LinxClientesEnderecosEntregaRepository>();
            services.AddScoped<ILinxClientesEnderecosEntregaCommandHandler, LinxClientesEnderecosEntregaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxClientesEnderecosEntregaValidator>();

            services.AddScoped<ILinxMovimentoService, LinxMovimentoService>();
            services.AddScoped<ILinxMovimentoRepository, LinxMovimentoRepository>();
            services.AddScoped<ILinxMovimentoCommandHandler, LinxMovimentoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxMovimentoValidator>();

            services.AddScoped<ILinxMovimentoCartoesService, LinxMovimentoCartoesService>();
            services.AddScoped<ILinxMovimentoCartoesRepository, LinxMovimentoCartoesRepository>();
            services.AddScoped<ILinxMovimentoCartoesCommandHandler, LinxMovimentoCartoesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxMovimentoCartoesValidator>();

            services.AddScoped<ILinxMovimentoPlanosService, LinxMovimentoPlanosService>();
            services.AddScoped<ILinxMovimentoPlanosRepository, LinxMovimentoPlanosRepository>();
            services.AddScoped<ILinxMovimentoPlanosCommandHandler, LinxMovimentoPlanosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxMovimentoPlanosValidator>();

            services.AddScoped<ILinxMovimentoTrocasService, LinxMovimentoTrocasService>();
            services.AddScoped<ILinxMovimentoTrocasRepository, LinxMovimentoTrocasRepository>();
            services.AddScoped<ILinxMovimentoTrocasCommandHandler, LinxMovimentoTrocasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxMovimentoTrocasValidator>();

            services.AddScoped<ILinxPlanosService, LinxPlanosService>();
            services.AddScoped<ILinxPlanosRepository, LinxPlanosRepository>();
            services.AddScoped<ILinxPlanosCommandHandler, LinxPlanosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxPlanosValidator>();

            services.AddScoped<ILinxNaturezaOperacaoService, LinxNaturezaOperacaoService>();
            services.AddScoped<ILinxNaturezaOperacaoRepository, LinxNaturezaOperacaoRepository>();
            services.AddScoped<ILinxNaturezaOperacaoCommandHandler, LinxNaturezaOperacaoCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxNaturezaOperacaoValidator>();

            services.AddScoped<ILinxProdutosService, LinxProdutosService>();
            services.AddScoped<ILinxProdutosRepository, LinxProdutosRepository>();
            services.AddScoped<ILinxProdutosCommandHandler, LinxProdutosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosValidator>();

            services.AddScoped<ILinxProdutosCodBarService, LinxProdutosCodBarService>();
            services.AddScoped<ILinxProdutosCodBarRepository, LinxProdutosCodBarRepository>();
            services.AddScoped<ILinxProdutosCodBarCommandHandler, LinxProdutosCodBarCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosCodBarValidator>();

            services.AddScoped<ILinxProdutosTabelasService, LinxProdutosTabelasService>();
            services.AddScoped<ILinxProdutosTabelasRepository, LinxProdutosTabelasRepository>();
            services.AddScoped<ILinxProdutosTabelasCommandHandler, LinxProdutosTabelasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosTabelasValidator>();

            services.AddScoped<ILinxProdutosTabelasPrecosService, LinxProdutosTabelasPrecosService>();
            services.AddScoped<ILinxProdutosTabelasPrecosRepository, LinxProdutosTabelasPrecosRepository>();
            services.AddScoped<ILinxProdutosTabelasPrecosCommandHandler, LinxProdutosTabelasPrecosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosTabelasPrecosValidator>();

            services.AddScoped<ILinxProdutosInventarioService, LinxProdutosInventarioService>();
            services.AddScoped<ILinxProdutosInventarioRepository, LinxProdutosInventarioRepository>();
            services.AddScoped<ILinxProdutosInventarioCommandHandler, LinxProdutosInventarioCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosInventarioValidator>();

            services.AddScoped<ILinxProdutosDetalhesService, LinxProdutosDetalhesService>();
            services.AddScoped<ILinxProdutosDetalhesRepository, LinxProdutosDetalhesRepository>();
            services.AddScoped<ILinxProdutosDetalhesCommandHandler, LinxProdutosDetalhesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosDetalhesValidator>();

            services.AddScoped<ILinxProdutosDepositosService, LinxProdutosDepositosService>();
            services.AddScoped<ILinxProdutosDepositosRepository, LinxProdutosDepositosRepository>();
            services.AddScoped<ILinxProdutosDepositosCommandHandler, LinxProdutosDepositosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosDepositosValidator>();

            services.AddScoped<ILinxProdutosPromocoesService, LinxProdutosPromocoesService>();
            services.AddScoped<ILinxProdutosPromocoesRepository, LinxProdutosPromocoesRepository>();
            services.AddScoped<ILinxProdutosPromocoesCommandHandler, LinxProdutosPromocoesCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosPromocoesValidator>();

            services.AddScoped<ILinxProdutosCamposAdicionaisService, LinxProdutosCamposAdicionaisService>();
            services.AddScoped<ILinxProdutosCamposAdicionaisRepository, LinxProdutosCamposAdicionaisRepository>();
            services.AddScoped<ILinxProdutosCamposAdicionaisCommandHandler, LinxProdutosCamposAdicionaisCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxProdutosCamposAdicionaisValidator>();

            services.AddScoped<ILinxB2CPedidosService, LinxB2CPedidosService>();
            services.AddScoped<ILinxB2CPedidosRepository, LinxB2CPedidosRepository>();
            services.AddScoped<ILinxB2CPedidosCommandHandler, LinxB2CPedidosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxB2CPedidosValidator>();

            services.AddScoped<ILinxB2CPedidosItensService, LinxB2CPedidosItensService>();
            services.AddScoped<ILinxB2CPedidosItensRepository, LinxB2CPedidosItensRepository>();
            services.AddScoped<ILinxB2CPedidosItensCommandHandler, LinxB2CPedidosItensCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxB2CPedidosItensValidator>();

            services.AddScoped<ILinxB2CPedidosStatusService, LinxB2CPedidosStatusService>();
            services.AddScoped<ILinxB2CPedidosStatusRepository, LinxB2CPedidosStatusRepository>();
            services.AddScoped<ILinxB2CPedidosStatusCommandHandler, LinxB2CPedidosStatusCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxB2CPedidosStatusValidator>();

            services.AddScoped<ILinxB2CStatusService, LinxB2CStatusService>();
            services.AddScoped<ILinxB2CStatusRepository, LinxB2CStatusRepository>();
            services.AddScoped<ILinxB2CStatusCommandHandler, LinxB2CStatusCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxB2CStatusValidator>();

            services.AddScoped<ILinxPedidosVendaService, LinxPedidosVendaService>();
            services.AddScoped<ILinxPedidosVendaRepository, LinxPedidosVendaRepository>();
            services.AddScoped<ILinxPedidosVendaCommandHandler, LinxPedidosVendaCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxPedidosVendaValidator>();

            services.AddScoped<ILinxPedidosCompraService, LinxPedidosCompraService>();
            services.AddScoped<ILinxPedidosCompraRepository, LinxPedidosCompraRepository>();
            services.AddScoped<ILinxPedidosCompraCommandHandler, LinxPedidosCompraCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxPedidosCompraValidator>();

            services.AddScoped<ILinxGrupoLojasService, LinxGrupoLojasService>();
            services.AddScoped<ILinxGrupoLojasRepository, LinxGrupoLojasRepository>();
            services.AddScoped<ILinxGrupoLojasCommandHandler, LinxGrupoLojasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxGrupoLojasValidator>();

            services.AddScoped<ILinxLojasService, LinxLojasService>();
            services.AddScoped<ILinxLojasRepository, LinxLojasRepository>();
            services.AddScoped<ILinxLojasCommandHandler, LinxLojasCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxLojasValidator>();

            services.AddScoped<ILinxSetoresService, LinxSetoresService>();
            services.AddScoped<ILinxSetoresRepository, LinxSetoresRepository>();
            services.AddScoped<ILinxSetoresCommandHandler, LinxSetoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxSetoresValidator>();

            services.AddScoped<ILinxVendedoresService, LinxVendedoresService>();
            services.AddScoped<ILinxVendedoresRepository, LinxVendedoresRepository>();
            services.AddScoped<ILinxVendedoresCommandHandler, LinxVendedoresCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxVendedoresValidator>();

            services.AddScoped<ILinxUsuariosService, LinxUsuariosService>();
            services.AddScoped<ILinxUsuariosRepository, LinxUsuariosRepository>();
            services.AddScoped<ILinxUsuariosCommandHandler, LinxUsuariosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxUsuariosValidator>();

            services.AddScoped<ILinxCfopFiscalService, LinxCfopFiscalService>();
            services.AddScoped<ILinxCfopFiscalRepository, LinxCfopFiscalRepository>();
            services.AddScoped<ILinxCfopFiscalCommandHandler, LinxCfopFiscalCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxCfopFiscalValidator>();

            services.AddScoped<ILinxRotinaOrigemService, LinxRotinaOrigemService>();
            services.AddScoped<ILinxRotinaOrigemRepository, LinxRotinaOrigemRepository>();
            services.AddScoped<ILinxRotinaOrigemCommandHandler, LinxRotinaOrigemCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxRotinaOrigemValidator>();

            services.AddScoped<ILinxXMLDocumentosService, LinxXMLDocumentosService>();
            services.AddScoped<ILinxXMLDocumentosRepository, LinxXMLDocumentosRepository>();
            services.AddScoped<ILinxXMLDocumentosCommandHandler, LinxXMLDocumentosCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<LinxXMLDocumentosValidator>();

            return services;
        }

        public static IServiceCollection AddDbContextLinxMicrovixService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<LinxMicrovixOutboundTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<LinxMicrovixOutboundUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<LinxMicrovixOutboundTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<LinxMicrovixOutboundUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<LinxMicrovixOutboundTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<LinxMicrovixOutboundUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
