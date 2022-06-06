using System;
namespace InventoryManager.Application.Response
{
    /// <summary>
    /// Clase base para retornar respuestas más complejas
    /// </summary>
    public class BaseResponse
    {
        public int Id { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}

