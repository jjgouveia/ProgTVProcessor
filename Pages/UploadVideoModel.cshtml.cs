using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class UploadVideoModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public UploadVideoModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult OnPostProcessVideo()
    {
        var videoFile = Request.Form.Files["videoFile"];

        Console.WriteLine("Video Info: " + videoFile.FileName);
        Console.WriteLine("Processando");

        if (videoFile != null && videoFile.Length > 0)
        {
            var videoInfo = ProcessVideo(videoFile);

            return new JsonResult(videoInfo);
        }

        return new JsonResult("Nenhum arquivo de vídeo enviado.");
    }

    private object ProcessVideo(IFormFile videoFile)

    {
        Console.WriteLine(videoFile);
      
        var videoInfo = new
        {
            Title = videoFile.FileName,
            Duration = "10 minutos",
            Resolution = "1920x1080",
            Format = "MP4"
        };

        return videoInfo;
    }
}
