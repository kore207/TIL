#### Client-side

* 사용자(Client's)의 컴퓨터에서 수행되는 action

#### Server-side

* Web server 에서 수행되는 action

> 이 떄 action은 프로그래밍 언어가 하는 모든 일을 말한다.



#### Blazor Server

* server-side ASP.NET COre application
* client 와 server 간 통신이 **SignalR** 을 통해 이루어진다.
* 지속적으로 client - server 간 연결이 이루어져야 한다.

#### Blazor WebAssembly

* Client-side application (브라우저에서 혼자 동작)
* API 사용시 새로운 application을 생성해야한다.
* 오프라인 작업이 가능하다
* API 는 **HttpClient** class를 사용한다. (아래 예시)

```  razor
// Index.razor
@page "/"
@inject HttpClient httpClient
@using Newtonsoft.Json
    <h1>Here is a list of Languages</h1>
@if (Languages != null &amp;&amp; Languages.Any())
{
    <ul>
        @foreach (var language in Languages)
        {
            <li>@language</li>
        }
    </ul>
}
<input @bind="MessageInput" @bind:event="oninput" />
<button @onclick="MessageInputClick">Add Language</button>
 
@code {
    public string MessageInput { get; set; }
 
    public List<string> Languages { get; set; }
 
    protected override async Task OnInitializedAsync()
    {
        Languages = await httpClient.GetJsonAsync<List<string>>("https://localhost:9000/api/language/getall");
    }
 
    public async Task MessageInputClick()
    {
        var postRequest = new Dictionary<string, string>();
        postRequest.Add("language", MessageInput);
 
        var requestMessage = new HttpRequestMessage()
        {
            Method = new HttpMethod("POST"),
            RequestUri = new Uri("https://localhost:9000/api/language/add"),
            Content = new StringContent(JsonConvert.SerializeObject(postRequest))
        };
        requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
 
        var response = await httpClient.SendAsync(requestMessage);
        var responseText = await response.Content.ReadAsStringAsync();
 
        Languages = JsonConvert.DeserializeObject<List<string>>(responseText);
 
        MessageInput = string.Empty;
    }

```

* SSR(server-side rendering) 이 사용되지 않는다.





