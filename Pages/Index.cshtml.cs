using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xabe.FFmpeg;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public IndexModel(IWebHostEnvironment environment)
    {
        _environment = environment;
        /* Caso tu já tenhas o ffmpeg na máquina e configurado no Path, pode comentar a linha de baixo.
         * Precisei configurar o caminho pois o programa não estava reconhecendo o ffmpeg no meu Path :( */
        FFmpeg.SetExecutablesPath(@"C:\ffmpeg\bin");
    }

    public IActionResult OnPostProcessVideo()
    {
        var videoFile = Request.Form.Files["videoFile"];

        if (videoFile != null && videoFile.Length > 0)
        {
            var tempFilePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "temp", videoFile.FileName);
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                videoFile.CopyTo(stream);
            }

            var info = FFmpeg.GetMediaInfo(tempFilePath);
            var videoStream = info.Result.VideoStreams.FirstOrDefault();
            var audioStream = info.Result.AudioStreams.FirstOrDefault();

            var videoInfo = new
            {
                Title = videoFile.FileName,
                Duration = videoStream != null ? videoStream.Duration.ToString(@"hh\:mm\:ss") : "Desconhecido",
                Resolution = videoStream != null ? $"{videoStream.Width}x{videoStream.Height}" : "Desconhecido",
                FrameRate = videoStream != null ? videoStream.Framerate : 0,
                AspectRatio = videoStream != null ? videoStream.Ratio : "Desconhecido",
                AudioChannels = audioStream != null ? audioStream.Channels : 0,
                AudioSampleRate = audioStream != null ? audioStream.SampleRate : 0,
                AudioCodec = audioStream != null ? audioStream.Codec : "Desconhecido",
            };
            System.IO.File.Delete(tempFilePath);

            return new JsonResult(videoInfo);
        }

        return new JsonResult("Nenhum vídeo enviado.");
    }
}
