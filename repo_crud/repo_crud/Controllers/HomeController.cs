﻿using Bussinesslayer.B_CLASS;
using Bussinesslayer.INTERFACE;
using DOT.VIEW_MODEL;
using ENTITIES.MODEL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using View = DOT.VIEW_MODEL.View;

namespace repo_crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IBusiness _IBusiness;
        private readonly IConfiguration _con;
        public HomeController(IBusiness Ibusiness, IConfiguration configuration)
        {
            _IBusiness = Ibusiness;
            _con = configuration;
        }

        [HttpGet("GET")]
        public async Task<IActionResult> GET()
        {
            var GET = await _IBusiness.GET();
            return Ok(GET);
        }
        [HttpPost("POST")]
        public async Task<IActionResult> POST(View details)
        {
            var POST = await _IBusiness.POST(details);
            return Ok(POST);
        }
        [HttpPut("PUT")]
        public async Task<IActionResult> PUT(View details)
        {
            var PUT = await _IBusiness.PUT(details);
            return Ok(PUT);
        }
        [HttpDelete("DELETE")]
        public async Task<IActionResult> DELETE(int id)
        {

            var DELETE = await _IBusiness.DELETE(id);
            return Ok(DELETE);
        }
        [HttpPost("SP_post")]

        public async Task<IActionResult> SP_post([FromBody] int R_ID, string NAME, int Age, string Address, int PH_number, string Gender, string E_ID)

        {

            SqlConnection sqlCon = null;
            String SqlconString = _con.GetConnectionString("MVC6CrudConnectionString");
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();

                SqlCommand sql_cmnd = new SqlCommand("SPM_Procedures", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@R_ID", SqlDbType.Int).Value = R_ID;
                sql_cmnd.Parameters.AddWithValue("@NAME", SqlDbType.VarChar).Value = NAME;
                sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = Age;
                sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = Address;
                sql_cmnd.Parameters.AddWithValue("@PH_number", SqlDbType.Int).Value = PH_number;
                sql_cmnd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = Gender;
                sql_cmnd.Parameters.AddWithValue("@E_ID", SqlDbType.VarChar).Value = E_ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return Ok();
        }

        [HttpGet("SP_get")]
        public async Task<IActionResult> SP_Get()

        {
            SqlConnection sqlCon = null;
            String SqlconString = _con.GetConnectionString("MVC6CrudConnectionString");
            var sql = new List<View>();
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("SPM_GetProcedure", sqlCon))

                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            View ss = new View
                            {
                                R_ID = reader.GetInt32("R_ID"),
                                NAME = reader.GetString("Name"),
                                Age = reader.GetInt32("Age"),
                                Address = reader.GetString("Address"),
                                PH_number = reader.GetInt32("PH_number"),
                                Gender = reader.GetString("Gender"),
                                E_ID = reader.GetString("E_ID")

                            };
                            sql.Add(ss);
                        }
                    }
                }
                return Ok(sql);
            }

        }
        [HttpDelete("Sp_Delect")]
        public async Task<IActionResult> Sp_Delect(int R_ID)
        {
            SqlConnection sqlCon = null;
            String SqlconString = _con.GetConnectionString("MVC6CrudConnectionString");

            using (sqlCon = new SqlConnection(SqlconString))
            {


                using (SqlCommand command = new SqlCommand("        ", sqlCon))

                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@R_ID", SqlDbType.Int);
                    command.Parameters["@R_ID"].Value = (R_ID);
                    sqlCon.Open();
                    command.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            return Ok();
        }
        [HttpPut("Sp_Put")]
        public async Task<IActionResult> Sp_Put(View Model)

        {

            SqlConnection sqlCon = null;
            String SqlconString = _con.GetConnectionString("MVC6CrudConnectionString");
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();

                SqlCommand sql_cmnd = new SqlCommand("SPM_Puteprocedure", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@R_ID", SqlDbType.Int).Value = Model.R_ID;
                sql_cmnd.Parameters.AddWithValue("@NAME", SqlDbType.VarChar).Value = Model.NAME;
                sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = Model.Age;
                sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = Model.Address;
                sql_cmnd.Parameters.AddWithValue("@PH_number", SqlDbType.Int).Value = Model.PH_number;
                sql_cmnd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = Model.Gender;
                sql_cmnd.Parameters.AddWithValue("@E_ID", SqlDbType.VarChar).Value = Model.E_ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return Ok();
        }
    }
        
}
