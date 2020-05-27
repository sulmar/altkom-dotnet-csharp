using System;

namespace Altkom.CSharp.Models
{
    public class Customer : Base
    {
        // backfield
        private string firstName;
        
        public string FirstName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException();
                }

                this.firstName = value;
            }
            get
            {
                return this.firstName;
            }
        }

        // auto-property
        public string LastName { get; set; }

        // Property read-only
        public string FullName
        {
            get
            {
                // 'Pan(i)' + FirstName + ' ' + LastName;
                // return String.Format("Pan(i) {0} {1}", FirstName, LastName);
                return $"Pan(i) {FirstName} {LastName}";
            }
        }

        //public void SetFirstName(string value)
        //{
        //    this.firstName = value;
        //}

        //public string GetFirstName()
        //{
        //    return this.firstName;
        //}

        // konstuktor bezparametryczny

        public Customer()
        {
        }

        public Customer(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

    }
}
