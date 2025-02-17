using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Volo.Abp.TestApp.Domain;

public class AppEntityWithNavigations : AggregateRoot<Guid>
{
    protected AppEntityWithNavigations()
    {

    }

    public AppEntityWithNavigations(Guid id, string name)
        : base(id)
    {
        Name = name;
        FullName = name;
    }

    public string Name { get; set; }

    public string FullName { get; set; }

    public AppEntityWithValueObjectAddress AppEntityWithValueObjectAddress { get; set; }

    public virtual AppEntityWithNavigationChildOneToOne OneToOne { get; set; }

    public virtual List<AppEntityWithNavigationChildOneToMany> OneToMany { get; set; }

    public virtual List<AppEntityWithNavigationChildManyToMany> ManyToMany { get; set; }
}

public class AppEntityWithValueObjectAddress : ValueObject
{
    public AppEntityWithValueObjectAddress(string country)
    {

        Country = country;
    }

    public string Country { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Country;
    }
}


public class AppEntityWithNavigationChildOneToOne : Entity<Guid>
{
    public string ChildName { get; set; }
}

public class AppEntityWithNavigationChildOneToMany : Entity<Guid>
{
    public Guid AppEntityWithNavigationId { get; set; }

    public string ChildName { get; set; }
}

public class AppEntityWithNavigationChildManyToMany : AggregateRoot<Guid>
{
    public string ChildName { get; set; }

    public virtual List<AppEntityWithNavigations> ManyToMany { get; set; }
}

public class AppEntityWithNavigationsAndAppEntityWithNavigationChildManyToMany
{
    public Guid AppEntityWithNavigationsId { get; set; }

    public Guid AppEntityWithNavigationChildManyToManyId { get; set; }
}
