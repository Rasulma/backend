using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly string _mediaPath = Path.Combine(Directory.GetCurrentDirectory(), "audio");

        [HttpGet("audio/{fileName}")]
        public IActionResult GetAudio(string fileName)
        {
            try
            {
                fileName = Path.GetFileName(fileName); // Nur den Dateinamen verwenden
                var filePath = Path.Combine(_mediaPath, fileName);

                // Datei existiert prüfen
                if (System.IO.File.Exists(filePath))
                {
                    return PhysicalFile(filePath, "audio/wav"); // Datei als Audio senden
                }
                else
                {
                    return NotFound("Audio file not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}