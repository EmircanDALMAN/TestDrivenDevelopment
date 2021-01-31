using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        private Mock<ICustomerDal> _mockCustomerDal;
        private List<Customer> _dbCustomers;
        [TestInitialize] // - Testleri başlatırken çalışan blok
        public void Start() // - Setup denilebiliyor
        {
            _mockCustomerDal = new Mock<ICustomerDal>();
            _dbCustomers = new List<Customer>
            {
                new Customer{Id=1,FirstName="Ali"},
                new Customer{Id=2,FirstName="Ahmet"},
                new Customer{Id=3,FirstName="Ayşe"},
                new Customer{Id=4,FirstName="Aydın"},
                new Customer{Id=5,FirstName="Burhan"}
            };
            _mockCustomerDal.Setup(m => m.GetAll()).Returns(_dbCustomers);
        }
        [TestMethod]
        public void Tum_musteriler_Listelenebilmelidir()
        {
            //Arrange - Test için gerekli ortamı oluşturmak
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);

            //Act - Action alırız. 
            List<Customer> customers = customerService.GetAll();

            //Assert
            Assert.AreEqual(5, customers.Count); //Kaç bekliyorsun ve nereden bekliyorsun söylüyoruz

        }

        [TestMethod]
        public void A_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange - Test için gerekli ortamı oluşturmak
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);

            //Act - Action alırız. 
            List<Customer> customers = customerService.GetCustomersByInitial("A");

            //Assert
            Assert.AreEqual(4, customers.Count); //Kaç bekliyorsun ve nereden bekliyorsun söylüyoruz
        }
        [TestMethod]
        public void kucuk_a_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange - Test için gerekli ortamı oluşturmak
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);

            //Act - Action alırız. 
            List<Customer> customers = customerService.GetCustomersByInitial("a");

            //Assert
            Assert.AreEqual(4, customers.Count); //Kaç bekliyorsun ve nereden bekliyorsun söylüyoruz
        }
    }
}


//Müşteriler listelenebilmeli
//Müşteriler baş harflerine göre sayfalanabilmeli

    //Test Case
    //5 elemanlı bir listem olsun