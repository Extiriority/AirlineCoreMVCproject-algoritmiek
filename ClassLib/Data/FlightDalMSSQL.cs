using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data 
{
    public class FlightDalMSSQL : IFlightContainer
    {
        
        private SqlConnection conn = new SqlConnection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi463189_airline;Persist Security Info=True;User ID=dbi463189_airline;Password=m4VEw2tX;");
        
        public List<FlightDto> getAllFlights()
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

        public FlightDto GetFlightById(int id)
        {
            return null;
        }
    }
}
