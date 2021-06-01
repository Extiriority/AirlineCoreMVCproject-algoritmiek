using ClassLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLib.Data
{
    public class FlightDALStub : IFlightFetch, IFlightPersist
    {
        private List<FlightDto> flightDtoList = new List<FlightDto>() 
        { 
            new FlightDto(){ flightId=1, aircraftCode="FD453", aircraftType="A320", departureCountry="Netherlands", arrivalCountry="Japan", departureDate=new DateTime(2008, 5, 3, 6, 30, 00), arrivalDate=new DateTime(2008, 5, 1, 19, 45, 00), flightStatus=true},
            new FlightDto(){ flightId=2, aircraftCode="FD356", aircraftType="747", departureCountry="Netherlands", arrivalCountry="Vietnam", departureDate=new DateTime(2008, 5, 3, 6, 30, 00), arrivalDate=new DateTime(2008, 5, 3, 16, 40, 00), flightStatus=true },
            new FlightDto(){ flightId=3, aircraftCode="FD596", aircraftType="A321", departureCountry="Netherlands", arrivalCountry="Italy", departureDate=new DateTime(2008, 7, 18, 7, 30, 00), arrivalDate=new DateTime(2008, 7, 18, 9, 05, 00), flightStatus=false}
        };
        
        public void delete(int id)
        {
            flightDtoList.RemoveAt(id);         
        }

        public List<FlightDto> getAll()
        {
            return flightDtoList;
        }

        public FlightDto getById(int Id)
        {
            FlightDto flight = flightDtoList.Where(x => x.flightId == Id).FirstOrDefault();
            return flight;
        }

        public void save(FlightDto flight)
        {
            flightDtoList.Add(flight);
        }

        public List<FlightDto> searchFlight(string searchString)
        {
            throw new NotImplementedException();
        }

        public void update(FlightDto flight)
        {
            flightDtoList.Add(flight);
        }
    }
}
