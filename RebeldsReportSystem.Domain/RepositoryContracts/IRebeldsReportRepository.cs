using RebeldsReportSystem.Domain.DomainEntities;
using System.Collections.Generic;


namespace RebeldsReportSystem.Domain.RepositoryContracts
{

    // Define una interfaz llamada IRebeldsReportRepository para el contrato de repositorio de informes de rebeldes
    public interface IRebeldsReportRepository
    {
        void Insert(RebeldsReport rebeldsReport);
        // Metodo de la interfaz que especifica la inserción de un informe de rebeldes en el repositorio.
        // Recibe como parámetro un objeto del tipo RebeldsReport.
        
    }

}

