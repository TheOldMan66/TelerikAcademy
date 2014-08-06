// ORIGINAL:
public void Cook() 
public class Chef
{
    private Bowl GetBowl()
    {   
        //... 
    }
    private Carrot GetCarrot()
    {
        //...
    }
    private void Cut(Vegetable potato)
    {
        //...
    }  
    public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        Bowl bowl;
        Peel(potato);
                
        Peel(carrot);
        bowl = GetBowl();
        Cut(potato);
        Cut(carrot);
        bowl.Add(carrot);
                
        bowl.Add(potato);
    }
    private Potato GetPotato()
    {
        //...
    }
}

// REFACTORED:
public class Chef
{
    private Bowl GetBowl()
    {   
        //... 
    }
    private Carrot GetCarrot()
    {
        //...
    }
    private Potato GetPotato()
    {
        //...
    }
    private void Cut(Vegetable potato)
    {
        //...
    }  

    public void Cook()
    {
        Bowl bowl = GetBowl();

        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();                
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
                
    }
}

public void Cook();
