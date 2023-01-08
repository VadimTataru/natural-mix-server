using NaturalMixApi.Controllers;
using NaturalMixApi.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NaturalMixApi.Tests
{
    public class ExistenceComponentTests
    {
        private readonly List<string> nonExistingCases = new List<string> { "aaaaaaa", "bvsvsvsv", "1241", "testoviy case" };
        private readonly List<string> existingCases = new List<string> { "allantoin", "limoene", "glycol distearate", "с9-12 alkane" };

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCase("C#WebApiTest")]
        public async Task Test_ExistingComponent_Single_Null(string singleCase)
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            List<ComponentItem>? componentDetails;
            var postBody = singleCase;

            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                componentDetails = await response.Content.ReadFromJsonAsync<List<ComponentItem>>();
                if(componentDetails != null)
                {
                    foreach (var component in componentDetails)
                    {
                        if (component.Origin != null)
                            Assert.Fail();
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        [TestCase("water")]
        public async Task Test_ExistingComponent_Single_NotNull(string singleCase)
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            List<ComponentItem>? componentDetails;
            var postBody = singleCase;

            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                componentDetails = await response.Content.ReadFromJsonAsync<List<ComponentItem>>();
                if (componentDetails != null)
                {
                    foreach (var component in componentDetails)
                    {
                        if (component.Origin == null)
                            Assert.Fail();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public async Task Test_ExistingComponent_Multiple_Null()
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            List<ComponentItem>? componentDetails;
            var postBody = nonExistingCases;

            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                componentDetails = await response.Content.ReadFromJsonAsync<List<ComponentItem>>();
                if (componentDetails != null)
                {
                    foreach (var component in componentDetails)
                    {
                        if (component.Origin != null)
                            Assert.Fail();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public async Task Test_ExistingComponent_Multiple_NotNull()
        {
            var client = new HttpClient();
            string url = "https://localhost:7246/api/ComponentItem";
            List<ComponentItem>? componentDetails;
            var postBody = existingCases;

            try
            {
                using var response = await client.PostAsJsonAsync(url, postBody);
                componentDetails = await response.Content.ReadFromJsonAsync<List<ComponentItem>>();
                if (componentDetails != null)
                {
                    foreach (var component in componentDetails)
                    {
                        if (component.Origin != null)
                            Assert.Fail();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
