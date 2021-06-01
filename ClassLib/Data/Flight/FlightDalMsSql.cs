﻿using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLib.Data 
{
    public class FlightDalMsSql : Database, IFlightPersist, IFlightFetch
    {
        public List<FlightDto> getAll()
        {
            List<FlightDto> flights = new List<FlightDto>();
            try
            {
                databaseConnection("SELECT * FROM Flight ORDER BY departureDate");
                using (reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    FlightDto flightDto = new FlightDto
                    {
                        flightId = (int)reader["Id"],
                        aircraftCode = Convert.ToString(reader["aircraftCode"]),
                        aircraftType = Convert.ToString(reader["aircraftType"]),
                        departureCountry = Convert.ToString(reader["departureCountry"]),
                        arrivalCountry = Convert.ToString(reader["arrivalCountry"]),
                        departureDate = (DateTime)reader["departureDate"],
                        arrivalDate = (DateTime)reader["arrivalDate"],
                        flightStatus = (bool)reader["flightStatus"],
                        price = (int)reader["price"]

                    };
                    flights.Add(flightDto);
                }                
            }
            finally
            {
                connClose();
            }
            return flights;
        }

        public FlightDto getById(int Id)
        {
            try
            {
                string query = "SELECT * FROM Flight " +
                               "WHERE Id = @flightId";
                FlightDto flight = new FlightDto();
                
                databaseConnection(query);
                cmd.Parameters.Add("@flightId", SqlDbType.Int).Value = Id;
                using (reader = cmd.ExecuteReader())
                using (SqlCommand command = new SqlCommand(query, conn))      
                    
                while (reader.Read())
                {                       
                    {
                        flight.flightId = (int)reader["Id"];
                        flight.aircraftCode = Convert.ToString(reader["aircraftCode"]);
                        flight.aircraftType = Convert.ToString(reader["aircraftType"]);
                        flight.departureCountry = Convert.ToString(reader["departureCountry"]);
                        flight.arrivalCountry = Convert.ToString(reader["arrivalCountry"]);
                        flight.departureDate = (DateTime)reader["departureDate"];
                        flight.arrivalDate = (DateTime)reader["arrivalDate"];
                        flight.flightStatus = (bool)reader["flightStatus"];
                        flight.price = (int)reader["price"];
                    }; 
                }
                return flight;
            }
            finally
            {
                connClose();
            }  
        }

        public void delete(int Id)
        {
            try
            {
                string query = "DELETE FROM Flight WHERE Id = @flightId";
                databaseConnection(query);
                SqlCommand cmd = new SqlCommand(query, this.conn);
                cmd.Parameters.AddWithValue("@flightId", Id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connClose();
            }
        }

        public void save(FlightDto data)
        {
            try
            {
                string query = "INSERT INTO Flight (AircraftCode, AircraftType, DepartureCountry, ArrivalCountry, DepartureDate, ArrivalDate, FlightStatus, Price) " +
                               "VALUES (@aircraftCode, @AircraftType, @DepartureCountry, @ArrivalCountry, @DepartureDate, @ArrivalDate, @FlightStatus, @price)";
                databaseConnection(query);

                cmd.Parameters.AddWithValue("@AircraftCode", data.aircraftCode);
                cmd.Parameters.AddWithValue("@AircraftType", data.aircraftType);
                cmd.Parameters.AddWithValue("@DepartureCountry", data.departureCountry);
                cmd.Parameters.AddWithValue("@ArrivalCountry", data.arrivalCountry);
                cmd.Parameters.AddWithValue("@DepartureDate", data.departureDate);
                cmd.Parameters.AddWithValue("@ArrivalDate", data.arrivalDate);
                cmd.Parameters.AddWithValue("@FlightStatus", data.flightStatus);
                cmd.Parameters.AddWithValue("@Price", data.price);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connClose();
            }           
        }

        public void update(FlightDto data)
        {
            try
            {
                string query = "UPDATE Flight " +
                    "SET AircraftCode = @aircraftCode, " +
                    "AircraftType = @AircraftType, " +
                    "DepartureCountry = @DepartureCountry, " +
                    "ArrivalCountry = @ArrivalCountry, " +
                    "DepartureDate = @DepartureDate, " +
                    "ArrivalDate = @ArrivalDate, " +
                    "FlightStatus = @FlightStatus, " +
                    "Price = @price " +
                    "WHERE Id = @flightId";
                databaseConnection(query);


                cmd.Parameters.AddWithValue("@flightId", data.flightId);
                cmd.Parameters.AddWithValue("@AircraftCode", data.aircraftCode);
                cmd.Parameters.AddWithValue("@AircraftType", data.aircraftType);
                cmd.Parameters.AddWithValue("@DepartureCountry", data.departureCountry);
                cmd.Parameters.AddWithValue("@ArrivalCountry", data.arrivalCountry);
                cmd.Parameters.AddWithValue("@DepartureDate", data.departureDate);
                cmd.Parameters.AddWithValue("@ArrivalDate", data.arrivalDate);
                cmd.Parameters.AddWithValue("@FlightStatus", data.flightStatus);
                cmd.Parameters.AddWithValue("@price", data.price);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                connClose();
            }         
        }

        public List<FlightDto> searchFlight(string searchString)
        {
             List<FlightDto> flights = new List<FlightDto>();
             try
             {
                string query = "SELECT * FROM Flight WHERE arrivalCountry LIKE '%" + searchString + "%'";
                databaseConnection(query);

                    using (reader = cmd.ExecuteReader())
                    using (SqlCommand command = new SqlCommand(query, conn))
                    while (reader.Read())
                    {
                         FlightDto flightDto = new FlightDto
                         {
                             flightId = (int)reader["Id"],
                             aircraftCode = Convert.ToString(reader["aircraftCode"]),
                             aircraftType = Convert.ToString(reader["aircraftType"]),
                             departureCountry = Convert.ToString(reader["departureCountry"]),
                             arrivalCountry = Convert.ToString(reader["arrivalCountry"]),
                             departureDate = (DateTime)reader["departureDate"],
                             arrivalDate = (DateTime)reader["arrivalDate"],
                             flightStatus = (bool)reader["flightStatus"],
                             price = (int)reader["price"]
             
                         };
                         flights.Add(flightDto);
                    }
             }
             finally
             {
                 connClose();
             }
             return flights;           
        }
    }
}
