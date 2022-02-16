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
    
    public class ApiIntegrationTest
    {
        [Fact]
        public void Test_Players_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.GetAsync("/api/player").Result;

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

                
        }

        [Fact]
        public void Test_Players_Post_InvalidSelectionID()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.PostAsync("/api/player/create", new StringContent(
                   JsonConvert.SerializeObject(new PlayerModel() {Name="Vladislav", Surname="Stojkovic", BirthDate = new DateTime(1998,7,24), SelectionID=20}), Encoding.UTF8, "application/json"
                )).Result;

                

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void Test_Selections_GetInvalidID(int id)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.GetAsync("/api/Selection/"+ id).Result;

                
                 
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
     

        [Fact]
        public void Test_Gyms_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.GetAsync("/api/gym").Result;

                response.EnsureSuccessStatusCode();
                

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }


        }

        [Fact]
        public void Test_InvalidRequest()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = client.GetAsync("/api/gymss").Result;

               

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
