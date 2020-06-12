using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using JHC.DataManager;

namespace TestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddDapper("mysql", m =>
            //{
            //    m.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //    m.DbType = DbStoreType.MySql;
            //});
            ////连接Oracle
            //services.AddDapper("OracleConnection", m =>
            //{
            //    m.ConnectionString = Configuration.GetConnectionString("OracleConnectionString");
            //    m.DbType = DbStoreType.Oracle;
            //});
            var connets = Configuration.GetSection("DbConnedtions").GetChildren();
            var dbDic = new Dictionary<string, DapperClient>();
            foreach (var item in connets) {
                string name = item.GetSection("name").Value;
                string type = item.GetSection("dbtype").Value;
                string constr= item.GetSection("connectstring").Value;
                ConnectionConfig conf = new ConnectionConfig();
                conf.ConnectionString = constr;
                switch (type.ToLower()) {
                    case "mysql":
                        conf.DbType = DbStoreType.MySql;
                        break;
                    case "oracle":
                        conf.DbType = DbStoreType.Oracle;
                        break;
                    case "sqlite":
                        conf.DbType = DbStoreType.Sqlite;
                        break;
                    case "sqlserver":
                        conf.DbType = DbStoreType.SqlServer;
                        break;
                }
                DapperClient client = new DapperClient(conf);
                dbDic.Add(name, client);
            }
            services.AddClient( dbDic);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
