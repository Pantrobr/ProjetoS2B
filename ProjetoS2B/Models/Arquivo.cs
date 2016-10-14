using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoS2B.Models
{
    public enum TipoArquivo
    {
        Foto = 1,
        Documento = 2
    }

    public class Arquivo
    {
        public int ArquivoId { get; set; }
        public string NomeArquivo { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public TipoArquivo TipoArquivo { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}