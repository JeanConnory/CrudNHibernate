using MvcNHibernate.Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MvcNHibernate.Mappings;

public class FuncionarioMap : ClassMapping<Funcionario>
{
    public FuncionarioMap()
    {
        Id(x => x.Id, x =>
        {
            x.Generator(Generators.Increment);
            x.Type(NHibernateUtil.Int32);
            x.Column("Id");
        });

        Property(b => b.Nome, x =>
        {
            x.Length(100);
            x.Type(NHibernateUtil.String);
            x.NotNullable(true);
        });

        Property(b => b.Idade, x =>
        {
            x.Type(NHibernateUtil.Int32);
            x.NotNullable(true);
        });

        Property(b => b.Salario, x =>
        {
            x.Type(NHibernateUtil.Double);
            x.Scale(2);
            x.Precision(10);
            x.NotNullable(true);
        });
        //Table("Funcionarios");
    }
}