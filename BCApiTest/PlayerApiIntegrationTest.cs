using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest
{
    
    public class PlayerApiIntegrationTest
    {
        [Fact]
        public void Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.GetAsync("/api/player").Result;

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

                
        }

        [Fact]
        public void Test_Post_InvalidSelectionID()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.PostAsync("/api/player/create", new StringContent(
                   JsonConvert.SerializeObject(new PlayerModel() {Name="Vladislav", Surname="Stojkovic", BirthDate = new DateTime(1998,7,24), SelectionID=20}), Encoding.UTF8, "application/json"
                )).Result;

                

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }


        [Fact]
        public void Test_Post_ShouldBeValid()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.PostAsync("/api/player/create", new StringContent(
                   JsonConvert.SerializeObject(new PlayerModel() { Name = "Vladislav", Surname = "Stojkovic", BirthDate = new DateTime(1998, 7, 24)}), Encoding.UTF8, "application/json"
                )).Result;



                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
