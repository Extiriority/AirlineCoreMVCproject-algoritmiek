using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data 
{
    public class FlightDalMsSql : IFlightPersist, IFlightFetch
    {
        
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;");

        public List<FlightDto> getAll()
        {
            List<FlightDto> flights = new List<FlightDto>();
            try
            {
                this.conn.Open();

                string query = "SELECT * FROM Flight";
                SqlCommand cmd = new SqlCommand(query, this.conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FlightDto flightDto = new FlightDto
                    {
                        flightId = (int)reader["Id"],
                        aircraftType = Convert.ToString(reader["aircraftType"]),
                        departureCountry = Convert.ToString(reader["departureCountry"]),
                        arrivalCountry = Convert.ToString(reader["arrivalCountry"]),
                        departureDate = (DateTime)reader["departureDate"],
                        arrivalDate = (DateTime)reader["arrivalDate"],
                        flightStatus = (bool)reader["flightStatus"]
                    };
                    flights.Add(flightDto);
                }
            }
            finally
            {
                this.conn.Close();
            }
            return flights;
        }

        public FlightDto getById(int Id)
        {
            try
            {
                this.conn.Open();

                string query = "SELECT * FROM Flight " +
                               "WHERE Id = @flightId";
                SqlCommand cmd = new SqlCommand(query, this.conn);

                cmd.Parameters.Add("@flightId", System.Data.SqlDbType.Int).Value = Id;

                using SqlDataReader reader = cmd.ExecuteReader();

                FlightDto flight = new FlightDto();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        {
                            flight.flightId = (int)reader["Id"];
                            flight.aircraftType = Convert.ToString(reader["aircraftType"]);
                            flight.departureCountry = Convert.ToString(reader["departureCountry"]);
                            flight.arrivalCountry = Convert.ToString(reader["arrivalCountry"]);
                            flight.departureDate = (DateTime)reader["departureDate"];
                            flight.arrivalDate = (DateTime)reader["arrivalDate"];
                            flight.flightStatus = (bool)reader["flightStatus"];
                        }; 
                    }
                }
                return flight;
            }
            finally
            {
                this.conn.Close();
            }
            
        }

        public void delete(int Id)
        {
            try
            {
                this.conn.Open();

                string query = "DELETE FROM Flight WHERE Id = @flightId";
                SqlCommand cmd = new SqlCommand(query, this.conn);

                cmd.Parameters.AddWithValue("@flightId", Id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void save(FlightDto data)
        {
            try
            {
                this.conn.Open();

                string query = "INSERT INTO Flight (AircraftType, DepartureCountry, ArrivalCountry, DepartureDate, ArrivalDate, FlightStatus) " +
                               "VALUES (@AircraftType, @DepartureCountry, @ArrivalCountry, @DepartureDate, @ArrivalDate, @FlightStatus)";
                SqlCommand cmd = new SqlCommand(query, this.conn);

                cmd.Parameters.AddWithValue("@AircraftType", data.aircraftType);
                cmd.Parameters.AddWithValue("@DepartureCountry", data.departureCountry);
                cmd.Parameters.AddWithValue("@ArrivalCountry", data.arrivalCountry);
                cmd.Parameters.AddWithValue("@DepartureDate", data.departureDate);
                cmd.Parameters.AddWithValue("@ArrivalDate", data.arrivalDate);
                cmd.Parameters.AddWithValue("@FlightStatus", data.flightStatus);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conn.Close();
            }           
        }
    }
}
