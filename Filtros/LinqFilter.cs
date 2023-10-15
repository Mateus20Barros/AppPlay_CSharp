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


    public static void FiltrarArtistasPorGenerosMusicais(List<Musica> musicas, string genero)
    {
        var artistasPoGeneroMusicais = musicas
            .Where(musica => musica.Genero.Contains(genero))
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();

        if (genero == string.Empty)
            Console.WriteLine("Informe um Genero musical.");

        Console.WriteLine("## Exibir Artistas Por Genero.\n");

        foreach(var artista in artistasPoGeneroMusicais)
            Console.WriteLine($"- {artista}");
    }


    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasDoArtista = musicas
            .Where(musica => musica.Artista!.Equals(nomeArtista))
            .ToList();

        if (nomeArtista == string.Empty)
            Console.WriteLine("Informe o nome do artista.");

        Console.WriteLine($"Musicas do Artista \"{nomeArtista}\"\n");

        foreach(var musica in musicasDoArtista)
            Console.WriteLine($"-> {musica.Nome}");
    }


    public static void FiltrarMusicasPorCSharp(List<Musica> musicas)
    {
        var buscarMusicasPorC = musicas
            .Where(musica => musica.Tonalidade.Equals("C#"))
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine("Buscar Todas as musicas em C#:");

        foreach(var musica in buscarMusicasPorC)
            Console.WriteLine($"-> {musica}");
    }
}
