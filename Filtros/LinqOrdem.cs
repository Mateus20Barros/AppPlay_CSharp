using ScreenSoundApp.Modelos;
namespace ScreenSoundApp.Filtros;

internal class LinqOrdem
{
    public static void ExibirListaDeArtistasOrdenandos(List<Musica> musicas)
    {
        var artistasOrdenados = musicas
            .OrderBy(musica => musica.Artista)
            .Select(musica=> musica.Artista.Replace("*", ""))
            .Distinct()
            .ToList();

        Console.WriteLine("## Lista de Artistas Ordenados.\n");

        foreach(var artista in artistasOrdenados)
        {
            Console.WriteLine($"-> {artista}");
        }
    }
}
