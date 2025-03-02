using ApiDispositivos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace ApiDispositivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {

        private readonly DispositivoService _dispositivoService;
        private readonly string _diretorioSalvarArquivo;
        
        public DispositivoController(DispositivoService dispositivoService)
        {
            _dispositivoService = dispositivoService;
            _diretorioSalvarArquivo = Path.Combine(Directory.GetCurrentDirectory(), "C:\\FSBRProjeto\\GerenciadorDeProdutos\\ArquivoCSV");
            if(!Directory.Exists(_diretorioSalvarArquivo))
            {
                Directory.CreateDirectory(_diretorioSalvarArquivo);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterDispositivoAppleEmCss()
        {
            var dispositivoApple = await _dispositivoService.ObterDispositivoAsync("Apple");

            if(dispositivoApple == null || dispositivoApple.Count == 0)
            {
                return NotFound("Nennhum dispositivo encontrado");

            }
            var nomeArquivoCSV = "dispositivos_apple.css";
            var caminhoArquivo = Path.Combine(_diretorioSalvarArquivo, nomeArquivoCSV);

            var sb = new StringBuilder();
            sb.AppendLine("Nome, Preco");
             
            foreach( var dispositivo in dispositivoApple)
            {
                sb.AppendLine($"{dispositivo.Name}, {dispositivo.Price.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            await System.IO.File.WriteAllTextAsync(caminhoArquivo, sb.ToString());
            //var  bytArray = Encoding.UTF8.GetBytes( sb.ToString() );
            //var stream = new MemoryStream(bytArray);

            // return File(stream, "text/csv", "dispositivoApple.csv");
            return Ok(new { Message = "Arquivo Salvo com sucesso", FilePath = caminhoArquivo });
        }
    }
}
