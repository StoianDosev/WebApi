using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client
{
    class Program
    {
        private static HttpClient client;
        static void Main(string[] args)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:46829/api/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));




            string commentUrl = "comments/";
            string categoryUrl = "categories/";
            string placeUrl = "places/";
            string voteUrl = "votes/";

            string date = "12.12.12";

            Category cat1 = new Category() { Name = null, Id = 1 };
            Category cat2 = new Category() { Name = "Category na Place", Created = date };

            Comment com = new Comment() { UserName = "Aaaaaaa Petrov", PlaceID = 3, Text = "Some text" };
            Place place = new Place() { Name = "Place Null", Latitude = 1, Longitude = 123456789101, Description="Some description" };
            Vote vote = new Vote() { UserName = "Pesho Peshev", Value = 3544, PlaceId = 1 };

            //AddNewItem<Place>(placeUrl, place);
            //GetAllAsync<Place>(placeUrl);
            //GetOne<Place>(placeUrl, 1);
            //AddNewItem<Category>(categoryUrl, cat2);
            //GetAllAsync<Category>(categoryUrl);
            //GetOne<Category>(categoryUrl, 4);

            //AddNewItem<Vote>(voteUrl, vote);
            //GetAllAsync<Vote>(voteUrl);
            //GetOne<Vote>(voteUrl, 1);
            //AddNewItem<Comment>(commentUrl, com);
            //GetAllAsync<Comment>(commentUrl);
            //GetOne<Comment>(commentUrl, 2);

            //var response = client.PostAsJsonAsync<Place>(categoryUrl, place).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Post added! {0}, {1}", (int)response.StatusCode, response.ReasonPhrase);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}

            //MyCompare myCompare = new MyCompare();

            //myCompare.Compare(cat1, cat2);

            //string s = "";
            //string str = "";
            //s.CompareTo(str);

            //List<Category> list = new List<Category>()
            //{
            //    new Category(){Id = 1},
            //    new Category(){Id = 2},
            //    new Category(){Id = 100},

            //};

            //list.Sort(myCompare);

            //cat1.Equals(
            Console.ReadLine();
        }


        internal async static void AddNewItem<T>(string serviceUrl, T category)
        {
            var response = await client.PostAsJsonAsync<T>(serviceUrl, category);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post added! {0}, {1} ", (int)response.StatusCode, response.ReasonPhrase);
            }
            else
            {
                Console.WriteLine("{0} ({1})  :{2}", (int)response.StatusCode, response.ReasonPhrase, response.RequestMessage);
            }
        }

        internal async static void GetAllAsync<T>(string serviceUrl)
        {
            HttpResponseMessage response = await client.GetAsync(serviceUrl);

            if (response.IsSuccessStatusCode)
            {
                var resultObjects = await response.Content.ReadAsAsync<IEnumerable<T>>();

                var resultJson = await response.Content.ReadAsStringAsync();

                //Console.WriteLine(resultJson);
                var resultObj = JsonConvert.DeserializeObject<List<T>>(resultJson);

                foreach (var item in resultObjects)
                {
                    if (item is Category)
                    {
                        var category = item as Category;
                        Console.WriteLine("Id: {0,-5} name: {1}", category.Id, category.Name);
                    }
                    else if (item is Comment)
                    {
                        var comment = item as Comment;
                        Console.WriteLine("Id: {0} name: {1} comment: {2}", comment.Id, comment.UserName, comment.Text);
                    }
                    else if (item is Place)
                    {
                        var place = item as Place;
                        Console.WriteLine("Id: {0}. name: {1}  latitude: {2}   longitude: {3}", place.Id, place.Name, place.Latitude, place.Longitude);
                    }
                    else
                    {
                        var vote = item as Vote;
                        Console.WriteLine("Id: {0} name: {1} value: {2}", vote.Id, vote.UserName, vote.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal async static void GetOne<T>(string serviceUrl, int id)
        {
            HttpResponseMessage response = await client.GetAsync(serviceUrl + id);

            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsAsync<T>();

                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                if (item is Place)
                {
                    var place = item as Place;
                    Console.WriteLine("Id: {0}. name: {1}  latitude: {2}   longitude: {3}", place.Id, place.Name, place.Latitude, place.Longitude);
                }
                else if (item is Comment)
                {
                    var comment = item as Comment;
                    Console.WriteLine("Id: {0} name: {1} comment: {2} placeId: {3}", comment.Id, comment.UserName, comment.Text, comment.PlaceID);
                }
                else if (item is Vote)
                {
                    var vote = item as Vote;
                    Console.WriteLine("Id: {0} name: {1} value: {2}  {3}", vote.Id, vote.UserName, vote.Value, vote.PlaceId);
                }
                else if (item is Category)
                {
                    Category category = item as Category;
                    Console.WriteLine("Id: {0,-5} name: {1}", category.Id, category.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

    }
}
