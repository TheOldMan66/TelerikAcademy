using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    static class CustomersManipulation
    {
        public static void InsertCustomer(Customer newCustomer)
        {
            using (var dbset = new NorthwindEntitiesData())
            {
                dbset.Customers.Add(newCustomer);
                dbset.SaveChanges();
            }
        }

        public static void ModifyCustomerName(string customerID, string newCompanyName)
        {
            using (var dbset = new NorthwindEntitiesData())
            {
                var customer = dbset.Customers.Find(customerID);
                customer.CompanyName = newCompanyName;
                dbset.SaveChanges();
            }
        }
        public static void DeleteCustomer(string customerID)
        {
            using (var dbset = new NorthwindEntitiesData())
            {
                var customer = dbset.Customers.Find(customerID);
                dbset.Customers.Remove(customer);
                dbset.SaveChanges();
            }
        }

        public static void SalesForPeriodAndRegion(DateTime startDate, DateTime endDate, string region)
        {
            using (var dbset = new NorthwindEntitiesData())
            {
                var orders = from order in dbset.Orders
                             where (order.ShipRegion == region && order.OrderDate.Value >= startDate && order.OrderDate.Value <= endDate)
                             select order;
                Console.WriteLine("Salese for region {0} in period {1} - {2}:", region, startDate.ToShortDateString(), endDate.ToShortDateString());
                foreach (var order in orders)
                {
                    foreach (var item in order.Order_Details)
                    {
                        Console.WriteLine("  - Quantity: {0,-10} Date: {1}", item.Quantity, order.OrderDate.Value.ToShortDateString());
                    }
                }
                //var sales = from order in dbset.Orders
                //            join orderDetails in dbset.Order_Details
                //            on order.OrderID equals orderDetails.OrderID
                //            where (order.ShipRegion == region && order.OrderDate.Value >= startDate && order.OrderDate.Value <= endDate)
                //            select new
                //            {
                //                Quantity = orderDetails.Quantity,
                //                Region = order.ShipRegion,
                //                Country = order.ShipCountry,
                //                Date = order.ShippedDate
                //            };
                //Console.WriteLine("Shipment by region and date");
                //foreach (var sale in sales)
                //{
                //    Console.WriteLine("Region: {0}, {1}, Quantity: {2}, Date: {3}", sale.Region, sale.Country, sale.Quantity, sale.Date.Value.ToShortDateString());
                //}
            }
        }

        public static void CopyDatabase()
        {
            var dbString = ((IObjectContextAdapter)new NorthwindEntitiesData()).ObjectContext.CreateDatabaseScript();
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=master;Integrated Security=true"))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("USE master", conn);
                command.ExecuteNonQuery();
                command = new SqlCommand("CREATE DATABASE NorthwindTwin", conn);
                command.ExecuteNonQuery();
                command = new SqlCommand("USE NorthwindTwin", conn);
                command.ExecuteNonQuery();
                command = new SqlCommand(dbString.ToString(), conn);
                command.ExecuteNonQuery();
            }
        }
    }

    public partial class Employee
    {
        public EntitySet<Territory> Teritories
        {
            get
            {
                EntitySet<Territory> teritory = new EntitySet<Territory>();
                teritory.AddRange(this.Territories);
                return teritory;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            goto cursor; // REMOVE THIS (IF I FORGOT) TO SEE ALL TESTS!!!

            cursor:

            Customer customer = new Customer();
            customer.CustomerID = "TSCP1";
            customer.CompanyName = "TestCompany1";

            /* TASK 2: Create a DAO class with static methods which provide functionality for inserting, 
             * modifying and deleting customers. Write a testing class. */

            CustomersManipulation.InsertCustomer(customer);
            customer.CompanyName = "ChangedNameCompany";
            CustomersManipulation.ModifyCustomerName("TSCP1", "NewCompanyName");
            CustomersManipulation.DeleteCustomer("TSCP1");

            /* TASK 3: Write a method that finds all customers who have orders made in 1997 and shipped to Canada. */

            using (var dbset = new NorthwindEntitiesData())
            {
                var customersFromCanada =
                    from order in dbset.Orders
                    where (int)order.OrderDate.Value.Year == 1997 && order.ShipCountry == "Canada"
                    group order by order.Customer into customers
                    select customers.Key.CompanyName;


                foreach (var cust in customersFromCanada)
                {
                    Console.WriteLine(cust);
                }

                //var ordersToCanada =
                //    from order in dbset.Orders
                //    where (int)order.OrderDate.Value.Year == 1997 && order.ShipCountry == "Canada"
                //    group order by order.CustomerID into newGroup
                //    select new
                //        {
                //            Name = (from cust in dbset.Customers
                //                    where cust.CustomerID == newGroup.Key
                //                    select cust.CompanyName)
                //        };

                //foreach (var order in ordersToCanada)
                //{
                //    Console.WriteLine(order.Name.ToArray()[0]);
                //}
            }

            /* TASK 4: Implement previous by using native SQL query and executing it through the DbContext. */

            string query = "SELECT c.CompanyName from Customers c JOIN Orders o ON o.CustomerID = c.CustomerID " +
                            "WHERE o.ShipCountry = 'Canada' AND YEAR(o.ShippedDate) = 1997 GROUP BY c.CompanyName";
            using (var dbset = new NorthwindEntitiesData())
            {
                var queryResult = dbset.Database.SqlQuery<string>(query);
                foreach (var item in queryResult)
                {
                    Console.WriteLine(item);
                }
            }

            /* TASK 5: Write a method that finds all the sales by specified region and period (start / end dates). */
            CustomersManipulation.SalesForPeriodAndRegion(new DateTime(1997, 1, 1), new DateTime(1997, 12, 31), "Essex");

            /* TASK 6: Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.  */
            CustomersManipulation.CopyDatabase();

            /* TASK 7: Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()?  */

            // uncomment this to see exception
            
            //using (var otherDataBase = new NorthwindEntitiesData())
            //{
            //    var newCustomer = new Customer();
            //    newCustomer.CustomerID = "NewID";
            //    newCustomer.CompanyName = "NewCompany";
            //    using (var dataBase = new NorthwindEntitiesData())
            //    {
            //        otherDataBase.Customers.Add(newCustomer);
            //        otherDataBase.SaveChanges();
            //        dataBase.Customers.Add(newCustomer);
            //        dataBase.Customers.Remove(newCustomer);
            //        dataBase.SaveChanges();
            //    }
            //}

            /* TASK 8: By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>. */

            // i make this with extension of partial class employee

            var employee = new NorthwindEntitiesData().Employees.First();
            var employeeTeritories = employee.Teritories;
            Console.WriteLine("Employee:", employee.FirstName + " " + employee.LastName);
            Console.Write("Teritories: ");
            foreach (var terit in employeeTeritories)
            {
                Console.Write(terit.TerritoryDescription.Trim() + ", ");
            }
        }
    }
}


// sorry, no time for more homeworks... deadlines are coming.