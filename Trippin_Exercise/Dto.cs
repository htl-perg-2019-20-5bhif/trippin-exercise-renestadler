using System.Collections.Generic;
using System.Linq;

namespace Trippin_Exercise
{
    public class PersonInputDto
    {

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string CityName { get; set; }

        public string Country { get; set; }
    }

    public class PersonOutputDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<AddressInfo> AddressInfo { get; set; }

        public PersonOutputDto(PersonInputDto personInputDto)
        {
            this.UserName = personInputDto.UserName;
            this.FirstName = personInputDto.FirstName;
            this.LastName = personInputDto.LastName;
            Emails = Enumerable.Empty<string>().Append(personInputDto.Email);
            AddressInfo addressInfo = new AddressInfo();
            addressInfo.Address = personInputDto.Address;
            addressInfo.City = new City();
            addressInfo.City.Name = personInputDto.CityName;
            addressInfo.City.CountryRegion = personInputDto.Country;
            AddressInfo = Enumerable.Empty<AddressInfo>().Append(addressInfo);
        }
    }

    public class AddressInfo
    {
        public string Address { get; set; }
        public City City { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string CountryRegion { get; set; }
        public string Region { get; set; }
    }
}
