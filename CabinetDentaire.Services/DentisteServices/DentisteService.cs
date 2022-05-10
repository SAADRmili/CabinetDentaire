
using CabinetDentaire.Postgresql;
using CabinetDentaire.Shared.Entities;
using Dapper;

namespace CabinetDentaire.Services
{
    public class DentisteService : IDentisteService
    {
        private readonly IPostgreSqlServices _postgreSqlServices;
        public DentisteService(IPostgreSqlServices postgreSqlServices)
        {
            _postgreSqlServices = postgreSqlServices;
        }
        public Task<IEnumerable<Dentiste>> GetDentistes()
        {
            var query = " select * from dentistes join workcategories ON workcategories.id = dentistes.workcategoryid";

            return _postgreSqlServices.QueryMultiAsync<Dentiste, WorkCategory, Dentiste>(query, (dentiste, work) =>
           {
               dentiste.WorkCategory = work;
               return dentiste;
           });
        }

        public async Task<int> UpdateTimeWorkDentiste(Guid id, WorkCategory workCategory)
        {
            var query = "select * from dentistes where id = @id ";

            var parms = new DynamicParameters();
            parms.Add("id", id, System.Data.DbType.Guid);

            var workCat = await _postgreSqlServices.QueryFirstOrDefaultAsync<Dentiste>(query, parms);

            if (workCat != null)
            {
                var queryUpdate = "Update  workcategories set hourstartwork = @hourstartwork , hourendwork = @hourendwork where id = @idwork  ";

                parms.Add("idwork", workCat.WorkCategoryId, System.Data.DbType.Guid);
                parms.Add("hourstartwork", workCategory.HourStartWork, System.Data.DbType.Time);
                parms.Add("hourendwork", workCategory.HourEndWork, System.Data.DbType.Time);
                return await _postgreSqlServices.ExecuteAsync(queryUpdate, parms);
            }

            return 0;
        }
    }
}
