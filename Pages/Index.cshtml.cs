using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xabe.FFmpeg;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public IndexModel(IWebHostEnvironment environment)
    {
        _environment = environment;

        var ffmpegPath = Environment.GetEnvironmentVariable("FFMPEG_PATH");
        FFmpeg.SetExecutablesPath(ffmpegPath);
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
            var videoStream = info.Result?.VideoStreams?.FirstOrDefault();
            var audioStream = info.Result?.AudioStreams?.FirstOrDefault();

            var videoInfo = new
            {
                Title = videoFile.FileName.Split('.').First(),
                Format = videoFile.FileName.Trim().Split('.').Last(),
                Size = videoFile.Length,
                SizeFormated = videoFile.Length.ToString().Length > 6 ? $"~ {videoFile.Length / 1000000} MB" : $"~ {videoFile.Length / 1000} KB",
                Duration = videoStream != null ? videoStream.Duration.ToString(@"hh\:mm\:ss") : "Desconhecido",
                Resolution = videoStream != null ? $"{videoStream.Width}x{videoStream.Height}" : "Desconhecido",
                VideoCodec = videoStream != null ? videoStream.Codec : "Desconhecido",
                FrameRate = videoStream != null ? videoStream.Framerate : 0,
                AspectRatio = videoStream != null ? videoStream.Ratio : "Desconhecido",
                AudioChannels = audioStream != null ? audioStream.Channels : 0,
                AudioSampleRate = audioStream != null ? audioStream.SampleRate : 0,
                AudioCodec = audioStream != null ? audioStream.Codec : "Desconhecido",
                AudioBitrate = audioStream != null ? audioStream.Bitrate : 0,
            };
            System.IO.File.Delete(tempFilePath);
            return new JsonResult(videoInfo);
        }

        return new JsonResult("Nenhum vídeo enviado.");
    }
}
