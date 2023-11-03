<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="120"/>
</div> <br>

### 📃 Sobre o Projeto

**AppPlay e uma aplicação desenvolvida na linguagem `CSharp`, que consume uma API de musicas, onde as musicas pode ser buscadas por `Genero` e `Artista`.** <br>
**O resultado das buscas são exibidas no console.** <br>
**Nesse projeto foi utilizados varios recursos da linguagem `CSharp`, mostrados em topicos a seguir.** <br><br>

**``🏷️ HttpClient ``** <br>
**E uma classe na biblioteca padrão do .NET usada para realizar solicitações HTTP e receber respostas de servidores web.** <br>
```CSharp
using System.Text.Json;
using ScreenSoundApp.Modelos;

using ( HttpClient client = new() )
{
    try
    {
        string URL = "https://guilhermeonrails.github.io/api-csharp-songs/songs.json";
        string resposta = await client.GetStringAsync(URL);

        Console.WriteLine(resposta);
    }
    catch(Exception error)
    {
        Console.WriteLine($"Temos um problema: { error.message }");
    }
}
```
***No codigo acima foi instanciado a classe `HttpClient` com o nome `client` dentro do bloco `using`.*** <br>
***Depois dentro do bloco `try` foi declarado a variavel `resposta` do tipo `string` para obter dados da URL `https://guilhermeonrails.github.io/api-csharp-songs/songs.json`, 
se a requisição da URL for bem sucedida será mostrado os objetos da URL no console, caso ocorra algum erro na requisição, será mostrado mensagem do bloco `catch` no console.*** <br><br>

**``🏷️ Json Serialization ``** <br>
**E uma classe que faz parte da biblioteca padrão do .NET, usado para converter objetos .NET em formato JSON e vice-versa.** <br>
**`Serialization` - Converte um objeto .NET em texto no formato JSON.** <br>
```CSharp
using System.Text.Json;
namespace ScreenSoundApp.Modelos;

internal class MusicasPreferidas
{
    public void GerarArquivosJson()
    {
        string json = JsonSerializer.Serialize (
          new { nome = Nome, musicas = ListaDeMusicasFavoritas }
        );

        string nomeArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeArquivo, json);
        Console.WriteLine("\nArquivo JSON criado com sucesso !!!");
        Console.WriteLine($"\nSalvo em {Path.GetFullPath(nomeArquivo)}");
    }
}
```
***Na classe `MusicasPreferidas` foi criado o metodo `GerarArquivosJson()` onde e usado a `Serialization` que converte objeto `.NET` 
em texto no formato `JSON`, assim quando o metodo e executado e gerado um arquivo com os dados no formato de texto.*** <br>

**`Deserialization` - Converte um texto no formato JSON para objeto .NET.** <br>
```CSharp
using System.Text.Json;
using ScreenSoundApp.Modelos;

using ( HttpClient client = new() )
{
    try
    {
        ...
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
    }
    catch(Exception error) { ... }
}
```
***No aqruivo `Program.cs` foi criado uma variavel chamada `musicas` onde e usado o `Deserialization` que converte textos no 
formato `JSON` em objetos .NET, e armazena esse objetos em uma lista do tipo musica.*** <br><br>

**``🏷️ JsonProperty ``** <br>
**Anotação usada para mapear propriedades de objetos em C# para nomes de propriedades em objetos `JSON`.** <br>
```CSharp
using System.Text.Json.Serialization;
namespace ScreenSoundApp.Modelos;

internal class Musica
{
    [JsonPropertyName("song")]
    public string Nome { get; set; }

    [JsonPropertyName("artist")]
    public string Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    [JsonPropertyName("key")]
    public int Key { get; set; }
}
```
***Na classe `Musica` foi usada anotação `[JsonPropertyName("")]` para nomear as propriedades recebidas da API.*** <br>
***- A propriedade `song` do objeto recebido da API foi nomeada para `Nome`*** <br>
***- A propriedade `artist` do objeto recebido da API foi nomeada para `Artista`*** <br>
***- A propriedade `duration_ms` do objeto recebido da API foi nomeada para `Duracao`*** <br>
***- A propriedade `genre` do objeto recebido da API foi nomeada para `Genero`*** <br>
***- A propriedade `key` do objeto recebido da API foi nomeada para `Chave`*** <br><br>

**``🏷️ LinQ ``** <br>
**Usado para realizar consultas de dados em Lista, Arrays, Banco de dados etc.** <br>
```CSharp
using ScreenSoundApp.Modelos;
namespace ScreenSoundApp.Filtros;

internal class LinqFilter
{

    public static void FiltrarTodosGenerosMusicais(List<Musica> musicas)
    {
        var todosGenerosMusicais = musicas
            .Select(generos => generos.Genero)
            .Distinct()
            .ToList();

        foreach (var genero in todosGenerosMusicais)
            Console.WriteLine($"- {genero}");
    }
}
```
***Na classe `LinqFilter` foi implementados alguns metodos de filtros dos dados obtido da API. Um desses metodos e o metodo `FiltrarTodosGenerosMusicais()` que recebe uma lista do tipo musica, onde e selecionda todas as musica por generos e selecione apenas um musica se houve 02 cadastras com o mesmo nome, depois percorrendo a lista com o metodo `foreach()` e mostrado no console.*** <br><br>

<div align="center">
    :octocat: Feito por Mateus Barros :octocat:
</div>

---
