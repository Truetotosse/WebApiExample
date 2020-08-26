using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace XpoWebApiClient {
    public class Customer : XPObject {
        public Customer(Session session) : base(session) { }
        private string fFirstName;
        public string FirstName {
            get { return fFirstName; }
            set { SetPropertyValue(nameof(FirstName), ref fFirstName, value); }
        }

        private string fLastName;
        public string LastName {
            get { return fLastName; }
            set { SetPropertyValue(nameof(LastName), ref fLastName, value); }
        }
        [PersistentAlias("Concat([FirstName], ' ', [LastName])")]
        public string ContactName {
            get { return (string)EvaluateAlias(nameof(ContactName)); }
        }


    }
}
