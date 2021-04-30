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
        public string aircraftType { get; set; }
        public string departureCountry { get; set; }
        public string arrivalCountry { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public bool flightStatus { get; set; }

        public Flight(FlightDto flightDto)
        {
            this.flightId = flightDto.flightId;
            this.aircraftType = flightDto.aircraftType;
            this.departureCountry = flightDto.departureCountry;
            this.arrivalCountry = flightDto.arrivalCountry;
            this.departureDate = flightDto.departureDate;
            this.arrivalDate = flightDto.arrivalDate;
            this.flightStatus = flightDto.flightStatus;
        }

        public Flight(IFlightPersist flight)
        {
            this.flight = flight;
        }

        public bool Create()
        {
            FlightDto data = new FlightDto();
            data.aircraftType = this.aircraftType;
            data.departureCountry = this.departureCountry;
            data.arrivalCountry = this.arrivalCountry;
            data.departureDate = this.departureDate;
            data.arrivalDate = this.arrivalDate;
            data.flightStatus = this.flightStatus;

            flight.save(data);
            return true;
        }

        public FlightDto Save(FlightDto flight)
        {

            throw new System.NotImplementedException();
        }
        public bool Delete(int id)
        {
            flight.delete(id);
            return true;

        }
    }


    /*/*public int aircraftId { get; set; }
        public string aircraftType { get; set; }
        public string departureCountry { get; set; }
        public string arrivalCountry { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public bool flightStatus { get; set; }

        public Flight(FlightDto flightDto)
        {
            this.aircraftType = flightDto.aircraftType;
            this.departureCountry = flightDto.departureCountry;
            this.arrivalCountry = flightDto.arrivalCountry;
            this.departureDate = flightDto.departureDate;
            this.arrivalDate = flightDto.arrivalDate;
            this.flightStatus = flightDto.flightStatus;
        }*/
}

