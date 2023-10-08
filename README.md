# ProgTVProcessor

Desafio técnico para a vaga de desenvolvedor .NET na ProgramadorTV. O desafio consistiu em gerar uma aplicação com Razor Pages que permitisse upar um vídeo e enviá-lo, sem reiniciar a página, para processamento no back-end. Como resultado, as mais diversas informações sobre o arquivo, como título, formato, duração, resolução, codec, etc deveriam ser exibidas de volta no front. Utilizei o FFmpeg para processar o vídeo e a biblioteca Xabe.FFMpeg para facilitar a integração. Nas requisições JavaScript utilizei o próprio JQuery imbutido na aplicação para facilitar a manipulação do DOM e requisitar os dados do back-end com AJAX.

# Demonstração

<img src="./demo_prog_tv_processor.gif" alt="ProgTVProcessor em ação 🦸🏾‍♂️" title="ProgTVProcessor em ação 🦸🏾‍♂️">

# Tecnologias

- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-7.0): Plataforma de desenvolvimento web da Microsoft.
- [Razor Pages](https://learn.microsoft.com/pt-br/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio): Estrutura para construção de páginas web baseadas em Razor.
- [.NET 6](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6): Plataforma de desenvolvimento de aplicações multiplataforma da Microsoft.

# Dependências

- [Xabe.FFMpeg](https://github.com/tomaszzmuda/Xabe.FFMpeg): Biblioteca .NET para trabalhar com FFmpeg.

# Informação importante

A aplicação requer que o FFmpeg esteja instalado e, preferencialmente, configurado no PATH do sistema operacional.

Caso não esteja, baixe o FFmpeg em https://ffmpeg.org/download.html e siga as instruções de instalação para o seu sistema operacional.

Importante: no Arquivo `Program.cs`, na linha 9, altere o valor da variável `FFMPEG_PATH` de acordo com o caminho de instalação do FFmpeg no seu sistema operacional. O meu, por exemplo, está instalado em `C:\ffmpeg\bin` e por isso o valor da variável é `@"C:\ffmpeg\bin"`.

# Como Executar

Faça o clone do repositório, execute o comando `dotnet restore` na pasta raiz do projeto para baixar as dependencias e execute o comando `dotnet run` para iniciar a aplicação.

# Como funciona

A aplicação é composta por uma única página, `Index.cshtml`, que contém um input para upload de um arquivo de vídeo e um botão de envio. Após o upload, o arquivo é processado pelo FFmpeg e as informações são exibidas na tela, sem a necessidade de recarregar a página, em formato JSON. É possível fazer o download dos dados do JSON no botão "Baixar JSON"
