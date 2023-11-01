using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Data;
using StoredProcedure.Models;

namespace StoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfEmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EfEmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public List<Employee> GetEmployes()
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value = 0
                },
                new SqlParameter()
                {
                    ParameterName = "@Name",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                new SqlParameter()
                {
                    ParameterName = "@Designation",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                 new SqlParameter()
                {
                    ParameterName = "@Type",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = "GetAll"
                }
            };
            var GetAllEmployes = _db.Employes.FromSqlRaw("dbo.SP_EMPLOYEE @Id, @Name, @Email, @Designation, @Type", param).ToList();
            return GetAllEmployes;
        }
        [HttpGet("{id}")]
        public List<Employee> GetEmployee(int id)
        {
            var param = new SqlParameter[]
{
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value = id
                },
                new SqlParameter()
                {
                    ParameterName = "@Name",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                new SqlParameter()
                {
                    ParameterName = "@Designation",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = ""
                },
                 new SqlParameter()
                {
                    ParameterName = "@Type",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = "GetById"
                }
};
            var GetEmployee = _db.Employes.FromSqlRaw("dbo.SP_EMPLOYEE @Id, @Name, @Email, @Designation, @Type", param).ToList();
            return GetEmployee;
        }
        [HttpPost]
        public int AddEmployee(Employee emp)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value = 0
                },
                new SqlParameter()
                {
                    ParameterName = "@Name",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Name
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@Designation",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Designation
                },
                 new SqlParameter()
                {
                    ParameterName = "@Type",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = "Insert"
                }


            };
            var addEmployee = _db.Database.ExecuteSqlRaw($"Exec SP_EMPLOYEE @Id, @Name, @Email,@Designation, @Type", param);
            return addEmployee;
        }
        [HttpPut("{id}")]
        public int UpdateEmployee(Employee emp)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value = emp.Id
                },
                new SqlParameter()
                {
                    ParameterName = "@Name",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Name
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@Designation",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = emp.Designation
                },
                 new SqlParameter()
                {
                    ParameterName = "@Type",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = "Update"
                }
            };
            var updateEmployee = _db.Database.ExecuteSqlRaw($"Exec SP_EMPLOYEE @Id, @Name, @Email,@Designation, @Type", param);
            return updateEmployee;
        }
        [HttpDelete("{id}")]
        public int DeleteEmployee(Employee emp)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value = emp.Id
                },
                
                 new SqlParameter()
                {
                    ParameterName = "@Type",
                    SqlDbType=System.Data.SqlDbType.NVarChar,
                    Value = "Delete"
                }


            };
            var DeleteEmployee = _db.Database.ExecuteSqlRaw($"Exec SP_EMPLOYEE @Id, @Type", param);
            return DeleteEmployee;
        }

    }
}
