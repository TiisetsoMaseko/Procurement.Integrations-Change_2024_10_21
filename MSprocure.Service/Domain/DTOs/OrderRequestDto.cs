using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Domain.DTOs
{
    #pragma warning disable CS8618, IDE1006, CS8625
    public class OrderRequestDto
    {
        public OrderRequestWrapperDto Request { get; set; }
    }

    public class OrderRequestWrapperDto : Request
    {
        public OrderRequestBodyDto? Body { get; set; }
    }

    public class OrderRequestBodyDto
    {
        public OrderRequestHeaderDto? OrderRequestHeader { get; set; }
        public ItemOutDto[]? ItemOut { get; set; }
    }
    public class ItemOutDto
    {
        public int quantity { get; set; }
        public int lineNumber { get; set; }
        public string lineNumberString
        {
            get => lineNumber.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value)) lineNumber = int.Parse(value);
            }
        }
        public string requisitionID { get; set; }

        public string agreementItemNumber { get; set; }
        public string requestedDeliveryDate { get; set; }

        //public string requestedDeliveryDateString
        //{
        //    get => requestedDeliveryDate.ToString("o");
        //    set => requestedDeliveryDate = DateTime.Parse(value);
        //}
        public string isAdHoc { get; set; }
        public int parentLineNumber { get; set; }
        public string itemType { get; set; }
        public string requiresServiceEntry { get; set; }
        public string confirmationDueDate { get; set; }
        //public string confirmationDueDateString
        //{
        //    get => confirmationDueDate.ToString("o");
        //    set => confirmationDueDate = DateTime.Parse(value);
        //}
        public string compositeItemType { get; set; }
        public string itemClassification { get; set; }
        public string itemCategory { get; set; }
        public string subcontractingType { get; set; }
        public string requestedShipmentDate { get; set; }
        //public string requestedShipmentDateString
        //{
        //    get => requestedShipmentDate.ToString("o");
        //    set => requestedShipmentDate = DateTime.Parse(value);
        //}
        public string isReturn { get; set; }
        public string returnAuthorizationNumber { get; set; }
        public string isDeliveryCompleted { get; set; }
        public ItemIDDto ItemID { get; set; }
        public ItemDetailDto ItemDetail { get; set; }
    }
    public class ItemIDDto
    {
        public string SupplierPartID { get; set; }
        public string SupplierPartAuxiliaryID { get; set; }
    }
    public class ItemDetailDto
    {
        public UnitPriceDto UnitPrice { get; set; }

        public DescriptionDto Description { get; set; }

        public string UnitOfMeasure { get; set; }

        public ClassificationDto Classification { get; set; }

        public string ManufacturerName { get; set; }

        public int LeadTime { get; set; }

    }
    public class UnitPriceDto
    {
        public UnitPriceDto()
        {
            Money = new MoneyDto();
        }

        public UnitPriceDto(string currency, decimal value)
        {
            Money = new MoneyDto(currency, value);
        }
        public MoneyDto Money { get; set; }
    }
    public class ClassificationDto
    {
        public ClassificationDto() { }

        public ClassificationDto(string value, string domain)
        {
            Value = value;
            this.domain = domain;
        }
        public string domain { get; set; }
        public string Value { get; set; }
    }

    public class OrderRequestHeaderDto
    {
        public string? orderID { get; set; }

        public string orderDate { get; set; }

        //public string orderDateString
        //{
        //    get => orderDate.ToString("o");
        //    set
        //    {
        //        var tempDate = new DateTime();
        //        var tryResult = DateTime.TryParse(value, out tempDate);
        //        if (tryResult) orderDate = tempDate;
        //    }
        //}
        public string? orderType { get; set; }
        public string? releaseRequired { get; set; }
        public string? type { get; set; }
        public string? orderVersion { get; set; }
        public string? isInternalVersion { get; set; }
        public string? agreementID { get; set; }
        public string? agreementPayloadID { get; set; }
        public string? parentAgreementID { get; set; }
        public string? parentAgreementPayloadID { get; set; }
        public string? effectiveDate { get; set; }
        //public string effectiveDateString
        //{
        //    get => effectiveDate?.ToString("o") ?? "";
        //    set => effectiveDate = DateTime.Parse(value);
        //}
        public string? expirationDate { get; set; }
        //public string expirationDateString
        //{
        //    get => expirationDate?.ToString("o") ?? "";
        //    set => expirationDate = DateTime.Parse(value);
        //}
        public string? requisitionID { get; set; }
        public string? shipComplete { get; set; }
        public string? pickUpDate { get; set; }
        //public string pickUpDateString
        //{
        //    get => pickUpDate?.ToString("o") ?? "";
        //    set => pickUpDate = DateTime.Parse(value);
        //}
        public string? requestedDeliveryDate { get; set; }
        //public string requestedDeliveryDateString
        //{
        //    get => requestedDeliveryDate?.ToString("o") ?? "";
        //    set => requestedDeliveryDate = DateTime.Parse(value);
        //}
        public TotalDto? Total { get; set; }
        public ShipToDto? ShipTo { get; set; }
        public BillToDto? BillTo { get; set; }

        public LegalEntityDto? LegalEntity { get; set; }
        public OrganizationUnitDto? OrganizationUnit { get; set; }

        public ShippingDto? Shipping { get; set; }

        public TaxDto? Tax { get; set; }

        public PaymentDto? Payment { get; set; }

        public PaymentDto? PaymentTerm { get; set; }

        public ContactDto[]? Contact { get; set; }

        public CommentsDto? Comments { get; set; }

        public FollowupDto? Followup { get; set; }

        public ControlKeysDto? ControlKeys { get; set; }

        public DocumentReferenceDto? DocumentReference { get; set; }

        public SupplierOrderInfoDto? SupplierOrderInfo { get; set; }

        public TermsOfDeliveryDto? TermsOfDelivery { get; set; }

        public DeliveryPeriodDto? Period { get; set; }

        public IdReferenceDto? IdReference { get; set; }

        public OrderRequestHeaderIndustryDto? OrderRequestHeaderIndustry { get; set; }

        public ExtrinsicDto[]? Extrinsic { get; set; }
    }
    public class SupplierOrderInfoDto
    {
        public string orderID { get; set; }
    }
    public class DeliveryPeriodDto
    {
        public string Value { get; set; }
    }
    public class ExtrinsicDto
    {
        public string name { get; set; }

        public IdReference IdReference { get; set; }

        public string Value { get; set; }
    }
    public class OrderRequestHeaderIndustryDto
    {
        public string Value { get; set; }
    }

    public class IdReferenceDto
    {
        public IdReferenceDto() { }

        public IdReferenceDto(string domain, string identifier)
        {
            this.domain = domain;
            this.identifier = identifier;
        }

        public string domain { get; set; }

        public string identifier { get; set; }

        public Description? Description { get; set; }
    }

    public class TermsOfDeliveryDto
    {
        public string Value { get; set; }
    }

    public class FollowupDto
    {
        public string Value { get; set; }
    }
    public class ControlKeysDto
    {
        public string Value { get; set; }
    }
    public class DocumentReferenceDto
    {
        public string payloadID { get; set; }
    }

    public class CommentsDto
    {
        public AttachmentDto[] Attachment { get; set; }

        public string Value { get; set; }
    }

    public class AttachmentDto
    {
        public string visibility { get; set; }
        public URLDto URL { get; set; }
    }

    public class URLDto
    {
        public URLDto() { }

        public URLDto(string name, string value)
        {
            this.name = name;
            Value = value;
        }

        public string name { get; set; }

        public string Value { get; set; }
    }

    public class OrganizationUnitDto
    {
        public string? Value { get; set; }
    }
    public class TotalDto
    {
        public TotalDto()
        {
            Money = new MoneyDto();
        }
        public TotalDto(string currency, decimal value)
        {
            Money = new MoneyDto(currency, value);
        }
        public MoneyDto Money { get; set; }
    }
    public class MoneyDto
    {
        public MoneyDto()
        {
            currency = "ZAF";
            Value = 0.0m;
        }
        public MoneyDto(string currency, decimal value)
        {
            this.currency = currency;
            Value = value;
        }
        public decimal alternateAmount { get; set; }
        public string alternateCurrency { get; set; }
        public string currency { get; set; }
        public decimal Value { get; set; }
    }
    public class ShipToDto
    {
        public ShipToDto()
        {
            Address = new AddressDto();
        }

        public ShipToDto(string addressID, string name, string deliverTo, string street, string city, string state,
                      string postalCode, string country)
        {
            Address = new AddressDto(addressID, name, deliverTo, street, city, state, postalCode, country);
        }
        public AddressDto Address { get; set; }

        public CarrierIdentifierDto CarrierIdentifier { get; set; }
    }

    public class AddressDto
    {
        public AddressDto()
        {
            addressID = "";
            Name = new NameDto();
            PostalAddress = new PostalAddressDto();
        }

        public AddressDto(string addressID, string name, string deliverTo, string street, string city, string state,
                       string postalCode, string country)
        {
            this.addressID = addressID;
            Name = new NameDto(name);
            PostalAddress = new PostalAddressDto(deliverTo, street, city, state, postalCode, country);
        }
        public string isoCountryCode { get; set; }
        public string addressID { get; set; }
        public string addressIDDomain { get; set; }
        public NameDto Name { get; set; }
        public PostalAddressDto PostalAddress { get; set; }
        public EmailDto? Email { get; set; }
    }
    public class CarrierIdentifierDto
    {
        public string? domain { get; set; }
        public string? Value { get; set; }
    }
    public class NameDto
    {
        public NameDto()
        {
            lang = "en";
            Value = "";
        }
        public NameDto(string value)
        {
            lang = "en";
            Value = value;
        }
        public NameDto(string value, string lang)
        {
            this.lang = lang;
            Value = value;
        }
        public string lang { get; set; }
        public string Value { get; set; }
    }
    public class PostalAddressDto
    {
        public PostalAddressDto() { }

        public PostalAddressDto(string deliverTo, string street, string city, string state, string postalCode,
                             string country)
        {
            if (!string.IsNullOrEmpty(deliverTo)) DeliverTo = deliverTo.Split(',');
            if (!string.IsNullOrEmpty(street)) Street = street.Split(',');
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = new CountryDto(country);
        }
        public string? name { get; set; }
        public string[]? DeliverTo { get; set; }

        public string[] Street { get; set; }

        public string City { get; set; }

        public string? State { get; set; }

        public string PostalCode { get; set; }

        public CountryDto Country { get; set; }
    }

    public class CountryDto
    {
        public CountryDto()
        {
            isoCountryCode = "ZAF";
            Value = "ZAR";
        }

        public CountryDto(string countryCode)
        {
            isoCountryCode = countryCode;
            Value = countryCode;
        }

        public CountryDto(string countryCode, string value)
        {
            isoCountryCode = countryCode;
            Value = value;
        }
        public string isoCountryCode { get; set; }
        public string Value { get; set; }
    }

    public class EmailDto
    {
        public EmailDto() { }

        public EmailDto(string name, string value)
        {
            this.name = name;
            Value = value;
        }

        public string name { get; set; }

        public string Value { get; set; }
    }

    public class BillToDto
    {
        public BillToDto()
        {
            Address = new AddressDto();
        }

        public BillToDto(string addressID, string name, string deliverTo, string street, string city, string state,
                      string postalCode, string country)
        {
            Address = new AddressDto(addressID, name, deliverTo, street, city, state, postalCode, country);
        }
        public AddressDto Address { get; set; }
    }
    public class LegalEntityDto
    {

        public string? Value { get; set; }
    }

    public class ShippingDto
    {
        public ShippingDto()
        {
            Money = new MoneyDto();
            Description = new DescriptionDto();
        }

        public ShippingDto(string currency, decimal value, string description, string lang = null)
        {
            Money = new MoneyDto(currency, value);
            Description = new DescriptionDto(description, lang);
        }
        public MoneyDto Money { get; set; }
        public DescriptionDto Description { get; set; }
    }
    public class DescriptionDto
    {
        public DescriptionDto() { }

        public DescriptionDto(string description, string lang = null)
        {
            Value = description;
            this.lang = lang;
        }

        public string? lang { get; set; }

        public string? Value { get; set; }

    }
    public class TaxDto
    {
        public TaxDto()
        {
            Money = new MoneyDto();
            Description = new DescriptionDto();
        }

        public TaxDto(string currency, decimal value, string description, string lang = null)
        {
            Money = new MoneyDto(currency, value);
            Description = new DescriptionDto(description, lang);
        }

        public MoneyDto Money { get; set; }
        public DescriptionDto Description { get; set; }
        public TaxDetailDto TaxDetail { get; set; }
    }
    public class TaxDetailDto
    {
        public string? purpose { get; set; }

        public string? category { get; set; }

        public string? percentageRate { get; set; }

        public TaxableAmountDto? TaxableAmount { get; set; }

        public TaxAmountDto? TaxAmount { get; set; }
    }

    public class TaxableAmountDto
    {
        public MoneyDto? Money { get; set; }
    }
    public class TaxAmountDto
    {
        public MoneyDto? Money { get; set; }
    }
    public class PaymentDto
    {
        public string? Value { get; set; }
    }
    public class ContactDto
    {
        public string? role { get; set; }

        public string? addressID { get; set; }

        public NameDto? Name { get; set; }

        public PostalAddressDto? PostalAddress { get; set; }

        public PhoneDto? Phone { get; set; }

    }
    public class PhoneDto
    {
        public TelephoneNumberDto? TelephoneNumber { get; set; }
    }

    public class TelephoneNumberDto
    {
        public CountryCodeDto? CountryCode { get; set; }

        public string? AreaOrCityCode { get; set; }

        public string? Number { get; set; }
    }
    public class CountryCodeDto
    {
        public CountryCodeDto() { }

        public CountryCodeDto(string isoCountryCode)
        {
            this.isoCountryCode = isoCountryCode;
        }

        public string? isoCountryCode { get; set; }
    }
    #pragma warning restore CS8618, IDE1006, CS8625
}
