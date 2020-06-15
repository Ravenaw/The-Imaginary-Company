
using System;
using System.Threading.Tasks;
using InventoryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Imaginary_Company;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login_Test_Method_Successful()
        {
            bool expectedresult = true;

            ViewModel.Instance.VMSetUser("Andrea", "124Dbu");
            bool actualresult = ViewModel.Instance.VMCheckPassword();

            Assert.AreEqual(expectedresult, actualresult);
        }
        [TestMethod]
        public void Login_Test_Method_Unsuccessful()
        {
            bool expectedresult = true;

            ViewModel.Instance.VMSetUser("Andrea", "aaaa");
            bool actualresult = ViewModel.Instance.VMCheckPassword();

            Assert.AreNotEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void Search_ArticleSuccessful()
        {
            ViewModel.Instance.TIC = "4568";
            Task.Run(()=>ViewModel.Instance.Search()).Wait();


            Assert.AreEqual("78945612", ViewModel.Instance.SearchResult.IAN);
        }
    }
}
