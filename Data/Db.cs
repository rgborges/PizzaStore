public record Pizza
{
    public int Id {get; set;}
    public string ? Name {get; set;}
}

public class PizzaDb
{
    private List<Pizza> _pizzas = new List<Pizza>()
    {
        new Pizza{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
        new Pizza{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
        new Pizza{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"} 
    };

    public List<Pizza> GetPizzas()
    {
        return _pizzas;
    }
    public Pizza ? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }
    public Pizza CreatePizza(Pizza pizza)
    {
        _pizzas.Add(pizza);
        return pizza;
    }
    public Pizza UpdatePizza(Pizza update)
    {
        _pizzas = _pizzas.Select( p => {
            if(p.Id == update.Id)
            {
                p.Name = update.Name;
            }
            return p;
        }).ToList();
        return update;
    }
    public void RemovePizza(int id)
    {
        _pizzas = _pizzas.FindAll(pizzas => pizzas.Id == id).ToList();
    }
}
