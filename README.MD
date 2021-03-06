# Melbourne Azure web camp
Your presenter today: David Burela
Code located at: https://github.com/DavidBurela/MelbournePrimeMinisters
Survey: aka.ms/mscloudessmelbourne17sept

Today's resources are available at: 
https://github.com/Azure-Readiness/DevCamp

Times (all meals are on level 11):
- Morning tea: 10:30
- Lunch: 12:30
- Afternoon tea: 2:30

1. Keynote
2. IaaS (VMs. What not to do).
3. Paas. ASP.Net MVC web apps (& deploying to Azure website & SQL Azure)
4. Web apps (websites, logic apps, API apps, mobile services)
5. Data Storage (Blobs, Queues)
6. Data Platform (SQL, Document DB)
7. Web API (how to create and query with Fiddler and in code)
8. Cloud futures: Talking about IoT (docker, Win10 IoT core, Event Hubs, Event Steams, Microservices, actors)

### Bonus code for calling Web API from C# code
Nuget packages
Microsoft.Net.Http
Web API client

var client = new HttpClient();
var response = await client.GetAsync("http://melbourneprimeministers.azurewebsites.net/api/PrimeMinisters/");

var primeMinisters = await response.Content.ReadAsAsync<IEnumerable<PrimeMinister>>();

var sb = new StringBuilder();
foreach (var primeMinister in primeMinisters)
{
    sb.AppendLine(string.Format("Prime Minister:{0} year:{1}", primeMinister.Name, primeMinister.Year));
}

var formattedText = sb.ToString();