using RebeldsReportSystem.Domain.CustomExceptions;
using RebeldsReportSystem.Domain.DomainEntities;
using RebeldsReportSystem.Domain.ServiceContracts;
using System.Collections.Generic;
using System.Web.Http;

namespace RebeldsReportSystem.WebAPI.Controllers
{
    /// <summary>
    /// Acciones para gestionar rebeldes
    /// </summary>

    // Define la clase del controlador para los informes de rebeldes
    public class RebeldsReportController : ApiController
    {
        // Declara una variable de solo lectura para el servicio de informes de rebeldes
        private readonly IRebeldsReportService _service;

        // Constructor del controlador que recibe una instancia del servicio de informes de rebeldes
        public RebeldsReportController(IRebeldsReportService service)
        {
            //// Asigna el servicio recibido a la variable _service
            _service = service;

        }
        
        /// <summary>
        /// Accion para registrar Rebeld Report
        /// </summary>
        /// <param name="rebeldReport">Introduce:["NameRebeld", "NamePlanet"]</param>        
        /// <returns></returns>
        [HttpPost]

        // Método de accion para registrar un informe de rebeldes, recibe una lista de string como parámetro
        public IHttpActionResult Register(List<string> rebeldReport)
        {
            // Verificamos si la lista de informes de rebeldes es nula o no y si contiene exactamente 2 elementos
            if (rebeldReport == null || rebeldReport.Count != 2)
            {
                // Devuelve una respuesta de error con el mensaje "nombre y planeta requeridos"
                return BadRequest("name and planet required"); 

            }    

            // Creamos una nueva instancia de la clase RebeldsReport
            RebeldsReport report = new RebeldsReport();          
            report.rebeldName = rebeldReport[0];
            report.planetName = rebeldReport[1];

            try
            {
                // Llama al mtodo CreateRebeldReport del servicio para crear el informe de rebeldes                
                _service.CreateRebeldReport(report);

                return Ok("Report received");
            }
            // Capturamos la excepción si no se pueden guardar los datos            
            catch (CannotSaveDataException ex)
            {
                return BadRequest($"Some error occured while trying to save data: {ex.Message}");
            }
        }
       
    }
}
