using Dapper;
using Northwind.DB.Interface;
using Northwind.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DB
{
    public class RegionRepository : IRepository<Region, int>
    {
        private readonly string connectionString;

        public RegionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Region> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Region>("SELECT * FROM Region");
            }
        }

        public Region Get(int key)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Region>("SELECT * FROM Region where RegionID=@RegionID", new { RegionID = key }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Создать новый регион
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(Region entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = @"Declare @ID int;
                                 select @ID = max(RegionID)+1 from Region
                                 INSERT INTO Region (RegionID, RegionDescription) VALUES(@ID, @RegionDescription)
                                 select @ID";
                return db.Query<int>(sqlQuery, new { RegionDescription = entity.RegionDescription }).Single();
            }
        }

        public int Update(Region entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update Region Set RegionDescription = @RegionDescription Where RegionID = @RegionID";
                return db.Execute(sqlQuery, entity);
            }
        }

        public int Delete(int key)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Region WHERE RegionID = @RegionID";
                return db.Execute(sqlQuery, new { RegionID = key });
            }
        }
    }
}
