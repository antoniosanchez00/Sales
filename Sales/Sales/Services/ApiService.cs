



namespace Sales.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Sales.Common.Models;
   
    public class ApiService
   {    
        //metodo geneerico que nos sirve para consumir de cualquier api
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient(); //nos sirve para hacer la comunicacion con la api
                client.BaseAddress = new Uri(urlBase); //pasamos la url base donde vamos a consumir el servicio

                var url = $"{prefix}{controller}";

                var response = await client.GetAsync(url);//hace la comunicacion 
                
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = list,
                };
            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,

                };
            }
        }
    }
}
