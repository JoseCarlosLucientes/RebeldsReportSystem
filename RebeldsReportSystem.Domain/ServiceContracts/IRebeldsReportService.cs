using RebeldsReportSystem.Domain.DomainEntities;
using System.Collections.Generic;

namespace RebeldsReportSystem.Domain.ServiceContracts
{

    // Define una interfaz  para el contrato de servicio de informes de rebeldes.
    public interface IRebeldsReportService
    {  
        void CreateRebeldReport(RebeldsReport rebeldsReport);
        // Método de la interfaz que especifica la creación de un informe de rebeldes.
        // Recibe como parámetro un objeto del tipo RebeldsReport.       


    }
}
