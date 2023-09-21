// namespace Rest.Test;

// public class UnitTest1
// {
//     // [Fact]
//     // public void Test1()
//     // {

//     // }
//     [Fact]
//     public void AverageResponseTime_Requests()
//     {
//         // var allResponseTimes = new List<(DateTime Start, DateTime End)>();
//         DateTime start;
//         DateTime end;

//         using (var client = new HttpClient())
//         {
//             start = DateTime.Now;
//             var response = client.GetAsync("http://localhost:5270/api/Employee").Result;
//             end = DateTime.Now;
//         }


//         var expected = 1;
//         var actual = (int)(end - start).TotalMilliseconds;
//         Assert.False(actual <= expected, $"Expected average response time of less than or equal to {expected} ms but was {actual} ms.");
//     }
//     [Fact]
//     public void AverageAddTime_Requests()
//     {
//         // var allResponseTimes = new List<(DateTime Start, DateTime End)>();
//         DateTime start;
//         DateTime end;

//         using (var client = new HttpClient())
//         {
//             start = DateTime.Now;
//             var response = client.PutAsync("http://localhost:5270/api/Employee").Result;
//             end = DateTime.Now;
//         }


//         var expected = 1;
//         var actual = (int)(end - start).TotalMilliseconds;
//         Assert.False(actual <= expected, $"Expected average response time of less than or equal to {expected} ms but was {actual} ms.");
//     }
// }