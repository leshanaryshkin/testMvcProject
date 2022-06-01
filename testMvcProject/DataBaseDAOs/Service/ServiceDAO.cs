using System.Collections.Generic;
using System.Linq;
using testMvcProject.DataBase;

namespace testMvcProject.DataBaseDAOs.Service
{
    public class ServiceDAO : IServiceManager
    {
        private readonly DBContext2 dBContext;

        public ServiceDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<AdditionalService> GetAll() => dBContext.Services.ToList();
        public void Add(AdditionalService newService)
        {
            dBContext.Services.Add(newService);

            dBContext.SaveChanges();
        }

        public void ChangeActual(string name)
        {
            DataBase.AdditionalService editService = new DataBase.AdditionalService();
            editService = Get(name);
            editService.isActual = !editService.isActual;
                dBContext.Entry(editService).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();
                
        }
        
        public AdditionalService Get(string name) => dBContext.Services.FirstOrDefault(p => p.ServiceName == name);
    }
}