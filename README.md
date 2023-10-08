# ProgTVProcessor

Desafio técnico para a vaga de desenvolvedor .NET na ProgramadorTV. O desafio consistiu em gerar uma aplicação com Razor Pages que permitisse upar um vídeo e, sem reiniciar a página, processá-lo e exibir as mais diversas informações sobre do arquivo, como duração, resolução, bitrate, etc.

# Tecnologias

- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-7.0): Plataforma de desenvolvimento web da Microsoft.
- [Razor Pages](https://learn.microsoft.com/pt-br/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio): Estrutura para construção de páginas web baseadas em Razor.
- [.NET 6](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6): Plataforma de desenvolvimento de aplicações multiplataforma da Microsoft.

# Dependências

- [Xabe.FFMpeg](https://github.com/tomaszzmuda/Xabe.FFMpeg): Biblioteca .NET para trabalhar com FFmpeg.

# Como usar

A aplicação requer que o FFmpeg esteja instalado e, preferencialmente, configurado no PATH do sistema operacional.

Caso não esteja, baixe o FFmpeg em https://ffmpeg.org/download.html e siga as instruções de instalação para o seu sistema operacional.

Importante: no Arquivo `Program.cs`, na linha 9, altere o valor da variável `FFMPEG_PATH` de acordo com o caminho de instalação do FFmpeg no seu sistema operacional. O meu, por exemplo, está instalado em `C:\ffmpeg\bin` e por isso o valor da variável é `@"C:\ffmpeg\bin"`.

# Como funciona

A aplicação é composta por uma única página, `Index.cshtml`, que contém um formulário para upload de arquivos e uma tabela para exibir as informações do arquivo.
