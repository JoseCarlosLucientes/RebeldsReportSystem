using RebeldsReportSystem.Domain.DomainEntities;
using RebeldsReportSystem.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RebeldsReportSystem.Infrastructure.Data.RepositoryImplementations
{
    public class RebeldsReportRepository : IRebeldsReportRepository
    {
        // Variable de solo lectura para almacenar la ruta completa del fichero.
        private readonly string _localDbFullPath;

        public RebeldsReportRepository()
        {
            // Constructor  que inicializa la variable _localDbFullPath con la ruta absoluta            
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "RebeldsReport.txt");
        }

        public void Insert(RebeldsReport rebeldsReport)
        {
            // Implementamos la inserción de un informe de rebeldes en el repositorio.           

            List<string> DbAsString = File.ReadAllLines(_localDbFullPath).ToList();

            string dataToInsert = $"_rebeld ({rebeldsReport.rebeldName}) on ({rebeldsReport.planetName}) at ({rebeldsReport.reportDate})_";

            DbAsString.Add(dataToInsert);

            File.WriteAllLines(_localDbFullPath, DbAsString);

        }
        

    }
}
