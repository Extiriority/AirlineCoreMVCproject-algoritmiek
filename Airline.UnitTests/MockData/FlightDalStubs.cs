using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.UnitTests
{
    using ClassLib.Data;
    using ClassLib.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;

    namespace Airline.UnitTests
    {
        public class FlightDALStubs : IFetchDal<FlightDto>, IPersistDal<FlightDto>
        {
            private List<FlightDto> flightDtoList = new List<FlightDto>()
            {
            new FlightDto(){ flightId=1, aircraftCode="FD453", aircraftType="A320", departureCountry="Netherlands", arrivalCountry="Japan", departureDate=new DateTime(2008, 5, 3, 6, 30, 00), arrivalDate=new DateTime(2008, 5, 1, 19, 45, 00), flightStatus=true, price=450},
            new FlightDto(){ flightId=2, aircraftCode="FD356", aircraftType="747", departureCountry="Netherlands", arrivalCountry="Vietnam", departureDate=new DateTime(2008, 5, 3, 6, 30, 00), arrivalDate=new DateTime(2008, 5, 3, 16, 40, 00), flightStatus=true, price=380},
            new FlightDto(){ flightId=3, aircraftCode="FD596", aircraftType="A321", departureCountry="Netherlands", arrivalCountry="Italy", departureDate=new DateTime(2008, 7, 18, 7, 30, 00), arrivalDate=new DateTime(2008, 7, 18, 9, 05, 00), flightStatus=false, price= 72}
            };

            public void delete(int id) => flightDtoList.RemoveAt(id);           
            public IEnumerable<FlightDto> getAll() => flightDtoList;

            public FlightDto getById(int id)
            {
                FlightDto flight = flightDtoList.Single(x => x.flightId == id);
                return flight;
            }

            public void save(FlightDto flight)
            {
                if (flight.aircraftCode == null || flight.aircraftType == null || flight.departureCountry == null || flight.arrivalCountry == null || flight.departureDate < DateTime.Now || flight.arrivalDate < DateTime.Now)
                {
                    throw new FlightAddException(string.Format("Unable to find a customer by matching password"));
                }
                flightDtoList.Add(flight);
            }
            public void update(FlightDto flight)
            {
                int index = flightDtoList.FindLastIndex(c => c.flightId == flight.flightId);
                if (index != -1)
                {
                    flightDtoList[index] = new FlightDto() 
                    {
                        flightId = flight.flightId,
                        aircraftCode = flight.aircraftCode,
                        aircraftType = flight.aircraftType,
                        departureCountry = flight.departureCountry,
                        arrivalCountry = flight.arrivalCountry,
                        departureDate = flight.departureDate,
                        arrivalDate = flight.arrivalDate,
                        flightStatus = flight.flightStatus,
                        price = flight.price
                    };
                }               
            }


            public int saveGetId(FlightDto t)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<FlightDto> search(string searchString)
            {
                throw new NotImplementedException();
            }


            public FlightDto verifyLogin(string email, string password)
            {
                throw new NotImplementedException();
            }
        }
    }

}
