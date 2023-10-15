using System.Text.Json;
using ScreenSoundApp.Modelos;
using ScreenSoundApp.Filtros;

using ( HttpClient client = new() )
{
    try
    {
        string resposta = await client
            .GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        LinqFilter.FiltrarTodosGenerosMusicais(musicas);
        LinqOrdem.ExibirListaDeArtistasOrdenandos(musicas);
        LinqFilter.FiltrarArtistasPorGenerosMusicais(musicas, "pop");
        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Michael Jacksom");
        LinqFilter.FiltrarMusicasPorCSharp(musicas);


        var musicasPreferidasPessoa = new MusicasPreferidas("Mateus");
        musicasPreferidasPessoa.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasPessoa.AdicionarMusicasFavoritas(musicas[377]);
        musicasPreferidasPessoa.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasPessoa.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasPessoa.AdicionarMusicasFavoritas(musicas[1467]);

        musicasPreferidasPessoa.ExibirMusicasFavoritas();
        musicasPreferidasPessoa.GerarArquivosJson();

    }
    catch (Exception error)
    {
        Console.WriteLine($"Temos um problema: {error.Message}");
    }
}