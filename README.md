# EscreveHoraAtualArquivoLogMinutoWorkerService

# Windows Service - Escreve Hora Atual no Arquivo de Log

Este projeto demonstra a criação de um Windows Service simples usando o .NET 7.0 e o Visual Studio 2022. O serviço escreve a hora atual em um arquivo de log chamado `log.txt` a cada segundo.

## Configuração do Projeto

1. Abra o Visual Studio 2022 e crie um novo projeto.
2. Selecione "Worker Service" como tipo de projeto e clique em "Next".
3. Escolha um nome e local para o projeto e clique em "Create".
4. Substitua o código da classe `Worker` no arquivo `Worker.cs` pelo código fornecido neste repositório.
5. Salve o arquivo e construa (build) o projeto.

## Instalação e Execução do Windows Service

Para instalar e executar o serviço, siga os passos abaixo:

1. Abra o prompt de comando como administrador.
2. Navegue até a pasta onde o executável do projeto foi gerado (geralmente na pasta `bin\Debug\net7.0` dentro do diretório do projeto).
3. Execute o comando `sc create` para criar o serviço, substituindo `[YourServiceName]` e `[FullPathToYourExecutable]` pelos valores apropriados. Por exemplo:
  sc create MeuTempoLoggerService binPath= "C:\workspace\Windows Service\EscreveHoraAtualArquivoLogMinutoWorkerService\EscreveHoraAtualArquivoLogMinutoWorkerService\bin\Debug\net7.0\EscreveHoraAtualArquivoLogMinutoWorkerService.exe"
  
  
4. Inicie o serviço usando o comando `sc start YourServiceName`. Por exemplo:
  sc start MeuTempoLoggerService


O serviço agora está sendo executado e deve criar um arquivo chamado `log.txt` no diretório "log" a cada segundo, registrando a hora atual.

## Parar e Remover o Windows Service

Para parar e remover o serviço, siga os passos abaixo:

1. Pare o serviço usando o comando `sc stop YourServiceName`. Por exemplo:

  sc stop MeuTempoLoggerService

