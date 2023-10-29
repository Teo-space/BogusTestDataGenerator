using Bogus;
using System.Json;
using System.Text;
using System.Text.Json;
Console.OutputEncoding = Encoding.UTF8;

print("Hello, World!");


var bogus = new Faker<CustomerRecord>("ru");
bogus.CustomInstantiator(faker => new CustomerRecord(
    faker.Person.FullName,
    faker.Address.StreetAddress(),
    faker.Address.City(),
    faker.Address.State(),
    faker.Address.ZipCode(),
    faker.Address.Country(),
    faker.Phone.PhoneNumber(),
    faker.Person.Email,
    faker.Finance.CreditCardNumber(),
    faker.Date.Future().Month + "/" + faker.Date.Future(5).Year,
    faker.Finance.CreditCardCvv(),
    faker.Address.StreetAddress()
));

var customer = bogus.Generate();
//bogus.UseSeed(123);

print(customer);


var customerFaker = new Faker<CustomerClass>()
  .RuleFor(c => c.Name, faker => faker.Person.FullName)
  .RuleFor(c => c.Address, faker => faker.Address.StreetAddress())
  .RuleFor(c => c.City, faker => faker.Address.City())
  .RuleFor(c => c.State, faker => faker.Address.State())
  .RuleFor(c => c.ZipCode, faker => faker.Address.ZipCode())
  .RuleFor(c => c.Country, faker => faker.Address.Country())
  .RuleFor(c => c.Phone, faker => faker.Phone.PhoneNumber())
  .RuleFor(c => c.Email, faker => faker.Person.Email)
  .RuleFor(c => c.CreditCardNumber, faker => faker.Finance.CreditCardNumber())
  .RuleFor(c => c.CreditCardExpiration, faker => faker.Date.Future().Month + "/" + faker.Date.Future(5).Year)
  .RuleFor(c => c.CreditCardCVV, faker => faker.Finance.CreditCardCvv())
  .RuleFor(c => c.BillingAddress, faker => faker.Address.StreetAddress())
;

var customer2 = customerFaker.Generate();
string jsonString = JsonSerializer.Serialize(customer2);
print(jsonString);



public record CustomerRecord(
    string Name,
    string Address,
    string City,
    string State,
    string ZipCode,
    string Country,
    string Phone,
    string Email,
    string CreditCardNumber,
    string CreditCardExpiration,
    string CreditCardCVV,
    string BillingAddress
);

public class CustomerClass
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CreditCardNumber { get; set; }
    public string CreditCardExpiration { get; set; }
    public string CreditCardCVV { get; set; }
    public string BillingAddress { get; set; }
}
