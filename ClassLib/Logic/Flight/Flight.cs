using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib.Logic
{
    public class Flight 
    {
        public IFlightPersist flight;

        public int flightId { get; set; }
        public string aircraftCode { get; set; }
        public string aircraftType { get; set; }
        public string departureCountry { get; set; }
        public string arrivalCountry { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public bool flightStatus { get; set; }
        public int price { get; set; }

        public Flight(FlightDto data)
        {
            this.flightId           = data.flightId;
            this.aircraftCode       = data.aircraftCode;
            this.aircraftType       = data.aircraftType;
            this.departureCountry   = data.departureCountry;
            this.arrivalCountry     = data.arrivalCountry;
            this.departureDate      = data.departureDate;
            this.arrivalDate        = data.arrivalDate;
            this.flightStatus       = data.flightStatus;
            this.price              = data.price;
        }

        public Flight(IFlightPersist flight)
        {
            this.flight = flight;
        }

        public void Save()
        {
            FlightDto data = new FlightDto
            {
                flightId = this.flightId,
                aircraftCode = this.aircraftCode,
                aircraftType = this.aircraftType,
                departureCountry = this.departureCountry,
                arrivalCountry = this.arrivalCountry,
                departureDate = this.departureDate,
                arrivalDate = this.arrivalDate,
                flightStatus = this.flightStatus,
                price = this.price
            };

            flight.save(data);         
        }

        public void Update()
        {
            FlightDto data = new FlightDto
            {
                flightId = this.flightId,
                aircraftCode = this.aircraftCode,
                aircraftType = this.aircraftType,
                departureCountry = this.departureCountry,
                arrivalCountry = this.arrivalCountry,
                departureDate = this.departureDate,
                arrivalDate = this.arrivalDate,
                flightStatus = this.flightStatus,
                price = this.price
            };

            flight.update(data);
        }
        public void Delete(int id)
        {
            flight.delete(id);
        }
    }
}

