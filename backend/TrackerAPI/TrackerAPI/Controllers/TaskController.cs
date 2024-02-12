using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerAPI.Models;

namespace WebApplication3.Controllers
{

    public class TaskController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select TaskId,UserId,Taskname,TaskType,Priority,CreatedBy,StartDate,EndDate,Status,Description from
                    dbo.Tasks
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
               ConnectionStrings["TASKDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Task tsk)
        {
            try
            {
                string query = @"
            INSERT INTO dbo.Tasks(TaskId,UserId, TaskName, TaskType, Priority, CreatedBy, StartDate, EndDate, Status, Description)
            VALUES ('" + tsk.TaskId + @"','" + tsk.UserId + @"', '" + tsk.Taskname + @"', '" + tsk.TaskType + @"', '" + tsk.Priority + @"', '" + tsk.CreatedBy + @"', '" + tsk.StartDate + @"', '" + tsk.EndDate + @"', '" + tsk.Status + @"', '" + tsk.Description + @"')
            ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TASKDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Inserted Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Insert!!";
            }
        }


        public string Put(Task tsk)
        {
            try
            {
                string query = @"
                    update dbo.Tasks set 
                    UserId='" + tsk.UserId + @"'
                    ,TaskName='" + tsk.Taskname + @"'
                    ,TaskType='" + tsk.TaskType + @"'
                    ,Priority='" + tsk.Priority + @"'
                    ,CreatedBy='" + tsk.CreatedBy + @"'
                    ,StartDate='" + tsk.StartDate + @"'
                    ,EndDate='" + tsk.EndDate + @"'
                    ,Status='" + tsk.Status + @"'
                    ,Description='" + tsk.Description + @"'
                    where TaskId=" + tsk.TaskId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["TASKDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Tasks
                    where TaskId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["TASKDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }

    }
}