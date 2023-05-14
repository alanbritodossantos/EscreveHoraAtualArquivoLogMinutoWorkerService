using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EscreveHoraAtualArquivoLogMinutoWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        int count; // Vari�vel para contar o n�mero de vezes que a hora atual foi escrita no arquivo

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            count = 0; // Inicializa a contagem
        }

        // M�todo que � executado como um servi�o em segundo plano
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Continua executando at� que o servi�o seja interrompido
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                WriteCurrentTimeToLogFile();
                await Task.Delay(1000, stoppingToken); // Espera 1 segundo antes de executar novamente (alterado de 1 minuto para 1 segundo)
            }
        }

        // M�todo para escrever a hora atual no arquivo de log
        private void WriteCurrentTimeToLogFile()
        {
            // Define o caminho do diret�rio de log e verifica se ele existe. Se n�o existir, cria o diret�rio.
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Define o caminho do arquivo de log dentro do diret�rio de log
            string logFilePath = Path.Combine(logDirectory, "log.txt");

            // Abre o arquivo de log (ou cria um novo, se n�o existir) e escreve a contagem e a hora atual
            using StreamWriter logFileWriter = new StreamWriter(logFilePath, true);
            logFileWriter.WriteLine($"{count} - Current Time: {DateTimeOffset.Now}");

            count++; // Incrementa a contagem
        }
    }
}
