
using System;
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

            User test = ViewModel.Instance.CurrentUser;
            test.SetUser("Andrea", "124Dbu");

            bool actualresult = test.ValidUser();
            Assert.AreEqual(expectedresult, actualresult);
        }
        [TestMethod]
        public void Login_Test_Method_Unsuccessful()
        {
            bool expectedresult = true;

            User test = ViewModel.Instance.CurrentUser;
            test.SetUser("Andrea", "124D");

            bool actualresult = test.ValidUser();
            Assert.AreNotEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void Search_ArticleSuccessful()
        {
            ViewModel.Instance.TIC = "4568";
            ViewModel.Instance.Search();

            Assert.AreEqual("78945612",ViewModel.Instance.SearchResult.IAN);

        }
    }
}
