using MSprocure.Service.CXML.Helpers;
using MSprocure.Service.Models;
using MSprocure.Service.Models.Content;
using MSprocure.Service.Models.Content.Requests;
using MSprocure.Service.Models.Head;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentTerm = MSprocure.Service.Models.Content.Requests.PaymentTerm;

namespace MSprocure.Service.Helpers
{

    public class InvoiceHelper
    {
        public static InvoiceDetailRequest CreateInvoiceRequest(InvoiceDetailRequest InvoiceObject)
        {
			#pragma warning disable CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations
            var xmlHeader = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>";
            var cXmlVersion = "1.2.059";
            var cXmlDTD = $"http://xml.cXML.org/schemas/cXML/{cXmlVersion}/InvoiceDetail.dtd";
            var myTimestamp = DateTime.Now;
			var invoiceDate = DateTime.Now;
			var invoiceNumber = "1111111111";

			var request = new InvoiceDetailRequest()
            {
				version = cXmlVersion,
				timestamp = myTimestamp,
				payloadID = CxmlHelper.GeneratePayloadID(myTimestamp, "LocalHostName"),
				Header = new Header()
				{
					From = new From()
					{
						Credential = new[] { new Credential("FromDomain", "From") }
					},
					To = new To()
					{
						Credential = new[] { new Credential("ToDomain", "To") }
					},
					Sender = new Sender()
					{
						Credential = new[] { new Credential("SenderDomain", "Sender", "SharedSecret") },
						UserAgent = "My cXML User Agent 1.0"
					}
				},
				Request = new InvoiceDetailRequestWrapper()
				{
					deploymentMode = "production",
					Body = new InvoiceDetailRequestBody()
					{
						InvoiceDetailRequestHeader = new InvoiceDetailRequestHeader()
						{
							invoiceDate = invoiceDate,
							operation = "new",
							purpose = "standard",
							invoiceOrigin = "supplier",
							invoiceID = invoiceNumber.ToString(),
							InvoiceDetailHeaderIndicator = new InvoiceDetailHeaderIndicator(),
							InvoiceDetailLineIndicator = new InvoiceDetailLineIndicator()
							{
								isAccountingInLine = "yes",
								isTaxInLine = "yes"
							},
					//		InvoicePartner = new invoicePartners,
					//		InvoiceDetailShipping = new InvoiceDetailShipping()
					//		{
					//			Contact = new[] {
					//	new Contact() {
					//		role = "shipFrom",
					//		Name = new Name(SupplierName, "en"),
					//		PostalAddress = new PostalAddress(SupplierName,
					//			ShipFromAddressStreet,
					//			ShipFromAddressCity, null,
					//				ShipFromAddressPostCode, null) {
					//			Country = new Country(
					//				GetISOCountryCode(ShipFromAddressCountry),
					//									ShipFromAddressCountry)
					//		}
					//	},
					//	new Contact() {
					//		role = "shipTo",
					//		Name = new Name(shipTo, "en"),
					//		PostalAddress = new PostalAddress(shipName,
					//			shipAddressStreet,
					//			shipCity, null, shipPostCode, null) {
					//			Country = new Country(
					//				GetISOCountryCode(shipCountry), shipCountry)
					//		}
					//	}
					//}
					//		},
							PaymentTerm = new PaymentTerm() { payInNumberOfDays = 30 }
				//			Extrinsic = extrinsics.Any() ? extrinsics.ToArray() : null,
				//			Comments = new[] {
				//	new Comments() { }
				//}
						},
						InvoiceDetailOrder = new InvoiceDetailOrder()
						{
							InvoiceDetailOrderInfo = new InvoiceDetailOrderInfo()
							{
								//MasterAgreementReference = new MasterAgreementReference()
								//{
								//	DocumentReference = new DocumentReference()
								//	{
								//		payloadID = orderPayloadId
								//	},
								//},
								OrderReference = new OrderReference()
								{
									DocumentReference = new DocumentReference()
									{
										payloadID = "11111111"
									}
								}
								//SupplierOrderInfo = new SupplierOrderInfo()
								//{
								//	orderID = orderNumber.ToString()
								//}
							},
							//InvoiceDetailItem = lineItems.ToArray()
						},
						InvoiceDetailSummary = new InvoiceDetailSummary()
						{
							SubtotalAmount = new SubtotalAmount()
							{
								Money = new Money("ZAF", Math.Abs(365))
							},
							Tax = new Tax()
							{
								Money = new Money("ZAF", Math.Abs(8))
								{
									//alternateAmount = Math.Abs(vatAmount),
									//alternateCurrency = currencycode
								},
								Description = new Description("Total Tax", "en"),
								TaxDetail = new TaxDetail()
								{
									purpose = "tax",
									category = "Standard Rate",
									percentageRate = "15%",
									TaxableAmount = new TaxableAmount()
									{
										Money = new Money("ZAF", Math.Abs(365))
									},
									TaxAmount = new TaxAmount()
									{
										Money = new Money("ZAF", Math.Abs(8))
									}
								}
							},
							//GrossAmount = isCreditNote ? null : new GrossAmount()
							//{
							//	Money = new Money(currencycode, Math.Abs(grossAmount))
							//},
							NetAmount = new NetAmount()
							{
								Money = new Money("ZAF", Math.Abs(365))
							}
							//DueAmount = isCreditNote ? null : new DueAmount()
							//{
							//	Money = new Money(currencycode, Math.Abs(dueAmount))
							//}
						}
					}
				}
			};

			return request;
			#pragma warning restore CS8618, CS0219, IDE0059 // Ignore Naming Rule Violations
        }

    }

}
