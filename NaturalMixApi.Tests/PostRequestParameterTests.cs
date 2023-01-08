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
        public async Task Test_NaturalMixApi_GetComponentByName_False()
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            var postBody = 2;
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
    }
}