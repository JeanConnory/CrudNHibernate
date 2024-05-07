namespace MvcNHibernate.Models;

public class Funcionario
{
    public virtual int Id { get; set; }

    public virtual string Nome { get; set; } = string.Empty;

    public virtual int Idade { get; set; }

    public virtual double Salario { get; set; }
}
