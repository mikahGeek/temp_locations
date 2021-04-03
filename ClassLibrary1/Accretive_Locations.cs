using System;

namespace ClassLibrary1
{
    public class Accretive_Locations
    {
        #region Instance Properties

        public Int32 ID { get; set; }

        public String Code { get; set; }

        public String Description { get; set; }

        public String Type { get; set; }

        public Int32? Parent { get; set; }

        public String ConnectionString { get; set; }

        public String Address1 { get; set; }

        public String Address2 { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String PostalCode { get; set; }

        public String ServerPath { get; set; }

        public String Name { get; set; }

        public String PhoneNumber { get; set; }

        public String PaymentAddress { get; set; }

        public String PaymentPayableTo { get; set; }

        public String PaymentAddress1 { get; set; }

        public String PaymentAddress2 { get; set; }

        public String PaymentAddressCity { get; set; }

        public String PaymentAddressState { get; set; }

        public String PaymentAddressPostalCode { get; set; }

        public String DatabaseName { get; set; }

        public Decimal? TimeZone { get; set; }

        public String AppealReplyTo { get; set; }

        public String AppealReplyAddress1 { get; set; }

        public String AppealReplyAddress2 { get; set; }

        public String AppealReplyCity { get; set; }

        public String AppealReplyState { get; set; }

        public String AppealReplyZip { get; set; }

        public String AppealReplyPhone { get; set; }

        public String TaxID { get; set; }

        public String PTAN { get; set; }

        public int EnvironmentID { get; set; }

        public String CrossSiteCode { get; set; }

        #endregion Instance Properties

    }
}
