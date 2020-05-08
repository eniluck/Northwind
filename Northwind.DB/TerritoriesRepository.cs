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
    class TerritoriesRepository : IRepository<Territories, int>
    {
        private readonly string connectionString;

        public TerritoriesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Territories> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Territories>("SELECT * FROM Territories");
            }
        }

        public Territories Get(int key)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Territories>("SELECT * FROM Territories where TerritoryID=@TerritoryID", new { TerritoryID = key }).FirstOrDefault();
            }
        }

        public int Create(Territories entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Territories (TerritoryID, TerritoryDescription,RegionID) VALUES(@TerritoryID, @TerritoryDescription, @RegionID)";
                return db.Execute(sqlQuery, entity);
            }
        }

        public int Update(Territories entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "Update Territories Set TerritoryDescription = @TerritoryDescription, RegionID = @RegionID Where TerritoryID = @TerritoryID";
                return db.Execute(sqlQuery, entity);
            }
        }

        public int Delete(int key)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Territories WHERE TerritoryID = @TerritoryID";
                return db.Execute(sqlQuery, new { TerritoryID = key });
            }
        }
    }
}
