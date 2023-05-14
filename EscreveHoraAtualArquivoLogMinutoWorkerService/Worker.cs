namespace EscreveHoraAtualArquivoLogMinutoWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        int count;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            count= 0;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                WriteCurrentTimeToLogFile();
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void WriteCurrentTimeToLogFile()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFilePath = Path.Combine(logDirectory, "log.txt");
            using StreamWriter logFileWriter = new StreamWriter(logFilePath, true);
            logFileWriter.WriteLine($"{count} - Current Time: {DateTimeOffset.Now}");
            count++;
        }
    }
}