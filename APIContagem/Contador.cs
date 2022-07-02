namespace APIContagem;

public class Contador
{
    private int _valorAtual = 0;

    public int ValorAtual { get => _valorAtual; }
    public string Local { get => ApplicationStatus.Local; }
    public string Kernel { get => ApplicationStatus.Kernel; }
    public string Framework { get => ApplicationStatus.Framework; }

    public void Incrementar() => _valorAtual++;
}