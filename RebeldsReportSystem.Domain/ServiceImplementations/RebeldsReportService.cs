using RebeldsReportSystem.Domain.CustomExceptions;
using RebeldsReportSystem.Domain.DomainEntities;
using RebeldsReportSystem.Domain.RepositoryContracts;
using RebeldsReportSystem.Domain.ServiceContracts;
using System;
using System.Collections.Generic;

namespace RebeldsReportSystem.Domain.ServiceImplementations
{
    public class RebeldsReportService : IRebeldsReportService
    {
        //  Variable de solo lectura para el repositorio de informes de rebeldes.
        private readonly IRebeldsReportRepository _repository;
        public RebeldsReportService(IRebeldsReportRepository rep)
        {
            // Constructor  que recibe una instancia del repositorio de informes de rebeldes.
            // Asigna el repositorio recibido a la variable _repository.
            _repository = rep;
            
        }
    

        public void CreateRebeldReport(RebeldsReport rebeldsReport)
        {
            try
            {
                // Metodo de la interfaz IRebeldsReportService que implementa la creación de un informe de rebeldes.
                _repository.Insert(rebeldsReport);
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción que ocurra durante la inserción del informe en el repositorio.                
                throw new CannotSaveDataException(ex.Message);
            }
        }      
    }
}
