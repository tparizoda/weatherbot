public class OpenMeteoClient
{
    private readonly HttpClient httpClient;

    public OpenMeteoClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task <WeatherResponse> GetweatherAsync(double longitude, double latitude)
    {
        var route = $"/v1/forecast?latitude={latitude.ToString().Replace(",", "."):F5}&longitude={longitude.ToString().Replace(",", "."):F5}&current_weather=true";;
        return httpClient.GetFromJsonAsync<WeatherResponse>(route);
    }
}