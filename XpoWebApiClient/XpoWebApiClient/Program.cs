using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;

namespace XpoWebApiClient {
    class Program {
        static void Main(string[] args) {
             IDataStore dataStore = new WebAPIDataStore("http://localhost:65270/");
             IDataLayer dataLayer = new SimpleDataLayer(new ReflectionDictionary(), dataStore);
             UnitOfWork uow = new UnitOfWork(dataLayer);
            Customer product = new Customer(uow) {
                FirstName = "Customer",
                LastName = "FoundFirst"
            };
            
            uow.Save(product);

            product = new Customer(uow) {
                FirstName = "Customer",
                LastName = "FoundSecond"
            };

            uow.CommitChanges();

            Customer search = uow.FindObject<Customer>( CriteriaOperator.Parse("FirstName=?", "Customer"));
            Console.WriteLine(search.ContactName);
            
            uow.Delete(search);
            uow.CommitChanges();

            search = uow.FindObject<Customer>(CriteriaOperator.Parse("FirstName=?", "Customer"));
            Console.WriteLine(search.ContactName);

            Console.ReadKey();


        }
    }
}
