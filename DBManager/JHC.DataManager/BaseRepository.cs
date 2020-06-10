using Dapper;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace DBManager.JHC.DataManager
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public BaseDBContext _baseDB;
        public BaseRepository(BaseDBContext baseDB)
        {
            _baseDB = baseDB;
        }

        public async Task Delete(int Id, string deleteSql)
        {
            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(deleteSql, new { Id = Id });
            }
        }

        public async Task<T> GetOne(int Id, string selectOneSql)
        {

            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.QueryFirstOrDefaultAsync<T>(selectOneSql, new { Id = Id });
                return result;
            }
        }
        public async Task<List<T>> GetList(int Id, string selectSql)
        {

            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                return await Task.Run(() => dbConnection.Query<T>(selectSql, new { Id = Id }).ToList());
            }
        }
        public async Task Insert(T entity, string insertSql)
        {
            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                await dbConnection.QueryFirstOrDefaultAsync<T>(insertSql, entity);
            }
        }

        public async Task<List<T>> SelectAsync(string selectSql)
        {
            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                return await Task.Run(() => dbConnection.Query<T>(selectSql).ToList());
            }
        }

        public async Task Update(T entity, string updateSql)
        {
            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(updateSql, entity);
            }
        }

        public async Task<List<T>> GetByDynamicParams(string sqlText, DynamicParameters dynamicParams)
        {
            using (IDbConnection dbConnection = _baseDB.Connection)
            {
                dbConnection.Open();
                return await Task.Run(() => dbConnection.Query<T>(sqlText, dynamicParams).ToList());
            }
        }
    }
}
