
---

### 📄 `README.md`

````markdown
# 🥷 Capitão Onigiri Scraper

Este projeto é um **web scraper em C#** que coleta informações de produtos da seção de mangás avulsos do site [Capitão Onigiri](https://www.capitaoonigiri.com.br).

Ele percorre todas as páginas da categoria e extrai:

- 🏷️ Nome do produto  
- 💰 Preço  
- 🖼️ Link da imagem  

## 💻 Tecnologias utilizadas

- [.NET Core](https://dotnet.microsoft.com/)
- [HtmlAgilityPack](https://html-agility-pack.net/) – para parsear e navegar pelo HTML
- `HttpClient` – para fazer as requisições HTTP

## 📦 Instalação

1. Clone este repositório:

```bash
git clone https://github.com/Pedro-2077/RaspagemManga.git
cd RaspagemManga
```

2. Restaure os pacotes e compile:

```bash
dotnet restore
dotnet build
```

3. Execute:

```bash
dotnet run
```

## 🔎 O que ele faz?

1. Acessa a página 1 da categoria `mangas avulsos`.
2. Descobre automaticamente o total de páginas disponíveis.
3. Itera por cada página e extrai:

   * Nome do mangá
   * Preço (sem símbolo de moeda)
   * URL da imagem do produto
4. Exibe todos os dados no terminal.

## 📂 Exemplo de saída

```txt
🔎 Total de páginas encontradas: 8

📄 Página 1:

1. Zetsuen no Tempest – Vol.1  
   Preço: R$15,00  
   Imagem: https://www.capitaoonigiri.com.br/wp-content/uploads/2023/08/tempest.jpg
```

## ⚠️ Aviso

Este scraper é apenas para fins educacionais. Consulte os **Termos de Uso** do site antes de realizar coletas em larga escala.




