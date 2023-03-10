using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NaturalMixApi.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(2)]
        [TestCase(2.4)]
        [TestCase('a')]
        [TestCase(true)]
        public async Task Test_NaturalMixApi_GetComponentByName_False(object postBody)
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            //var postBody = 2;
            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);                
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public async Task Test_NaturalMixApi_GetComponentByName_True()
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            var postBody = "2";
            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        [TestCase(2)]
        [TestCase(2.4)]
        [TestCase('a')]
        [TestCase(true)]
        public async Task Test_NaturalMixApi_RecognizeImage_False(object postBody)
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem/recognize";
            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public async Task Test_NaturalMixApi_RecognizeImage_True()
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem/recognize";
            var postBody = new byte[1];
            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}