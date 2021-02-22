using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarsWithCheckbox.Models
{
    public class CarsWithCheckboxDb
    {
        private string _conStr;

        public CarsWithCheckboxDb(string conStr)
        {
            _conStr = conStr;
        }

        public List<Car> GetCars()
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Cars";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Car> results = new List<Car>();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.Make = (string)reader["Make"];
                    car.Model = (string)reader["Model"];
                    car.Year = (int)reader["Year"];
                    car.Price = (decimal)reader["Price"];
                    car.HasLeatherSeats = (bool)reader["HasLeatherSeats"];
                    car.CarType = (CarType)reader["CarType"];

                    results.Add(car);

                }


                return results;
            }
        }

        public void AddCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Cars (Make, Model, Year, Price, CarType, HasLeatherSeats) " +
                                      "VALUES (@make, @model, @year, @price, @carType, @hasLeather)";
                command.Parameters.AddWithValue("@make", car.Make);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", car.Year);
                command.Parameters.AddWithValue("@price", car.Price);
                command.Parameters.AddWithValue("@carType", car.CarType);
                command.Parameters.AddWithValue("@hasLeather", car.HasLeatherSeats);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}