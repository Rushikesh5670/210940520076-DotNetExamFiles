using DotNetExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> listpro = new List<Product>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ViewAllProducts";
            SqlDataReader dreader = cmd.ExecuteReader();

            while (dreader.Read())
            {
                Product pro = new Product();
                pro.ProductId = (int)dreader["ProductId"];
                pro.ProductName = dreader["ProductName"].ToString();
                pro.Rate = (decimal)dreader["Rate"];
                pro.Description = dreader["Description"].ToString();
                pro.CategoryName = dreader["CategoryName"].ToString();
                listpro.Add(pro);
            }
            conn.Close();
            return View(listpro);

        }

       

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product pro = new Product();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ViewProductUsingId";
            cmd.Parameters.AddWithValue("@ProductId", id);
            try
            {
                SqlDataReader dreader = cmd.ExecuteReader();
                dreader.Read();
                pro.ProductId = (int)dreader["ProductId"];
                pro.ProductName = dreader["ProductName"].ToString();
                pro.Rate = (decimal)dreader["Rate"];
                pro.Description = dreader["Description"].ToString();
                pro.CategoryName = dreader["CategoryName"].ToString();
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return View(pro);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product pro)
            
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertProducts";
                cmd.Parameters.AddWithValue("@ProductId",pro.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                cmd.Parameters.AddWithValue("@Rate", pro.Rate);
                cmd.Parameters.AddWithValue("@Description", pro.Description);
                cmd.Parameters.AddWithValue("@CategoryName", pro.CategoryName);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product pro = new Product();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId = @ProductId";
            cmd.Parameters.AddWithValue("@ProductId", id);
            try
            {
                SqlDataReader dreader = cmd.ExecuteReader();
                dreader.Read();
                pro.ProductId = (int)dreader["ProductId"];
                pro.ProductName = dreader["ProductName"].ToString();
                pro.Rate = (decimal)dreader["Rate"];
                pro.Description = dreader["Description"].ToString();
                pro.CategoryName = dreader["CategoryName"].ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return View(pro);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                if (pro.ProductId == id)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId";
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product pro = new Product();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId = @ProductId";
            cmd.Parameters.AddWithValue("@ProductId", id);
            try
            {
                SqlDataReader dreader = cmd.ExecuteReader();
                dreader.Read();
                pro.ProductId = (int)dreader["ProductId"];
                pro.ProductName = dreader["ProductName"].ToString();
                pro.Rate = (decimal)dreader["Rate"];
                pro.Description = dreader["Description"].ToString();
                pro.CategoryName = dreader["CategoryName"].ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return View(pro);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from Products where ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ProductId", id);
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
