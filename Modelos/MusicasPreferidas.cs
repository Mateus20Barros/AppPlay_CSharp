using System.Text.Json;
using System.Text.Json.Serialization;
namespace ScreenSoundApp.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> ListaDeMusicasFavoritas { get; }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Musicas favoritas de {Nome}\n");

        foreach(var musica in ListaDeMusicasFavoritas)
            Console.WriteLine($"-> {musica.Nome} de {musica.Artista}");
    }

    public void GerarArquivosJson()
    {
        string json = JsonSerializer
            .Serialize(new { nome = Nome, musicas = ListaDeMusicasFavoritas });

        string nomeArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeArquivo, json);
        Console.WriteLine("\nArquivo JSON criado com sucesso !!!");
        Console.WriteLine($"\nSalvo em {Path.GetFullPath(nomeArquivo)}");
    }
}
