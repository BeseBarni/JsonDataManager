namespace JsonDataManager.Data
{
    public class ApiCallerService
    {
        public async Task<T> GetApiAsync<T>(string path)
        { 
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(path);
                    return await response.Content.ReadFromJsonAsync<T>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
