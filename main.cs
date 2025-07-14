using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://www.kabum.com.br/busca/monitor-144hz";

        HttpClient client = new HttpClient();

        // Finge que somos um navegador
        client.DefaultRequestHeaders.Add("User-Agent", 
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

        try
        {
            // Faz a requisição para a Kabum
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();

                // Carrega o HTML em um objeto que podemos navegar
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Cada produto está dentro de um <div> com class "productCard"
                var produtos = doc.DocumentNode.SelectNodes("//div[contains(@class, 'productCard')]");

                if (produtos != null)
                {
                    foreach (var produto in produtos)
                    {
                        // Nome do produto (está em <span> ou <h2>)
                        var nome = produto.SelectSingleNode(".//span[@class='nameCard']")?.InnerText?.Trim()
                                   ?? produto.SelectSingleNode(".//h2")?.InnerText?.Trim();

                        // Preço do produto (classe 'priceCard')
                        var preco = produto.SelectSingleNode(".//span[contains(@class,'priceCard')]")?.InnerText?.Trim();

                        // Link do produto (dentro da tag <a>)
                        var link = produto.SelectSingleNode(".//a")?.GetAttributeValue("href", "");

                        if (!string.IsNullOrEmpty(link) && !link.StartsWith("http"))
                            link = "https://www.kabum.com.br" + link;

                        Console.WriteLine($"Nome: {nome}");
                        Console.WriteLine($"Preço: {preco}");
                        Console.WriteLine($"Link: {link}");
                        Console.WriteLine(new string('-', 50));
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum produto encontrado na página.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao acessar Kabum. Código: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}
