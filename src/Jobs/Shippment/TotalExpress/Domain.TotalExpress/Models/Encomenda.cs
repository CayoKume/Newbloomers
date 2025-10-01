﻿using Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TotalExpress.Models
{
    public class Encomenda
    {
        public string pedido { get; private set; }
        public string clienteCodigo { get; private set; }
        public string tipoServico { get; private set; }
        public string data { get; private set; }
        public string hora { get; private set; }
        public Int64 remetenteid { get; private set; }
        
        [SkipProperty]
        public List<Volume> volumes { get; private set; } = new List<Volume>();
        
        [SkipProperty]
        public List<Documentofiscal> documentoFiscal { get; private set; } = new List<Documentofiscal>();

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public Encomenda() { }

        public Encomenda(Dtos.Return.Encomenda encomenda, string retorno, string sender_id)
        {
            this.pedido = encomenda.pedido;
            this.clienteCodigo = encomenda.clienteCodigo;
            this.tipoServico = encomenda.tipoServico;
            this.data = encomenda.data;
            this.hora = encomenda.hora;
            this.recordKey = encomenda.pedido;
            this.recordXml = retorno;
            this.remetenteid = CustomConvertersExtensions.ConvertToInt64Validation(sender_id);

            foreach (var documento in encomenda.documentoFiscal)
            {
                this.documentoFiscal.Add(new Documentofiscal(documento, encomenda.pedido));
            }

            foreach (var volume in encomenda.volumes)
            {
                this.volumes.Add(new Volume(volume, encomenda.pedido));
            }
        }
    }
}
