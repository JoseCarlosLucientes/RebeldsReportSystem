using System;

namespace RebeldsReportSystem.Domain.CustomExceptions
{
    
    public class CannotSaveDataException : Exception
    {             
        public CannotSaveDataException()
        {
            
        }
        // Constructor con un parametro de string para la excepcion CannotSaveDataException,
        // llama al constructor de la clase base (Exception) con el mensaje recibido
        public CannotSaveDataException(string message) : base(message) { }
    }
}
